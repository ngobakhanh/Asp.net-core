using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfServiceLibrary_EnotsCompany.DAL;

namespace WcfServiceLibrary_EnotsCompany
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CategoryService" in both code and config file together.
    public class CategoryService : ICategoryService
    {
        B2BEntities ctx = new B2BEntities();
        public bool createCategory(Category ce)
        {
            Category _e = ctx.Categories.Where(c => c.CategoryId == ce.CategoryId).SingleOrDefault();
            if (_e != null)
            {
                My_Exception.MyFaultException myex = new My_Exception.MyFaultException();
                myex.errorCode = "1002";
                myex.message = "ID is exist";

                throw new FaultException<My_Exception.MyFaultException>(myex);

            }
            else
            {
                ctx.Categories.Add(ce);
                ctx.SaveChanges();
                return true;
            }
            return false;
        }

        public bool deleteCategory(int id)
        {
            Category _e = ctx.Categories.Where(c => c.CategoryId == id).SingleOrDefault();
            if (_e == null)
            {
                My_Exception.MyFaultException myex = new My_Exception.MyFaultException();
                myex.errorCode = "1003";
                myex.message = "ID does not exist";

                throw new FaultException<My_Exception.MyFaultException>(myex);

            }
            else
            {
                _e.StatusCate = "Disable";
                ctx.SaveChanges();
                return true;
            }
            return false;
        }

        public Category findCategorybyId(int id)
        {
            Category ca = ctx.Categories.Where(c => c.CategoryId == id).SingleOrDefault();            ;
            if (ca == null)
            {
                throw new FaultException(new FaultReason("id not found"), FaultCode.CreateReceiverFaultCode(new FaultCode("1001")));
            }
            else
            {
                return ca;
            }
        }

        public List<Category> findCategorybyName(string nameCategory)
        {
            List<Category> e = ctx.Categories.Where(c => c.CategoryName.Contains(nameCategory)).ToList();
            if (e == null)
            {
                throw new FaultException(new FaultReason("name not found"), FaultCode.CreateReceiverFaultCode(new FaultCode("1001")));
            }
            else
            {
                return e;
            }
        }

       
        public List<Category> getAllCategory()
        {
            List<Category> lst = ctx.Categories.ToList();
            if (lst.Count == 0)
            {
                throw new FaultException("Data not found!!!");
            }
            else
            {
                return lst;
            }
        }

        public bool updateCategory(Category c)
        {
            Category ca = findCategorybyId(c.CategoryId);
            if (ca == null)
            {
                My_Exception.MyFaultException myex = new My_Exception.MyFaultException();
                myex.errorCode = "1003";
                myex.message = "ID does not exist";

                throw new FaultException<My_Exception.MyFaultException>(myex);

            }
            else
            {
                ca.CategoryId = c.CategoryId;
                ca.CategoryName = c.CategoryName;
                ca.ImageCate = c.ImageCate;
                ca.ParentId = c.ParentId;
                ca.StatusCate = c.StatusCate;
                ctx.SaveChanges();
                return true;
            }
                return false;
        }
    }
}
