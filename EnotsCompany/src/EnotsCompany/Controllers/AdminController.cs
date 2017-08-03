using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServiceReference_Employee;
using ServiceReference_Category;
using ServiceReference_Article;
using ServiceReference_Country;
using ServiceReference_Unit;
using ServiceReference_Wholesaler;
using ServiceReference_Supplier;
using ServiceReference_Slider;
using ServiceReference_ContactPerson;
using EnotsCompany.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using ServiceReference_PaymentMethod;
using Microsoft.AspNetCore.Authorization;
using EnotsCompany.Data;
using Microsoft.AspNetCore.Identity;
using EnotsCompany.Models.ManageViewModels;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

//For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace EnotsCompany.Controllers
{
    [Authorize(Roles ="admin")]  
    public class AdminController : Controller
    {

        ApplicationRoleManager _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger _logger;

        EmployeeServiceClient es = new EmployeeServiceClient();
        CategoryServiceClient cs = new CategoryServiceClient();
        ArticleServiceClient arls = new ArticleServiceClient();
        CountryServiceClient co = new CountryServiceClient();
        SliderServiceClient slide = new SliderServiceClient();
        PaymentMethodServiceClient pay = new PaymentMethodServiceClient();
        SupplierServiceClient sup = new SupplierServiceClient();
        WholesalerServiceClient whole = new WholesalerServiceClient();
        UnitServiceClient unit = new UnitServiceClient();
        ContactPersonServiceClient cp = new ContactPersonServiceClient();
        WholesalerServiceClient ws = new WholesalerServiceClient();
        ServiceReference_Invoice.InvoiceServiceClient iv = new ServiceReference_Invoice.InvoiceServiceClient();

        static string flag = "";
        static string message = "";

        IHostingEnvironment _host;
        public AdminController(IHostingEnvironment host, 
            UserManager<ApplicationUser> userManager, 
            SignInManager<ApplicationUser> signInManager, 
            ApplicationRoleManager roleManager,
            ILoggerFactory loggerFactory)
        {
            _host = host;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _logger = loggerFactory.CreateLogger<ManageController>();
        }

        public async Task<IActionResult> Index()
        {
            ServiceReference_Employee.Employee[] lstEMP = await es.getAllEmployeeAsync();
            ServiceReference_Supplier.Supplier[] lstSUP = await sup.getAllSupplierAsync();
            ServiceReference_Wholesaler.Wholesaler[] lstWS = await ws.getAllWholesalerAsync();
            ServiceReference_Invoice.Invoice[] lstInvoice = await iv.getAllInvoiceAsync ();
            ServiceReference_Employee.Employee empId = await es.findEmployeebyIdAsync(1);
            ServiceReference_Article.Article[] lstArtcle = await arls.getAllArticleAsync();

            AdminModel adModel = new AdminModel
            {
                Employees = lstEMP,
                Suppliers=lstSUP,
                Wholesalers=lstWS,
                Invoices=lstInvoice,
                empById=empId,
                Articles=lstArtcle
            };
            return View(adModel);
        }

       

        public async Task<IActionResult> EmployeeIndex()
        {
            var model = await es.getAllEmployeeAsync();
            return View(model);
        }
        public async Task<IActionResult> EmployeeEdit(int id)
        {
            ServiceReference_Employee.Employee e = await es.findEmployeebyIdAsync(id);
            ViewBag.flag = flag;
            ViewBag.message = message;
            flag = "";
            message = "";
            return View(e);
        }

        public async Task<IActionResult> EmployeeSave(ServiceReference_Employee.Employee e)
        {
            bool _boolean = await es.createEmployeeAsync(e);
            if (_boolean)
            {
                flag = "success";
                message = "Add new employee success";
            }
            else
            {
                flag = "error";
                message = "Add new employee fail.";
            }
            return RedirectToAction("EmployeeCreate");
        }
        public IActionResult EmployeeCreate()
        {
            ViewBag.flag = flag;
            ViewBag.message = message;
            flag = "";
            message = "";
            return View();
        }
        public async Task<IActionResult> EmployeeUpdate(ServiceReference_Employee.Employee e)
        {
            bool _boolean = await es.updateEmployeeAsync(e);
            if (_boolean)
            {
                flag = "success";
                message = "Add new employee success";
            }
            else
            {
                flag = "error";
                message = "Add new employee fail.";
            }
            return RedirectToAction("EmployeeEdit/" + e.EmployeeId);
        }
        public async Task<IActionResult> EmployeeDelete(int id)
        {
            bool _boolean = await es.deleteEmployeeAsync(id);
            return RedirectToAction("EmployeeIndex");
        }

        public async Task<IActionResult> CategoryIndex()
        {
            var model = await cs.getAllCategoryAsync();
            return View(model);
        }
        public async Task<IActionResult> CategoryEdit(int id)
        {
            ServiceReference_Category.Category e = await cs.findCategorybyIdAsync(id);
            ServiceReference_Category.Category[] lst_categories = await cs.getAllCategoryAsync();
            CategoryModel cm = new CategoryModel()
            {
                categories = lst_categories,
                CategoryId = e.CategoryId,
                CategoryName = e.CategoryName,
                ImageCate = e.ImageCate,
                ParentId = e.ParentId,
                StatusCate = e.StatusCate
            };
            ViewBag.flag = flag;
            ViewBag.message = message;
            flag = "";
            message = "";
            return View(cm);
        }

        [HttpPost]
        public IActionResult uploadsave(IList<IFormFile> files)
        {
            string path = _host.WebRootPath + @"/images/";
            foreach (IFormFile f in files)
            {
                string filename = f.FileName;

                System.IO.FileStream fs = System.IO.File.Create(path + filename);
                f.CopyTo(fs);
                fs.Flush();
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> CategorySave(CategoryModel cm, IList<IFormFile> files)
        {
            string path = _host.WebRootPath + @"/images/";
            string filename = "";
            ServiceReference_Category.Category c = new ServiceReference_Category.Category();
            c.CategoryId = cm.CategoryId;
            c.CategoryName = cm.CategoryName;
            c.ImageCate = cm.ImageCate;
            c.ParentId = cm.ParentId;
            c.StatusCate = cm.StatusCate;
            if (files.Count > 0)
            {
                foreach (IFormFile f in files)
                {
                    filename = f.FileName;
                    FileStream fs = System.IO.File.Create(path + filename);
                    f.CopyTo(fs);
                    fs.Flush();
                    fs.Dispose();
                }
            }
            else
            {
                filename = "noimage.jpg";
            }
            c.ImageCate = filename;
            bool _boolean = await cs.createCategoryAsync(c);
            if (_boolean)
            {
                flag = "success";
                message = "Add new category success";
            }
            else
            {
                flag = "error";
                message = "Add new category unsuccess.";
            }
            return RedirectToAction("CategoryCreate");
        }
        public async Task<IActionResult> CategoryCreate()
        {
            ServiceReference_Category.Category[] lst_categories = await cs.getAllCategoryAsync();
            CategoryModel cm = new CategoryModel()
            {
                categories = lst_categories
            };
            ViewBag.flag = flag;
            ViewBag.message = message;
            flag = "";
            message = "";
            return View(cm);
        }
        [HttpPost]
        public async Task<IActionResult> CategoryUpdate(CategoryModel cm, IList<IFormFile> files)
        {
            bool _boolean = false;
            ServiceReference_Category.Category c = await cs.findCategorybyIdAsync(cm.CategoryId);
            c.CategoryId = cm.CategoryId;
            c.CategoryName = cm.CategoryName;
            c.ImageCate = cm.ImageCate;
            c.ParentId = cm.ParentId;
            c.StatusCate = cm.StatusCate;
            if (files.Count > 0)
            {
                string path = _host.WebRootPath + @"/images/";
                string filename = "";
                foreach (IFormFile f in files)
                {
                    filename = f.FileName;

                    FileStream fs = System.IO.File.Create(path + filename);
                    f.CopyTo(fs);
                    fs.Flush();
                }
                c.ImageCate = filename;
                _boolean = await cs.updateCategoryAsync(c);
            }
            else
            {
                _boolean = await cs.updateCategoryAsync(c);
            }
            if (_boolean)
            {
                flag = "success";
                message = "Update category success";
            }
            else
            {
                flag = "error";
                message = "Update category unsuccess.";
            }
            return RedirectToAction("CategoryEdit/" + c.CategoryId);
        }
        public async Task<IActionResult> CategoryDelete(int id)
        {
            bool _boolean = await cs.deleteCategoryAsync(id);
            return RedirectToAction("CategoryIndex");
        }
        public async Task<IActionResult> ArticleIndex()
        {
            var model = await arls.getAllArticleAsync();
            return View(model);
        }
        public async Task<IActionResult> ArticleEdit(int id)
        {
            Article e = await arls.findArticlebyIDAsync(id);
            ViewBag.flag = flag;
            ViewBag.message = message;
            flag = "";
            message = "";
            return View(e);
        }

        [HttpPost]
        public async Task<IActionResult> ArticleSave(Article a, IFormFile file)
        {
            bool _boolean = false;
            if (file != null)
            {
                string path = _host.WebRootPath + @"/images/";
                FileStream fs = System.IO.File.Create(path + file.FileName);
                file.CopyTo(fs);
                fs.Flush();
                a.ImageArticle = file.FileName;
                _boolean = await arls.createArticleAsync(a);
            }
            else
            {
                _boolean = await arls.createArticleAsync(a);
            }
            if (_boolean)
            {
                flag = "success";
                message = "Add new article success";
            }
            else
            {
                flag = "error";
                message = "Add new article unsuccess.";
            }
            return RedirectToAction("ArticleCreate");
        }
        public IActionResult ArticleCreate()
        {
            ViewBag.flag = flag;
            ViewBag.message = message;
            flag = "";
            message = "";
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ArticleUpdate(Article a, IFormFile file)
        {
            bool _boolean = false;
            if (file != null)
            {
                string path = _host.WebRootPath + @"/images/";
                FileStream fs = System.IO.File.Create(path + file.FileName);
                file.CopyTo(fs);
                fs.Flush();
                a.ImageArticle = file.FileName;
                _boolean = await arls.updateArticleAsync(a);
            }
            else
            {
                _boolean = await arls.updateArticleAsync(a);
            }
            if (_boolean)
            {
                flag = "success";
                message = "Update article success";
            }
            else
            {
                flag = "error";
                message = "Update article unsuccess.";
            }

            return RedirectToAction("ArticleEdit/" + a.ArticleId);
        }
        public async Task<IActionResult> ArticleDelete(int id)
        {
            bool _boolean = await arls.deleteArticleAsync(id);
            return RedirectToAction("ArticleIndex");
        }
        public async Task<IActionResult> UnitIndex()
        {
            var model = await unit.getAllUnitAsync();
            return View(model);
        }
        public async Task<IActionResult> UnitEdit(int id)
        {
            ServiceReference_Unit.Unit e = await unit.findUnitByIdAsync(id);
            ViewBag.flag = flag;
            ViewBag.message = message;
            flag = "";
            message = "";
            return View(e);
        }

        public async Task<IActionResult> UnitSave(ServiceReference_Unit.Unit e)
        {
            bool _boolean = await unit.createUnitAsync(e);
            if (_boolean)
            {
                flag = "success";
                message = "Add new unit success";
            }
            else
            {
                flag = "error";
                message = "Add new unit unsuccess.";
            }
            return RedirectToAction("UnitCreate");
        }
        public IActionResult UnitCreate()
        {
            ViewBag.flag = flag;
            ViewBag.message = message;
            flag = "";
            message = "";
            return View();
        }
        public async Task<IActionResult> UnitUpdate(ServiceReference_Unit.Unit e)
        {
            bool _boolean = await unit.updateUnitAsync(e);
            if (_boolean)
            {
                flag = "success";
                message = "Update unit success";
            }
            else
            {
                flag = "error";
                message = "Update unit unsuccess.";
            }
            return RedirectToAction("UnitEdit/" + e.UnitId);
        }
        public async Task<IActionResult> UnitDelete(int id)
        {
            bool _boolean = await unit.deleteUnitAsync(id);
            return RedirectToAction("UnitIndex");
        }
        public async Task<IActionResult> PaymentIndex()
        {
            var model = await pay.getAllPaymentMethodAsync();
            return View(model);
        }

        public IActionResult PaymentCreate()
        {
            ViewBag.flag = flag;
            ViewBag.message = message;
            flag = "";
            message = "";
            return View();
        }

        public async Task<IActionResult> PaymentSave(ServiceReference_PaymentMethod.PaymentMethod p)
        {
            bool _boolean = await pay.createPaymentMethodAsync(p);
            if (_boolean)
            {
                flag = "success";
                message = "Add new payment method success";
            }
            else
            {
                flag = "error";
                message = "Add new payment method unsuccess.";
            }
            return RedirectToAction("PaymentCreate");
        }

        public async Task<IActionResult> PaymentEdit(int id)
        {
            ServiceReference_PaymentMethod.PaymentMethod p = await pay.findPaymentMethodByIdAsync(id);
            ViewBag.flag = flag;
            ViewBag.message = message;
            flag = "";
            message = "";
            return View(p);
        }
        public async Task<IActionResult> PaymentUpdate(ServiceReference_PaymentMethod.PaymentMethod p)
        {
            bool _boolean = await pay.updatePaymentMethodAsync(p);
            if (_boolean)
            {
                flag = "success";
                message = "Update payment method success";
            }
            else
            {
                flag = "error";
                message = "Update payment method unsuccess.";
            }
            return RedirectToAction("PaymentEdit/" + p.PaymentMethodId);
        }
        public async Task<IActionResult> PaymentDelete(int id)
        {
            bool _boolean = await pay.deletePaymentMethodAsync(id);
            return RedirectToAction("PaymentIndex");
        }

        public async Task<IActionResult> SliderIndex()
        {
            var model = await slide.getAllSliderAsync();
            return View(model);
        }
        public IActionResult SliderCreate()
        {
            ViewBag.flag = flag;
            ViewBag.message = message;
            flag = "";
            message = "";
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SliderSave(Slider s, IList<IFormFile> files)
        {
            bool _boolean = false;
            if (files.Count > 0)
            {
                string path = _host.WebRootPath + @"/images/";
                string filename = "";
                foreach (var f in files)
                {
                    filename = f.FileName;
                    FileStream fs = System.IO.File.Create(path + filename);
                    f.CopyTo(fs);
                    fs.Flush();
                    fs.Dispose();
                }
                s.ImageSlider = filename;
                _boolean = await slide.createSliderAsync(s);
            }
            else
            {
                _boolean = await slide.createSliderAsync(s);
            }
            if (_boolean)
            {
                flag = "success";
                message = "Add new slider success";
            }
            else
            {
                flag = "error";
                message = "Add new slider unsuccess.";
            }
            return RedirectToAction("SliderCreate");
        }
        public async Task<IActionResult> SliderEdit(int id)
        {
            Slider s = await slide.findSliderByIdAsync(id);
            ViewBag.flag = flag;
            ViewBag.message = message;
            flag = "";
            message = "";
            return View(s);
        }
        public async Task<IActionResult> SliderUpdate(Slider s, IList<IFormFile> files)
        {
            bool _boolean = false;
            if (files.Count > 0)
            {
                string path = _host.WebRootPath + @"\images\";
                string filename = "";
                foreach (var file in files)
                {
                    filename = file.FileName;
                    FileStream fs = System.IO.File.Create(path + filename);
                    file.CopyTo(fs);
                    fs.Flush();
                    fs.Dispose();
                }
                s.ImageSlider = filename;
                _boolean = await slide.updateSliderAsync(s);
            }
            else
            {
                _boolean = await slide.updateSliderAsync(s);
            }
            if (_boolean)
            {
                flag = "success";
                message = "Update slider success";
            }
            else
            {
                flag = "error";
                message = "Update slider unsuccess.";
            }


            return RedirectToAction("SliderEdit/" + s.SliderId);
        }
        public async Task<IActionResult> SliderDelete(int id)
        {
            bool _boolean = await slide.deleteSliderAsync(id);
            return RedirectToAction("SliderIndex");
        }

        public async Task<IActionResult> CountryIndex()
        {
            var model = await co.getAllCountryAsync();
            return View(model);
        }
        public async Task<IActionResult> CountryEdit(int id)
        {
            ServiceReference_Country.Country e = await co.findCountrybyIdAsync(id);
            ViewBag.flag = flag;
            ViewBag.message = message;
            flag = "";
            message = "";
            return View(e);
        }

        public async Task<IActionResult> CountrySave(ServiceReference_Country.Country e)
        {
            bool _boolean = await co.createCountryAsync(e);
            if (_boolean)
            {
                flag = "success";
                message = "Add new country success";
            }
            else
            {
                flag = "error";
                message = "Add new country unsuccess.";
            }
            return RedirectToAction("CountryCreate");
        }
        public IActionResult CountryCreate()
        {
            ViewBag.flag = flag;
            ViewBag.message = message;
            flag = "";
            message = "";
            return View();
        }
        public async Task<IActionResult> CountryUpdate(ServiceReference_Country.Country e)
        {
            bool _boolean = await co.updateCountryAsync(e);
            if (_boolean)
            {
                flag = "success";
                message = "Update country success";
            }
            else
            {
                flag = "error";
                message = "Update country unsuccess.";
            }
            return RedirectToAction("CountryEdit/" + e.CountryId);
        }
        public async Task<IActionResult> CountryDelete(int id)
        {
            bool _boolean = await co.deleteCountryAsync(id);
            return RedirectToAction("CountryIndex");
        }


        public async Task<IActionResult> SupplierIndex()
        {
            var model = await sup.getAllSupplierAsync();
            return View(model);
        }

        public async Task<IActionResult> SupplierCreate()
        {
            ServiceReference_Category.Category[] lst_categories = await cs.getAllCategoryAsync();
            ServiceReference_Country.Country[] lst_countries = await co.getAllCountryAsync();
            SupplierModel sm = new SupplierModel()
            {
                categories = lst_categories,
                countries = lst_countries
            };
            ViewBag.flag = flag;
            ViewBag.message = message;
            flag = "";
            message = "";
            return View(sm);
        }
        public async Task<IActionResult> SupplierEdit(string id)
        {
            ServiceReference_Supplier.Supplier s = await sup.findSupplierByIdAsync(id);
            ServiceReference_Category.Category[] lst_categories = await cs.getAllCategoryAsync();
            ServiceReference_Country.Country[] lst_countries = await co.getAllCountryAsync();
            SupplierModel sm = new SupplierModel()
            {
                categories = lst_categories,
                countries = lst_countries,
                SupplierId = s.SupplierId,
                Avatar = s.Avatar,
                CompanyName = s.CompanyName,
                Email = s.Email,
                Phone = s.Phone,
                Address = s.Address,
                Province = s.Province,
                MainProduct = s.MainProduct,
                CategoryId = (int)s.CategoryId,
                Website = s.Website,
                Zipcode = s.Zipcode,
                CountryId = (int)s.CountryId,
                Status = s.Status,
                BussinessType = s.BussinessType,
                YearEstablished = s.YearEstablished,
                TotalEmployees = s.TotalEmployees
            };
            ViewBag.flag = flag;
            ViewBag.message = message;
            flag = "";
            message = "";
            return View(sm);
        }

        public async Task<IActionResult> SupplierUpdate(SupplierModel sm)
        {
            ServiceReference_Supplier.Supplier s = await sup.findSupplierByIdAsync(sm.SupplierId);
            s.SupplierId = sm.SupplierId;
            s.CompanyName = sm.CompanyName;
            s.Email = sm.Email;
            s.Phone = sm.Phone;
            s.Address = sm.Address;
            s.Province = sm.Province;
            s.MainProduct = sm.MainProduct;
            s.CategoryId = sm.CategoryId;
            s.Website = sm.Website;
            s.Zipcode = sm.Zipcode;
            s.CountryId = sm.CountryId;
            s.Status = sm.Status;
            s.BussinessType = sm.BussinessType;
            s.YearEstablished = sm.YearEstablished;
            s.TotalEmployees = sm.TotalEmployees;
            bool _boolean = await sup.updateSupplierAsync(s);
            if (_boolean)
            {
                flag = "success";
                message = "Update supplier success.";
                return RedirectToAction("SupplierEdit/" + s.SupplierId);
            }
            else
            {
                flag = "success";
                message = "Update supplier success.";
                return RedirectToAction("SupplierEdit/" + s.SupplierId);
            }
        }

        public async Task<IActionResult> SupplierSave(SupplierModel sm)
        {
            ServiceReference_Supplier.Supplier s = new ServiceReference_Supplier.Supplier();
            s.SupplierId = sm.SupplierId;
            s.CompanyName = sm.CompanyName;
            s.Email = sm.Email;
            s.Phone = sm.Phone;
            s.Address = sm.Address;
            s.Province = sm.Province;
            s.MainProduct = sm.MainProduct;
            s.CategoryId = sm.CategoryId;
            s.Website = sm.Website;
            s.Zipcode = sm.Zipcode;
            s.CountryId = sm.CountryId;
            s.Status = sm.Status;
            s.BussinessType = sm.BussinessType;
            s.YearEstablished = sm.YearEstablished;
            s.TotalEmployees = sm.TotalEmployees;
            bool _boolean = await sup.createSupplierAsync(s);
            if (_boolean)
            {
                flag = "success";
                message = "Add new supplier success.";
                return RedirectToAction("SupplierCreate");
            }
            else
            {
                flag = "error";
                message = "Add new supplier fail.";
                return RedirectToAction("SupplierCreate");
            }
        }

        public async Task<IActionResult> SupplierDelete(string id)
        {
            bool _boolean = await sup.deleteSupplierAsync(id);
            return RedirectToAction("SupplierIndex");
        }

        public async Task<IActionResult> WholesalerIndex()
        {
            var model = await whole.getAllWholesalerAsync();
            return View(model);
        }

        public async Task<IActionResult> WholesalerCreate()
        {
            ServiceReference_Country.Country[] lst_countries = await co.getAllCountryAsync();
            WholesalerModel im = new WholesalerModel()
            {
                coutries = lst_countries
            };
            ViewBag.flag = flag;
            ViewBag.message = message;
            flag = "";
            message = "";
            return View(im);
        }

        public async Task<IActionResult> WholesalerSave(WholesalerModel wm)
        {
            ServiceReference_Wholesaler.Wholesaler w = new ServiceReference_Wholesaler.Wholesaler();
            ServiceReference_ContactPerson.ContactPerson c = new ServiceReference_ContactPerson.ContactPerson();
            w.WholesalerId = wm.WholesalerId;
            w.Fullname = wm.Fullname;
            w.Email = wm.Email;
            w.Phone = wm.Phone;
            w.AddressWS = wm.AddressWS;
            w.CountryId = wm.CountryId;
            w.Website = wm.Website;
            w.StatusWS = wm.StatusWS;
            c.WholesalerId = await whole.getWholesalerIdAsync(wm.CountryId);
            c.Fullname = wm.CompanyName;
            c.Email = wm.CEmail;
            c.Phone = wm.CPhone;
            c.StatusCP = wm.StatusCP;
            bool _boolean = await whole.createWholesalerAsync(w);
            bool _bool = await cp.createContactPersonAsync(c);
            if (_boolean && _bool)
            {
                flag = "success";
                message = "Add new wholesaler success";
            }
            else
            {
                flag = "error";
                message = "Add new wholesaler fail.";
            }
            return RedirectToAction("WholesalerCreate");
        }
        public async Task<IActionResult> WholesalerEdit(string id)
        {
            ServiceReference_Wholesaler.Wholesaler w = await whole.findWholesalerByIdAsync(id);
            //ServiceReference_ContactPerson.ContactPerson c = await cp.findContactPersonbySalerIdAsync(id);
            ServiceReference_Country.Country[] lst_countries = await co.getAllCountryAsync();
            WholesalerModel wm = new WholesalerModel()
            {
                coutries = lst_countries,
                WholesalerId = w.WholesalerId,
                Fullname = w.Fullname,
                Email = w.Email,
                Phone = w.Phone,
                AddressWS = w.AddressWS,
                CountryId = w.CountryId,
                Website = w.Website,
                StatusWS = w.StatusWS,
                //ContactPersonId = c.ContactPersonId,
                //CompanyName = c.Fullname,
                //CEmail = c.Email,
                //CPhone = c.Phone,
                //StatusCP = c.StatusCP

            };
            ViewBag.flag = flag;
            ViewBag.message = message;
            flag = "";
            message = "";
            return View(wm);
        }


        public async Task<IActionResult> WholesalerUpdate(WholesalerModel wm)
        {
            ServiceReference_Wholesaler.Wholesaler w = await whole.findWholesalerByIdAsync(wm.WholesalerId);
            //ServiceReference_ContactPerson.ContactPerson c = await cp.findContactPersonbySalerIdAsync(wm.WholesalerId);
            w.WholesalerId = wm.WholesalerId;
            w.Fullname = wm.Fullname;
            w.Email = wm.Email;
            w.Phone = wm.Phone;
            w.AddressWS = wm.AddressWS;
            w.CountryId = wm.CountryId;
            w.Website = wm.Website;
            w.StatusWS = wm.StatusWS;
            //c.ContactPersonId = wm.ContactPersonId;
            //c.WholesalerId = wm.WholesalerId;
            //c.Fullname = wm.CompanyName;
            //c.Email = wm.CEmail;
            //c.Phone = wm.CPhone;
            //c.StatusCP = wm.StatusCP;
            bool _boolean = await whole.updateWholesalerAsync(w);
            //bool _bool = await cp.updateContactPersonAsync(c);
            if (_boolean)
            {
                flag = "success";
                message = "Update wholesaler success";
            }
            else
            {
                flag = "error";
                message = "Update wholesaler fail.";
            }
            return RedirectToAction("WholesalerEdit/" + w.WholesalerId);
        }
        public async Task<IActionResult> WholesalerDelete(string id)
        {
            bool _boolean = await whole.deleteWholesalerAsync(id);
            return RedirectToAction("WholesalerIndex");
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
                    //_logger.LogInformation(3, "User changed their password successfully.");
                    ViewBag.msg = "success";
                    return View();
                }
                ViewBag.msg = "error";
                return View(model);
            }
            return RedirectToAction("ChangePassword");
        }

        // Role Admintration

        public async Task<IActionResult> RoleIndex()
        {
            var model = _roleManager.Roles;
            return View(model);
        }
        

        public async Task<JsonResult> AddRole(string role)
        {
            IdentityRole irole = await _roleManager.FindByNameAsync(role);
            IdentityRole newRole = new IdentityRole(role);
            if (irole == null)
                await _roleManager.CreateAsync(newRole);
            var model = _roleManager.Roles;
            return Json(model);
        }

        public async Task<JsonResult> DeleteRole(string role)
        {
            IdentityRole irole = await _roleManager.FindByNameAsync(role);
            if (irole != null)
                await _roleManager.DeleteAsync(irole);
            var model = _roleManager.Roles;
            return Json(model);
        }

        public async Task<JsonResult> ActiveSlider(int id,bool active)
        {
            Slider s = await slide.findSliderByIdAsync(id);
            s.IsActive = active;
            bool res = await slide.updateSliderAsync(s);
            return Json(s);
        }
    }
}
