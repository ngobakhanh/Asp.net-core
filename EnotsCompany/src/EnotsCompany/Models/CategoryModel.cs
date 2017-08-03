using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceReference_Category;

namespace EnotsCompany.Models
{
    public class CategoryModel
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string ImageCate { get; set; }
        public Nullable<int> ParentId { get; set; }
        public string StatusCate { get; set; }

        public Category[] categories { get; set; }

        //public ServiceReference_Category.Category[] listParentCate { get; set; }

        //public ServiceReference_Supplier.Supplier[] listSupByCategory { get; set; }

        public ServiceReference_Feedback.Feedback[] lst_feedback { get; set; }

        public ServiceReference_Item.Item[] listItemByCategory { get; set; }

        public ServiceReference_Item.Item ItemById { get; set; }

        public ServiceReference_Category.Category CategorybyId { get; set; }

        public ServiceReference_Unit.Unit[] listUnit { get; set; }
    }
}
