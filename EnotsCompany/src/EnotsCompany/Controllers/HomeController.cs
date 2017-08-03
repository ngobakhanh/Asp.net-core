using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServiceReference_Category;
using EnotsCompany.Models;
using ServiceReference_Item;
using ServiceReference_Supplier;
using ServiceReference_Feedback;
using System.Text.RegularExpressions;
using ServiceReference_Article;
using Newtonsoft.Json;
using System.Text;

namespace EnotsCompany.Controllers
{

    public class HomeController : Controller
    {
        ServiceReference_Slider.SliderServiceClient slider = new ServiceReference_Slider.SliderServiceClient();
        ItemServiceClient itm = new ItemServiceClient();
        CategoryServiceClient cs = new CategoryServiceClient();
        SupplierServiceClient sup = new SupplierServiceClient();
        FeedbackServiceClient fb = new FeedbackServiceClient();
        ArticleServiceClient acl = new ArticleServiceClient();
        static ServiceReference_Invoice.InvoiceServiceClient iv = new ServiceReference_Invoice.InvoiceServiceClient();
        ServiceReference_Unit.UnitServiceClient unit = new ServiceReference_Unit.UnitServiceClient();


        // GET: /<controller>/
        public async Task<IActionResult> Index(string searchString)
        {
            List<ServiceReference_Supplier.Supplier> lst_sup = (await sup.getAllSupplierAsync()).Take(6).ToList();
            ViewData["CurrentFilter"] = searchString;
            ViewBag.sliders = (await slider.getAllSliderAsync()).Where(s=>s.IsActive == true).ToList();

            List<RecentViewedItem> lst_recent = new List<RecentViewedItem>();
            byte[] ViewItemsession;
            HttpContext.Session.TryGetValue("RecentProductList", out ViewItemsession);
            string RecentProductList;
            if (ViewItemsession != null)
            {
                RecentProductList = Encoding.UTF8.GetString(ViewItemsession);
                if (RecentProductList == "" || RecentProductList == null)
                {
                    lst_recent = new List<RecentViewedItem>();
                }
                else
                {
                    //convert  string --> lst
                    lst_recent = (List<RecentViewedItem>)JsonConvert.DeserializeObject<List<RecentViewedItem>>(RecentProductList);
                }
            }
                ViewData["RecentProductList"] = lst_recent;

            if (!String.IsNullOrEmpty(searchString))
            {
                return RedirectToAction("Category", "Home", new { searchString });
            }
            SupplierModel supmodel = new SupplierModel
            {
                suppliers = lst_sup
            };
            return View(supmodel);
        }

        public async Task<ServiceReference_Category.Category[]> getAllCategory()
        {
            ServiceReference_Category.Category[] lst_itemParent = await cs.getAllCategoryAsync();
            return lst_itemParent;
        }

        public static async Task<int> numberInvoice(string supplierId)
        {

            var count = (await iv.getAllInvoiceAsync()).Where(i => i.SupplierId == supplierId).Count();
            return count;
        }


        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }


        public async Task<IActionResult> Category(int? categoryId, int? page, string searchString = "")
        {
            List<ServiceReference_Item.Item> lst_item = null;
            ViewBag.page = page ?? 1;
            ViewBag.CategoryId = categoryId;
            int pageSize = 8;
            ViewData["CurrentFilter"] = searchString;
            ServiceReference_Category.Category catebyId;
            if (!String.IsNullOrEmpty(searchString))//nếu có nhập tìm kiếm thì đưa vào list tìm sp theo tên
            {
                lst_item = (await itm.findItembyNameAsync(searchString)).ToList();
                ViewData["link"] = searchString;
            }
            else if(searchString == null && categoryId == null)
            {
                lst_item = (await itm.getAllItemAsync()).ToList();
                ViewData["link"] = "All";
            }
            else
            {
                lst_item = (await itm.findItembyCategoryIdAsync((int)categoryId)).ToList();
                catebyId = await cs.findCategorybyIdAsync((int)categoryId);
                ViewData["link"] = catebyId.CategoryName;
            }

            var items = (from a in lst_item select a).AsQueryable();
            return View(PaginatedList<ServiceReference_Item.Item>.CreateAsync(items, page ?? 1, pageSize));
        }

