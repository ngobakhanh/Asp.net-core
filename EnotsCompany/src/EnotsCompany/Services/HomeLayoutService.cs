using ServiceReference_Category;
using ServiceReference_Supplier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnotsCompany.Services
{
    public class HomeLayoutService
    {
        public CategoryServiceClient cs = new CategoryServiceClient();
        public SupplierServiceClient sup = new SupplierServiceClient();

        public ServiceReference_Category.Category[] lst_itemParent { get; set; }
        public Supplier[] lst_supbyCate { get; set; }

        public HomeLayoutService()
        {
            getAllCategory();
            getAllSupplier();
        }

        public async Task<ServiceReference_Category.Category[]> getAllCategory()
        {
            lst_itemParent = await cs.getAllCategoryAsync();
            return lst_itemParent;
        }

        public async Task<Supplier[]> getAllSupplier()
        {
            lst_supbyCate = await sup.getAllSupplierAsync();
            return lst_supbyCate;
        }

    }
}

