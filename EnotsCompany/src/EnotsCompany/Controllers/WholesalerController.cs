using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServiceReference_Item;
using ServiceReference_Category;
using ServiceReference_Supplier;
using ServiceReference_Wholesaler;
using EnotsCompany.Models;
using EnotsCompany.Data;
using Microsoft.AspNetCore.Identity;
using ServiceReference_Feedback;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace EnotsCompany.Controllers
{
    public class WholesalerController : Controller
    {
        ApplicationRoleManager _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        static string _id = string.Empty;



        FeedbackServiceClient fb = new FeedbackServiceClient();
        static ItemServiceClient itm = new ItemServiceClient();
        CategoryServiceClient cs = new CategoryServiceClient();
        SupplierServiceClient sup = new SupplierServiceClient();
        ServiceReference_Unit.UnitServiceClient unit = new ServiceReference_Unit.UnitServiceClient();
        WholesalerServiceClient ws = new WholesalerServiceClient();
        static ServiceReference_PurchaseOrder.PurchaseOrderServiceClient po = new ServiceReference_PurchaseOrder.PurchaseOrderServiceClient();
        ServiceReference_Invoice.InvoiceServiceClient inc = new ServiceReference_Invoice.InvoiceServiceClient();
        ServiceReference_PurchaseOrderDetail.PurchaseOrderDetailsServiceClient pod = new ServiceReference_PurchaseOrderDetail.PurchaseOrderDetailsServiceClient();
        ServiceReference_Country.CountryServiceClient country = new ServiceReference_Country.CountryServiceClient();
        ServiceReference_Invoice.InvoiceServiceClient iv = new ServiceReference_Invoice.InvoiceServiceClient();

        public WholesalerController(ApplicationRoleManager roleManager, UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            ApplicationUser user = await _userManager.GetUserAsync(HttpContext.User);
            _id = await getWholesalerId(user.Email);
            ViewBag.active = "order";

            if (!String.IsNullOrEmpty(_id))
            {
                try
                {
                    List<ServiceReference_Invoice.Invoice> invoices = (await iv.getAllInvoiceAsync()).Where(i => i.WholesalerId == _id).OrderByDescending(p => p.InvoiceDate).ToList();
                    return View(invoices);
                }
                catch (Exception ex)
                {
                    return View();
                }
            }
            return View();
        }
        public async Task<IActionResult> Inquiry(string searchString)
        {
            ApplicationUser user = await _userManager.GetUserAsync(HttpContext.User);

            if (user != null)
            {
                _id = await getWholesalerId(user.Email);
                ViewData["CurrentFilter"] = searchString;
                ViewBag.active = "inquiry";

                if (!String.IsNullOrEmpty(searchString))
                {
                    return RedirectToAction("Category", "Home", new { searchString });
                }
                if (!String.IsNullOrEmpty(_id))
                {

                    ServiceReference_PurchaseOrder.PurchaseOrder[] orders = await po.findPurchaseOrderByWSIdAsync(_id);
                    return View(orders);
                }
                return View();
            }
            else return RedirectToAction("Login", "Account");
        }
        public async Task<JsonResult> getPurchase(string id)
        {
            var purcharse = await po.findPurchaseOrderByIdAsync(id);
            return Json(purcharse);
        }

        public async Task<string> getWholesalerId(string email)
        {
            var wholesaler = (await ws.getAllWholesalerAsync()).Where(w => w.Email == email).SingleOrDefault();
            return wholesaler.WholesalerId;
        }

        [HttpPost]
        public async Task<string> ConfirmPurchase(string purchaseId)
        {
            var purchase = await po.findPurchaseOrderByIdAsync(purchaseId);
            var purchasedt = (await po.findPurchaseOrderDetailbypIdAsync(purchase.ReplyId)).SingleOrDefault();
            var product = await itm.findItembyIdAsync(purchasedt.ItemId);
            var wholesaler = await ws.findWholesalerByIdAsync(purchase.WholesalerId);
            ServiceReference_Invoice.Invoice invoice = new ServiceReference_Invoice.Invoice();
            purchase.StatusPurchase = "confirmed";
            purchase.StatusInquiry = "Readed";
            bool res = await po.updatePurchaseOrderAsync(purchase);
            if (res)
            {
                invoice.InvoiceId = await iv.getInvoiceIdAsync(purchaseId);
                invoice.PurchaseOrderId = purchase.ReplyId;
                invoice.SupplierId = product.SupplierId;
                invoice.WholesalerId = purchase.WholesalerId;
                invoice.EmloyeeID = 1;
                invoice.InvoiceDate = DateTime.Now;
                invoice.PaymentMethodId = 1;
                invoice.Status = "unpaid";
                invoice.ShipFee = 0;
                invoice.ShipAddress = wholesaler.AddressWS;
                invoice.Total = (double)purchasedt.LineTotal;

                bool msg = await iv.createInvoiceAsync(invoice);
                if (msg)
                    return "success";
                else return "fail";
                // return "success";
            }
            else return "fail";
        }


        public static async Task<List<ServiceReference_PurchaseOrder.PurchaseOrder>> getListReply(string purchaseId)
        {
            var lst_reply = (await po.findPurchaseOrderByWSIdAsync(_id)).Where(x => x.ReplyId == purchaseId).ToList();
            return lst_reply;
        }

        public static async Task<ServiceReference_Item.Item> getValueById(int itemId)
        {
            ServiceReference_Item.Item item = await itm.findItembyIdAsync(itemId);
            return item;
        }
        public async Task<IActionResult> Account(string msg)
        {
            ApplicationUser user = await _userManager.GetUserAsync(HttpContext.User);
            _id = await getWholesalerId(user.Email);
            ViewBag.active = "account";
            if (!String.IsNullOrEmpty(msg))
            {
                ViewBag.msg = msg;
            }

            if (!String.IsNullOrEmpty(_id))
            {
                ServiceReference_Wholesaler.Wholesaler w = await ws.findWholesalerByIdAsync(_id);
                ServiceReference_Country.Country[] lst_countries = await country.getAllCountryAsync();
                ServiceReference_PurchaseOrder.PurchaseOrder[] orders = await po.findPurchaseOrderByWSIdAsync(_id);
                ServiceReference_Wholesaler.Wholesaler[] lst_ws = await ws.getAllWholesalerAsync();

                WholesalerModel ws_model = new WholesalerModel
                {
                    salerbyId = w,
                    WholesalerId = w.WholesalerId,
                    Fullname = w.Fullname,
                    Email = w.Email,
                    Phone = w.Phone,
                    AddressWS = w.AddressWS,
                    CountryId = w.CountryId,
                    Website = w.Website,
                    StatusWS = w.StatusWS,
                    coutries = lst_countries,
                    pOdersbyWSId = orders,
                    wholesalers = lst_ws
                };
                return View(ws_model);
            }

            return View();
        }
        public async Task<IActionResult> saveAccount(WholesalerModel wholesaler)
        {
            var w = await ws.findWholesalerByIdAsync(wholesaler.WholesalerId);
            w.WholesalerId = wholesaler.WholesalerId;
            w.Fullname = wholesaler.Fullname;
            w.AddressWS = wholesaler.AddressWS;
            w.Website = wholesaler.Website;
            w.CountryId = wholesaler.CountryId;
            w.Phone = wholesaler.Phone;

            bool res = await ws.updateWholesalerAsync(w);
            string msg = res == true ? "success" : "error";
            return RedirectToAction("Account", new { msg = msg });
        }

        public async Task<bool> SaveInquiry(int itemId, int quantity, string comment)
        {
            ServiceReference_Item.Item item = await itm.findItembyIdAsync(itemId);
            ServiceReference_PurchaseOrder.PurchaseOrderDetail pdt = new ServiceReference_PurchaseOrder.PurchaseOrderDetail();
            ServiceReference_PurchaseOrder.PurchaseOrder p = new ServiceReference_PurchaseOrder.PurchaseOrder();
            bool isSuccess = false;
            try
            {

                p.PurchaseOrderId = await po.getPurchaseOrderIdAsync(_id);
                p.PurchaseOrderDate = DateTime.Now;
                p.InquiriedData = DateTime.Now;
                p.ReceivedDate = DateTime.Now;
                p.WholesalerId = _id;
                p.SupplierId = item.SupplierId;
                p.Comment = comment;
                p.StatusPurchase = "Being prepared";


                pdt.PurchaseOrderId = await po.getPurchaseOrderIdAsync(_id);
                pdt.ItemId = item.ItemId;
                pdt.Price = 0;
                pdt.Quantity = quantity;
                pdt.Discount = 0;
                pdt.Tax = 0;
                pdt.LineTotal = 0;
                pdt.UnitId = item.UnitId;
                bool res = await po.tranPurcharseOrderAsync(p, pdt);
                if (res) isSuccess = true;
            }
            catch (Exception ex)
            {
                isSuccess = false;
            }
            return isSuccess;
        }

        public async Task<int> NumMessage()
        {
            var model = (await po.getAllPurchaseOrderAsync()).Where(d => d.StatusInquiry == "new" && d.ReplyId != null && d.WholesalerId == _id);
            return model.Count();
        }

        public async Task<IActionResult> WS_Invoice(string searchString, string podId)
        {
            ViewData["CurrentFilter"] = searchString;

            if (!String.IsNullOrEmpty(searchString))
            {
                return RedirectToAction("Category", "Home", new { searchString });
            }
            if (!String.IsNullOrEmpty(_id))
            {
                ServiceReference_Wholesaler.Wholesaler wsbyId = await ws.findWholesalerByIdAsync(_id);
                ServiceReference_Country.Country[] lst_countries = await country.getAllCountryAsync();
                ServiceReference_PurchaseOrder.PurchaseOrder[] orders = await po.findPurchaseOrderByWSIdAsync(_id);
                ServiceReference_PurchaseOrderDetail.PurchaseOrderDetail[] orderdetails = null;
                ServiceReference_Invoice.Invoice[] invoices = null;
                if (!String.IsNullOrEmpty(podId))
                {
                    orderdetails = await pod.findPurchaseOrderDetailbypIdAsync(podId);
                    invoices = await inc.findInvoicebyPurchaseIdAsync(podId);

                }

                WholesalerModel ws_model = new WholesalerModel
                {
                    salerbyId = wsbyId,
                    coutries = lst_countries,
                    pOdersbyWSId = orders,
                    pOderDetail = orderdetails,
                    getInvoicebyWSId = invoices
                };
                return View(ws_model);
            }

            return View();
        }

        public async Task<IActionResult> ContactSupplier(int itemId)
        {
            ApplicationUser user = await _userManager.GetUserAsync(HttpContext.User);
            if (user != null)
            {
                _id = await getWholesalerId(user.Email);
                ServiceReference_Item.Item item = await itm.findItembyIdAsync(itemId);
                ViewBag.Units = await unit.getAllUnitAsync();
                return View(item);
            }
            else
            {
                return RedirectToAction("Login", "Account", new { returnUrl = "/Wholesaler/ContactSupplier?itemId=" + itemId + "" });
            }
        }

        [HttpGet]
        public async Task<IActionResult> Checkout1(string id)
        {
            //ApplicationUser user = await _userManager.GetUserAsync(HttpContext.User);
            //_id = await getWholesalerId(user.Email);
            var model = await iv.findInvoicebyIdAsync(id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Checkout1(ServiceReference_Invoice.Invoice invoice)
        {
            var old_invoice = await iv.findInvoicebyIdAsync(invoice.InvoiceId);
            old_invoice.ShipAddress = invoice.ShipAddress;
            old_invoice.Note = invoice.Note;
            await iv.updateInvoiceAsync(old_invoice);
            return RedirectToAction("checkout2", new { id = old_invoice.InvoiceId });
        }

        [HttpGet]
        public async Task<IActionResult> Checkout2(string id)
        {
            var model = await iv.findInvoicebyIdAsync(id);
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Checkout2(ServiceReference_Invoice.Invoice invoice)
        {
            var old_invoice = await iv.findInvoicebyIdAsync(invoice.InvoiceId);
            if (invoice.ShipmentMethod == "Airplane Express")
            {
                old_invoice.ShipFee = old_invoice.Total * 15 / 100;
                old_invoice.Total = old_invoice.Total + (old_invoice.Total * 15 / 100);
            }

            if (invoice.ShipmentMethod == "Sea Express")
            {
                old_invoice.ShipFee = old_invoice.Total * 10 / 100;
                old_invoice.Total = old_invoice.Total + (old_invoice.Total * 10 / 100);
            }

            old_invoice.ShipmentMethod = invoice.ShipmentMethod;
            await iv.updateInvoiceAsync(old_invoice);
            return RedirectToAction("checkout3", new { id = old_invoice.InvoiceId });
        }

        [HttpGet]
        public async Task<IActionResult> Checkout3(string id)
        {
            var model = await iv.findInvoicebyIdAsync(id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Checkout3(ServiceReference_Invoice.Invoice invoice)
        {
            var old_invoice = await iv.findInvoicebyIdAsync(invoice.InvoiceId);
            old_invoice.PaymentMethodId = invoice.PaymentMethodId;
            await iv.updateInvoiceAsync(old_invoice);
            return RedirectToAction("checkout4", new { id = old_invoice.InvoiceId });
        }

        [HttpGet]
        public async Task<IActionResult> Checkout4(string id)
        {
            //var model = await iv.findInvoicebyIdAsync(id);
            var model = await iv.findInvoicebyIdAsync(id);
            return View(model);
        }

        [HttpPost]
        public async Task<bool> Checkout(string paymentId, string invoiceId)
        {
            var invoice = await iv.findInvoicebyIdAsync(invoiceId);
            invoice.PaypalId = paymentId;
            invoice.Status = "paid";
            bool res = await iv.updateInvoiceAsync(invoice);
            return true;
        }

        // save feedback

        public async Task<JsonResult> SaveFeedback(int itemId, string message)
        {
            ApplicationUser user = await _userManager.GetUserAsync(HttpContext.User);
            _id = await getWholesalerId(user.Email);
            ServiceReference_Item.Item item = await itm.findItembyIdAsync(itemId);
            Feedback feedback = new Feedback();
            feedback.ItemId = item.ItemId;
            feedback.SubjectFB = " ";
            feedback.WholesalerId = _id;
            feedback.SupplierId = item.SupplierId;
            feedback.Message = message;
            feedback.ReceivedDate = DateTime.Now;
            bool res = await fb.createFeedbackAsync(feedback);
            var lst = await fb.findFeedbackbyItemIdAsync(itemId);
            return Json(lst);
        }
    }
}