        public async Task<IActionResult> SupplierItem(string supplierId, int? page = 1)
        {
            List<ServiceReference_Item.Item> lst_ItembyCate;
            lst_ItembyCate = (await itm.findItembySupIdAsync(supplierId)).ToList();
            var items = (from a in lst_ItembyCate select a).AsQueryable();
            ViewBag.page = page;
            int pageSize = 10;
            return View(PaginatedList<ServiceReference_Item.Item>.CreateAsync(items, page ?? 1, pageSize));
        }
        public void AddRecentProduct(List<RecentViewedItem> list, int id, string name, string img, string price, string unitName, int cateId, int maxItems)
        {
            // list is current list of RecentProduct objects
            // Check if item already exists
            var item = list.FirstOrDefault(t => t.ItemId == id);
            // TODO: here if item is found, you could do some more coding
            //       to move item to the end of the list, since this is the
            //       last product referenced.
            if (item == null)
            {
                // Add item only if it does not exist
                list.Add(new RecentViewedItem
                {
                    ItemId = id,
                    ItemName = name,
                    ImageItem = img,
                    Price = price,
                    UnitName = unitName,
                    CategoryId = cateId,
                    LastVisited = DateTime.Now,
                });
            }

            // Check that recent product list does not exceed maxItems
            // (items at the top of the list are removed on FIFO basis;
            // first in, first out).
            while (list.Count > maxItems)
            {
                list.RemoveAt(0);
            }
        }
        public async Task<IActionResult> ItemDetail(int id, int cateId)
        {
            ServiceReference_Item.Item items = await itm.findItembyIdAsync(id);
            ServiceReference_Unit.Unit[] lstUnit = await unit.getAllUnitAsync();
            ServiceReference_Item.Item[] lstRelatedItem = await itm.findItembyCategoryIdAsync(cateId);
            ServiceReference_Feedback.Feedback[] feedbacks = await fb.findFeedbackbyItemIdAsync(id);

            List<RecentViewedItem> lst = new List<RecentViewedItem>();

            byte[] ViewItemsession;
            HttpContext.Session.TryGetValue("RecentProductList", out ViewItemsession);
            string RecentProductList;
            if (ViewItemsession != null)
            {
                RecentProductList = Encoding.UTF8.GetString(ViewItemsession);
                if (RecentProductList == "" || RecentProductList == null)
                {
                    lst = new List<RecentViewedItem>();
                }
                else
                {
                    //convert  string --> lst
                    lst = (List<RecentViewedItem>)JsonConvert.DeserializeObject<List<RecentViewedItem>>(RecentProductList);
                }
            }
            else
            {
                RecentProductList = "";
                lst = new List<RecentViewedItem>();
            }
            // Add product to recent list (make list contain max 3 items; change if you like)
            AddRecentProduct(lst, id, items.ItemName, items.ImageItem, items.Price, items.Unit.UnitName, cateId, 4);

            //luu session;
            RecentProductList = JsonConvert.SerializeObject(lst);
            ViewItemsession = Encoding.UTF8.GetBytes(RecentProductList);
            HttpContext.Session.Set("RecentProductList", ViewItemsession);

            // Store recentProductList to ViewData keyed as "RecentProductList" to use it in a view
            ViewData["RecentProductList"] = lst;

            CategoryModel iemModel = new CategoryModel
            {
                ItemById = items,
                listUnit = lstUnit,
                listItemByCategory = lstRelatedItem,
                lst_feedback = feedbacks
            };
            ViewBag.ItemId = id;
            return View(iemModel);
        }

        public async Task<IActionResult> Article(int? page)
        {
            List<Article> lstArrticle = (await acl.getAllArticleAsync()).Where(a=>a.StatusArticle == "Enable").ToList();
            ViewBag.page = page ?? 1;
            var items = (from a in lstArrticle select a).AsQueryable();
            int pageSize = 4;
            return View(PaginatedList<ServiceReference_Article.Article>.CreateAsync(items, page ?? 1, pageSize));
        }

        public async Task<IActionResult> ArticleDetail(int id = 0)
        {
            Article findarc = await acl.findArticlebyIDAsync(id);
            if (id != 0)
            {
                ArticleModel arclmodel = new ArticleModel
                {
                    arclById = findarc
                };
                return View(arclmodel);
            }


            return View();
        }

        public async Task<IActionResult> SupplierDetail(string id, int? page = 1)
        {
            List<ServiceReference_Item.Item> items = (await itm.findItembySupIdAsync(id)).Take(4).ToList();
            var supplier = await sup.findSupplierByIdAsync(id);
            SupplierModel model = new SupplierModel()
            {
                supplier = supplier,
                items = items
            };
            return View(model);
        }

    }
}
