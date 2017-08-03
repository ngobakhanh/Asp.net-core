using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfServiceLibrary_EnotsCompany.DAL;

namespace WcfServiceLibrary_EnotsCompany
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ItemService" in both code and config file together.
    public class ItemService : IItemService
    {
        B2BEntities ctx = new B2BEntities();
        public bool createItem(Item i)
        {
            Item _e = ctx.Items.Where(c => c.ItemId == i.ItemId).SingleOrDefault();

            if (_e != null)
            {
                My_Exception.MyFaultException myex = new My_Exception.MyFaultException();
                myex.errorCode = "1002";
                myex.message = "ID is exist";

                throw new FaultException<My_Exception.MyFaultException>(myex);

            }
            else
            {
                ctx.Items.Add(i);
                ctx.SaveChanges();
                return true;
            }
            return false;
        }

        public bool deleteItem(int id)
        {
            Item p = findItembyId(id);
            if (p == null)
            {
                My_Exception.MyFaultException myex = new My_Exception.MyFaultException();
                myex.errorCode = "1003";
                myex.message = "ID does not exist";

                throw new FaultException<My_Exception.MyFaultException>(myex);

            }
            else
            {
                p.StatusItem = "Disable";
                ctx.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Item> findItembyCategoryId(int categoryId)
        {
            List<Item> listI = ctx.Items
                .Include("Category")
                .Include("Supplier")
                .Include("Unit").Where(c => c.CategoryId == categoryId)
                .Where(s => s.StatusItem.Trim().ToLower() == "enable")
                .ToList();
           if (listI == null)
            {
                throw new FaultException(new FaultReason("id not found"), FaultCode.CreateReceiverFaultCode(new FaultCode("1001")));
            }
            else
            {
                return listI;
            }
        }

        public Item findItembyId(int id)
        {
            Item ite = ctx.Items
                .Include("Category")
                .Include("Supplier")
                .Include("Unit")
                .Where(c => c.ItemId == id)
                .SingleOrDefault();
            if (ite == null)
            {
                throw new FaultException(new FaultReason("id not found"), FaultCode.CreateReceiverFaultCode(new FaultCode("1001")));
            }
            else
            {
                return ite;
            }
        }

        public List<Item> findItembyName(string name)
        {
            List<Item> listI = ctx.Items
                .Include("Category")
                .Include("Supplier")
                .Include("Unit")
                .Where(c => c.ItemName.Contains(name) && c.StatusItem.ToLower() == "enable")
                .ToList();
            if (listI == null)
            {
                throw new FaultException(new FaultReason("id not found"), FaultCode.CreateReceiverFaultCode(new FaultCode("1001")));
            }
            else
            {
                return listI;
            }
        }

        public List<Item> findItembySupId(string supId)
        {
            List<Item> listI = ctx.Items.Include("Category")
                .Include("Supplier")
                .Include("Unit")
                .Where(c => c.SupplierId == supId && c.StatusItem.Trim().ToLower() == "enable")
                .ToList();
            if (listI == null)
            {
                throw new FaultException(new FaultReason("id not found"), FaultCode.CreateReceiverFaultCode(new FaultCode("1001")));
            }
            else
            {
                return listI;
            }
        }

        public List<Item> getAllItem()
        {

            List<Item> lst = ctx.Items
                .Include("Category")
                .Include("Supplier")
                .Include("Unit")
                .ToList();
            if (lst == null)
            {
                throw new FaultException(new FaultReason("Data not found"), FaultCode.CreateReceiverFaultCode(new FaultCode("1001")));
            }
            else
            {
                return lst;
            }
        }

        public List<Item> sortItembyNameAZ()
        {
            List<Item> listI = ctx.Items.OrderBy(x => x.ItemName)
                .Where(s => s.StatusItem.Trim().ToLower() == "enable")
                .ToList();
            if (listI == null)
            {
                throw new FaultException(new FaultReason("id not found"), FaultCode.CreateReceiverFaultCode(new FaultCode("1001")));
            }
            else
            {
                return listI;
            }
        }

        public List<Item> sortItembyNameZA()
        {
            List<Item> listI = ctx.Items
                .OrderByDescending(x => x.ItemName)
                .Where(s => s.StatusItem.Trim().ToLower() == "enable")
                .ToList();
            if (listI == null)
            {
                throw new FaultException(new FaultReason("id not found"), FaultCode.CreateReceiverFaultCode(new FaultCode("1001")));
            }
            else
            {
                return listI;
            }
        }

        public bool updateItem(Item i)
        {
            Item old_I = findItembyId(i.ItemId);
            if (old_I == null)
            {
                My_Exception.MyFaultException myex = new My_Exception.MyFaultException();
                myex.errorCode = "1003";
                myex.message = "ID does not exist";

                throw new FaultException<My_Exception.MyFaultException>(myex);

            }
            else
            {
                
                old_I.ItemId = i.ItemId;
                old_I.ItemName = i.ItemName;
                old_I.DescriptionItem = i.DescriptionItem;
                old_I.Price = i.Price;
                old_I.MinQuantity = i.MinQuantity;
                old_I.Discount = i.Discount;
                old_I.ImageItem = i.ImageItem;
                old_I.MoreImage = i.MoreImage;
                old_I.CategoryId = i.CategoryId;
                old_I.SupplierId = i.SupplierId;
                old_I.ParentItem = i.ParentItem;
                old_I.AddedDate = i.AddedDate;
                old_I.Warranty = i.Warranty;
                old_I.UnitId = i.UnitId;
                old_I.Note = i.Note;
                old_I.ShippingFee = i.ShippingFee;
                old_I.FAQ = i.FAQ;
                old_I.StatusItem = i.StatusItem;

                ctx.SaveChanges();
                return true;
            }
                return false;
        }
    }
}
