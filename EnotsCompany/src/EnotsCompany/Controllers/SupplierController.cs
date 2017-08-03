using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServiceReference_Item;
using ServiceReference_Category;
using ServiceReference_Supplier;
using ServiceReference_Unit;
using EnotsCompany.Models;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using ServiceReference_Feedback;
using ServiceReference_Invoice;
using System.Linq;
using System;
using System.IO;
using ServiceReference_PurchaseOrder;
using ServiceReference_PurchaseOrderDetail;
using EnotsCompany.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using EnotsCompany.Models.ManageViewModels;
using Microsoft.Extensions.Logging;

//For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace EnotsCompany.Controllers
{
    [Authorize(Roles = "admin,supplier")]
    public class SupplierController : Controller
    {

        ApplicationRoleManager _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger _logger;
        static string _id = string.Empty;

        ServiceReference_Country.CountryServiceClient co = new ServiceReference_Country.CountryServiceClient();
        ItemServiceClient item = new ItemServiceClient();
        CategoryServiceClient cc = new CategoryServiceClient();
        static SupplierServiceClient s = new SupplierServiceClient();
        UnitServiceClient u = new UnitServiceClient();
        FeedbackServiceClient fb = new FeedbackServiceClient();
        InvoiceServiceClient iv = new InvoiceServiceClient();
        static PurchaseOrderServiceClient po = new PurchaseOrderServiceClient();
        PurchaseOrderDetailsServiceClient pdt = new PurchaseOrderDetailsServiceClient();
        ServiceReference_Wholesaler.WholesalerServiceClient ws = new ServiceReference_Wholesaler.WholesalerServiceClient();
        IHostingEnvironment _host;
        static string flag = "";
        static string message = "";
        
        public SupplierController(IHostingEnvironment host,
            ApplicationRoleManager roleManager, 
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILoggerFactory loggerFactory)
        {
            _host = host;
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = loggerFactory.CreateLogger<ManageController>();
        }

        //Item
        public async Task<IActionResult> Index()
        {
            ApplicationUser user = await _userManager.GetUserAsync(HttpContext.User);
            if (user != null)
            {
                _id = await getSupplierIdByEmail(user.Email);
                List<ServiceReference_Invoice.Invoice> invoices = null;
                List<ServiceReference_Invoice.Invoice> last_invoices = null;
                List<ServiceReference_PurchaseOrder.PurchaseOrder> lst_inquiries = null;
                float saletotal = 0;
                float profitmonth = 0;
                float total = 0;
                int faq = 0;
                try
                {
                    invoices = (await iv.getAllInvoiceBySupplierIdAsync(_id)).OrderByDescending(x=>x.InvoiceDate).ToList();
                    last_invoices = invoices.Where(d => d.InvoiceDate.ToString("dd-MM-yyyy") == DateTime.Now.ToString("dd-MM-yyyy")).OrderByDescending(x=>x.InvoiceDate).ToList();
                    saletotal = invoices.Where(d => d.InvoiceDate.ToString("dd-MM-yyyy") == DateTime.Now.ToString("dd-MM-yyyy")).Count();
                    profitmonth = (float)invoices.Where(d => d.InvoiceDate.Month == DateTime.Now.Month && d.InvoiceDate.Year == DateTime.Now.Year && d.Status == "paid").Sum(t => t.Total);
                    total = (float)invoices.Where(d => d.InvoiceDate.ToString("dd-MM-yyyy") == DateTime.Now.ToString("dd-MM-yyyy") && d.Status == "paid").Sum(t => t.Total);
                    //faq = (await item.getAllItemAsync()).Where(f => f.FAQ != null && f.SupplierId == _id).Count();
                }
                catch (Exception)
                {
                    invoices = null;
                    last_invoices = null;
                    saletotal = 0;
                    profitmonth = 0;
                    total = 0;
                    faq = 0;
                    lst_inquiries = null;
                }

                lst_inquiries = (await po.getAllPurchaseOrderAsync())
                        .OrderByDescending(p => p.InquiriedData)
                        .Where(p => p.SupplierId == _id)
                        .ToList();

                InvoiceModel model = new InvoiceModel()
                {
                    Saletotal = saletotal,
                    Total = total,
                    ProfitMonth = profitmonth,
                    Inquiries = lst_inquiries,
                    Invoices = invoices,
                    LastInvoices = last_invoices,
                    FAQ = faq
                };

                return View(model);
            }
            else return RedirectToAction("Login", "Account");
           
        }

        public async Task<string> getSupplierIdByEmail(string email)
        {
            var supplier = (await s.getAllSupplierAsync()).Where(w => w.Email == email).SingleOrDefault();
            return supplier.SupplierId;
        }
        public async Task<IActionResult> ItemIndex(string op = "enable")
        {
            var items = (await item.getAllItemAsync()).Where(s=>s.SupplierId==_id).ToList();
            var lst_disable = items.Where(i => i.StatusItem.Trim().ToLower() == "disable").ToList();
            var lst_enable = items.Where(i => i.StatusItem.Trim().ToLower() == "enable").ToList();
            //if (op == null) op = "enable";
            return View(op.Trim().ToLower() == "enable" ? lst_enable : lst_disable);
        }
        public async Task<IActionResult> ItemCreate()
        {
            ServiceReference_Item.Item[] lst_parentitems = await item.getAllItemAsync();
            ServiceReference_Category.Category[] lst_categories = await cc.getAllCategoryAsync();
            ServiceReference_Supplier.Supplier[] lst_suppliers = await s.getAllSupplierAsync();
            ServiceReference_Unit.Unit[] lst_unit = await u.getAllUnitAsync();
            ItemModel im = new ItemModel()
            {
                parentitems = lst_parentitems,
                categories = lst_categories,
                suppliers = lst_suppliers,
                units = lst_unit
            };
            ViewBag.flag = flag;
            ViewBag.message = message;
            flag = "";
            message = "";
            return View(im);
        }
        [HttpPost]
        public async Task<IActionResult> ItemSave(ServiceReference_Item.Item i, IList<IFormFile> files)
        {
            string mainimage = "";
            string moreimage = "";
            int count = 0;
            string path = _host.WebRootPath + @"/images/";
            try
            {
                if (files.Count == 0)
                {
                    mainimage = "noimage.jpg";
                }
                else if (files.Count == 1)
                {
                    foreach (IFormFile f in files)
                    {
                        mainimage = f.FileName;
                        System.IO.FileStream fs = System.IO.File.Create(path + f.FileName);
                        f.CopyTo(fs);
                        fs.Flush();
                        fs.Dispose();
                        count++;
                    }
                }
                else
                {
                    foreach (IFormFile f in files)
                    {
                        if (count == 0)
                        {
                            mainimage = f.FileName;
                        }
                        else
                        {
                            moreimage += f.FileName + ",";
                        }
                        FileStream fs = System.IO.File.Create(path + f.FileName);
                        f.CopyTo(fs);
                        fs.Flush();
                        fs.Dispose();
                        count++;
                    }
                }
                i.SupplierId = _id;
                i.ImageItem = mainimage;
                i.MoreImage = moreimage;
                bool _boolean = await item.createItemAsync(i);
                if (_boolean)
                {
                    flag = "success";
                    message = "Add new item success";
                }
            }
            catch (System.Exception)
            {
                flag = "error";
                message = "Add new item unsuccess";
            }
            return RedirectToAction("ItemCreate");
        }

        public async Task<IActionResult> ItemEdit(int id)
        {
            ServiceReference_Item.Item i = await item.findItembyIdAsync(id);
            ServiceReference_Category.Category[] lst_categories = await cc.getAllCategoryAsync();
            ServiceReference_Supplier.Supplier[] lst_suppliers = await s.getAllSupplierAsync();
            ServiceReference_Item.Item[] lst_parentitems = await item.getAllItemAsync();
            ServiceReference_Unit.Unit[] lst_unit = await u.getAllUnitAsync();
            ItemModel im = new ItemModel()
            {
                parentitems = lst_parentitems,
                categories = lst_categories,
                suppliers = lst_suppliers,
                units = lst_unit,
                ItemId = i.ItemId,
                ItemName = i.ItemName,
                ImageItem = i.ImageItem,
                MoreImage = i.MoreImage,
                ImageUpdate = i.MoreImage,
                DescriptionItem = i.DescriptionItem,
                MinQuantity = i.MinQuantity,
                Price = i.Price,
                Discount = i.Discount,
                CategoryId = i.CategoryId,
                SupplierId = i.SupplierId,
                ParentItem = i.ParentItem,
                AddedDate = i.AddedDate,
                Warranty = i.Warranty,
                UnitId = i.UnitId,
                Note = i.Note,
                ShippingFee = i.ShippingFee,
                FAQ = i.FAQ,
                StatusItem = i.StatusItem
            };
            ViewBag.flag = flag;
            ViewBag.message = message;
            flag = "";
            message = "";
            return View(im);
        }

        [HttpPost]
        public async Task<IActionResult> ItemUpdate(ItemModel im, IList<IFormFile> files)
        {
            ServiceReference_Item.Item i = null;
            string mainimage = "";
            string moreimage = "";
            int count = 0;
            string path = _host.WebRootPath + @"/images/";
            string[] imgOrigin = im.MoreImage.TrimEnd(',').Split(',');
            string[] imageUpdate = im.ImageUpdate.TrimEnd(',').Split(',');
            IEnumerable<string> imgs = imgOrigin.Except(imageUpdate);
            try
            {
                if (files.Count == 0)
                {
                    mainimage = imageUpdate[0];
                    moreimage = im.ImageUpdate;
                }
                else if (files.Count == 1)
                {
                    foreach (IFormFile f in files)
                    {
                        im.ImageUpdate += f.FileName + ",";
                        System.IO.FileStream fs = System.IO.File.Create(path + f.FileName);
                        f.CopyTo(fs);
                        fs.Flush();
                        fs.Dispose();
                    }
                    moreimage = im.ImageUpdate;
                    mainimage = imageUpdate[0];
                }
                else
                {
                    foreach (IFormFile f in files)
                    {
                        im.ImageUpdate += f.FileName + ",";
                        System.IO.FileStream fs = System.IO.File.Create(path + f.FileName);
                        f.CopyTo(fs);
                        fs.Flush();
                        fs.Dispose();
                        count++;
                    }
                    moreimage = im.ImageUpdate;
                    mainimage = imageUpdate[0];
                }

                // xóa file
                foreach (var img in imgs)
                {
                    System.IO.File.Delete(path + img);
                }
                i = await item.findItembyIdAsync(im.ItemId);
                i.ItemId = im.ItemId;
                i.ItemName = im.ItemName;
                i.ImageItem = mainimage;
                i.MoreImage = moreimage;
                i.DescriptionItem = im.DescriptionItem;
                i.MinQuantity = im.MinQuantity;
                i.Price = im.Price;
                i.Discount = im.Discount;
                i.CategoryId = im.CategoryId;
                i.SupplierId = _id;
                i.ParentItem = im.ParentItem;
                i.AddedDate = im.AddedDate;
                i.Warranty = im.Warranty;
                i.UnitId = im.UnitId;
                i.Note = im.Note;
                i.ShippingFee = im.ShippingFee;
                i.FAQ = im.FAQ;
                i.StatusItem = im.StatusItem;
                bool _boolean = await item.updateItemAsync(i);
                if (_boolean)
                {
                    flag = "success";
                    message = "Update Item success";
                }
            }
            catch (System.Exception)
            {
                flag = "error";
                message = "Update Item unsuccess";
            }
            return RedirectToAction("ItemEdit/" + im.ItemId);
        }
        public async Task<IActionResult> ItemDelete(int id)
        {
            bool _boolean = await item.deleteItemAsync(id);
            return RedirectToAction("ItemIndex");
        }

        // Feedback
        public async Task<IActionResult> FeedbackIndex()
        {
            var model = await fb.getAllFeedbackAsync();
            return View(model);
        }

        public async Task<IActionResult> FeedbackDetail()
        {
            var model = await fb.getAllFeedbackAsync();
            return View(model);
        }


        //Invoice

        public async Task<IActionResult> InvoiceIndex()
        {
            var invoices = await iv.getAllInvoiceAsync();
            return View(invoices);
        }

        public async Task<IActionResult> InvoiceEdit(string id)
        {
            ServiceReference_Invoice.Invoice invoice = await iv.findInvoicebyIdAsync(id);
            return View(invoice);
        }

        //Purchase order

        public async Task<bool> ReplyInquiry(string purchaseId, DateTime recievedate, float price, float discount, float tax, string comment)
        {
            ServiceReference_PurchaseOrder.PurchaseOrder p = await po.findPurchaseOrderByIdAsync(purchaseId);
            ServiceReference_PurchaseOrder.PurchaseOrderDetail pd = (await po.findPurchaseOrderDetailbypIdAsync(purchaseId)).SingleOrDefault();
            ServiceReference_PurchaseOrder.PurchaseOrder pnew = new ServiceReference_PurchaseOrder.PurchaseOrder();
            bool isSuccess = false;
            try
            {
                pnew.PurchaseOrderId = await po.getPurchaseOrderIdAsync(p.WholesalerId);
                pnew.PurchaseOrderDate = DateTime.Now;
                pnew.InquiriedData = p.InquiriedData;
                pnew.ReceivedDate = recievedate;
                pnew.SupplierId = p.SupplierId;
                pnew.WholesalerId = p.WholesalerId;
                pnew.Comment = comment;
                pnew.ReplyId = p.PurchaseOrderId;
                pnew.StatusPurchase = "quoted";
                pnew.StatusInquiry = "new";

                pd.Price = price;
                pd.Discount = discount;
                pd.Tax = tax;
                pd.LineTotal = (price + (price * tax / 100) - (price * discount / 100)) * pd.Quantity;

                bool res = await po.tranUpdatePurcharseOrderAsync(pnew, pd);
                if (res) isSuccess = true;
            }
            catch (Exception ex)
            {
                isSuccess = false;
            }
            return isSuccess;
        }

        public static async Task<List<ServiceReference_PurchaseOrder.PurchaseOrder>> getListReply(string purchaseId)
        {
            var lst_reply = (await po.getAllPurchaseOrderAsync()).Where(x => x.ReplyId == purchaseId && x.SupplierId == _id).ToList();
            return lst_reply;
        }
        public static async Task<ServiceReference_Supplier.Supplier> getInfo()
        {
            var supplier = await s.findSupplierByIdAsync(_id);
            return supplier;
        }
        
        // Edit profile 

        public async Task<IActionResult> SupplierEdit()
        {
            try
            {
                ApplicationUser user = await _userManager.GetUserAsync(HttpContext.User);
                _id = await getSupplierIdByEmail(user.Email);
                ServiceReference_Supplier.Supplier su = await s.findSupplierByIdAsync(_id);
                ServiceReference_Category.Category[] lst_categories = await cc.getAllCategoryAsync();
                ServiceReference_Country.Country[] lst_countries = await co.getAllCountryAsync();
                SupplierModel sm = new SupplierModel()
                {
                    categories = lst_categories,
                    countries = lst_countries,
                    SupplierId = su.SupplierId,
                    Avatar = su.Avatar,
                    Name = su.Name,
                    Title = su.Title,
                    CompanyName = su.CompanyName,
                    Email = su.Email,
                    Phone = su.Phone,
                    Address = su.Address,
                    Province = su.Province,
                    MainProduct = su.MainProduct,
                    CategoryId = (int)su.CategoryId,
                    Website = su.Website,
                    Zipcode = su.Zipcode,
                    CountryId = (int)su.CountryId,
                    Status = su.Status,
                    BussinessType = su.BussinessType,
                    YearEstablished = su.YearEstablished,
                    TotalEmployees = su.TotalEmployees
                };
                ViewBag.flag = flag;
                ViewBag.message = message;
                flag = "";
                message = "";
                return View(sm);
            }
            catch (Exception)
            {
                return RedirectToAction("SupplierEdit");
            }
        }

        public async Task<IActionResult> SupplierUpdate(SupplierModel sm)
        {
            ServiceReference_Supplier.Supplier su = await s.findSupplierByIdAsync(sm.SupplierId);
            su.SupplierId = sm.SupplierId;
            //su.Avatar = sm.Avatar;
            su.Name = sm.Name;
            su.Title = sm.Title;
            su.CompanyName = sm.CompanyName;
            su.Email = sm.Email;
            su.Phone = sm.Phone;
            su.Address = sm.Address;
            su.Province = sm.Province;
            su.MainProduct = sm.MainProduct;
            su.CategoryId = sm.CategoryId;
            su.Website = sm.Website;
            su.Zipcode = sm.Zipcode;
            su.Country = sm.Country;
            su.CountryId = sm.CountryId;
            su.Status = sm.Status;
            su.BussinessType = sm.BussinessType;
            su.YearEstablished = sm.YearEstablished;
            su.TotalEmployees = sm.TotalEmployees;
            bool _boolean = await s.updateSupplierAsync(su);
            if (_boolean)
            {
                flag = "success";
                message = "Update profile success.";
                return RedirectToAction("SupplierEdit");
            }
            else
            {
                flag = "success";
                message = "Update profile success.";
                return RedirectToAction("SupplierEdit");
            }
        }

        // Change Password

        // GET: /Manage/ChangePassword
        [HttpGet]
        public IActionResult ChangePassword()
        {
            ViewBag.active = "changepass";
            return View();
        }

        //
        // POST: /Manage/ChangePassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await _userManager.GetUserAsync(HttpContext.User);
            ViewBag.active = "changepass";
            if (user != null)
            {
                var result = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    _logger.LogInformation(3, "User changed their password successfully.");
                    ViewBag.msg = "success";
                    return View();
                }
                AddErrors(result);
                ViewBag.msg = "error";
                return View(model);
            }
            return RedirectToAction("ChangePassword");
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        //upload image


        [HttpPost]
        public async Task<string> upload()
        {
            ServiceReference_Supplier.Supplier supplier = await s.findSupplierByIdAsync(_id);
            string path = _host.WebRootPath + @"\images\";
            string filename = "";
            // Checking no of files injected in Request object  
            if (Request.Form.Files.Count > 0)
            {
                try
                {
                    foreach (IFormFile f in Request.Form.Files)
                    {

                        filename = f.FileName;
                        if (System.IO.File.Exists(path + filename))
                            System.IO.File.Delete(path + filename);
                        System.IO.FileStream fs = System.IO.File.Create(path + filename);

                        f.CopyTo(fs);
                        fs.Flush();
                        fs.Dispose();
                    }
                    // Returns message that successfully uploaded  
                    supplier.Avatar = filename;
                    bool res = await s.updateSupplierAsync(supplier);
                    return filename;
                }
                catch (Exception ex)
                {
                    return "error";
                }
            }
            else
            {
                return "No files selected.";
            }
        }

    }
}
