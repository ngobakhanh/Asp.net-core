using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfServiceLibrary_EnotsCompany.DAL;
namespace WcfServiceLibrary_EnotsCompany
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SupplierService" in both code and config file together.
    public class SupplierService : ISupplierService
    {
        B2BEntities ctx = new B2BEntities();
        public bool createSupplier(Supplier sup)
        {
            Supplier _e = ctx.Suppliers.Where(c => c.SupplierId == sup.SupplierId).SingleOrDefault();
            if (_e != null)
            {
                My_Exception.MyFaultException myex = new My_Exception.MyFaultException();
                myex.errorCode = "1002";
                myex.message = "ID is exist";

                throw new FaultException<My_Exception.MyFaultException>(myex);

            }
            else
            {
                sup.SupplierId = getSupplierId((int)sup.CountryId);
                ctx.Suppliers.Add(sup);
                ctx.SaveChanges();
                return true;
            }
            return false;
        }

        public bool deleteSupplier(string supId)
        {
            Supplier _e = findSupplierById(supId);
            if (_e == null)
            {
                My_Exception.MyFaultException myex = new My_Exception.MyFaultException();
                myex.errorCode = "1003";
                myex.message = "ID does not exist";

                throw new FaultException<My_Exception.MyFaultException>(myex);

            }
            else
            {
                _e.Status = "Disable";
                ctx.SaveChanges();
                return true;
            }
            return false;
        }

        public Supplier findSupplierById(string supId)
        {
            Supplier e = ctx.Suppliers.Where(c => c.SupplierId == supId).SingleOrDefault();
            if (e == null)
            {
                throw new FaultException(new FaultReason("id not found"), FaultCode.CreateReceiverFaultCode(new FaultCode("1001")));
            }
            else
            {
                return e;
            }
        }

        public List<Supplier> getAllSupplier()
        {
            List<Supplier> lst = ctx.Suppliers.Include("Country1").Where(w => w.Status == "Enable").ToList();
            if (lst.Count == 0)
            {
                throw new FaultException("Data not found!!!");
            }
            else
            {
                return lst;
            }
        }

        public string getSupplierId(int countryId)
        {
            string supplierId = "";
            int maxId = 0;
            try
            {
                maxId = int.Parse(ctx.Suppliers.Max(p => p.SupplierId.Substring(2)));
            }
            catch (Exception ex)
            {
                maxId = -1;
            }
            var supplierList = (from a in ctx.Countries
                                where a.CountryId == countryId
                                select new
                                {
                                    countryCode = a.CountryCode
                                });
            string cCode = supplierList.FirstOrDefault().countryCode;

            if (maxId < 0)
            {
                supplierId = cCode + "0001";
            }
            else if (maxId >= 0 && maxId < 9)
            {
                supplierId = cCode + "000" + (maxId + 1);
            }
            else if (maxId >= 9 && maxId < 99)
            {
                supplierId = cCode + "00" + (maxId + 1);
            }
            else if (maxId >= 99 && maxId < 999)
            {
                supplierId = cCode + "0" + (maxId + 1);
            }
            else if (maxId >= 999 && maxId < 9999)
            {
                supplierId = cCode + (maxId + 1);
            }

            return supplierId;
        }

        public bool updateSupplier(Supplier sup)
        {
            Supplier s = findSupplierById(sup.SupplierId);
            if (s == null)
            {
                My_Exception.MyFaultException myex = new My_Exception.MyFaultException();
                myex.errorCode = "1003";
                myex.message = "ID does not exist";

                throw new FaultException<My_Exception.MyFaultException>(myex);

            }
            else
            {
                s.SupplierId = sup.SupplierId;
                s.Name = sup.Name;
                s.Title = sup.Title;
                s.CompanyName = sup.CompanyName;
                s.Avatar = sup.Avatar;
                s.Email = sup.Email;
                s.Phone = sup.Phone;
                s.Address = sup.Address;
                s.Province = sup.Province;
                s.MainProduct = sup.MainProduct;
                s.CategoryId = sup.CategoryId;
                s.Website = sup.Website;
                s.Zipcode = sup.Zipcode;
                s.Country = sup.Country;
                s.CountryId = sup.CountryId;
                s.Status = sup.Status;
                s.BussinessType = sup.BussinessType;
                s.YearEstablished = sup.YearEstablished;
                s.TotalEmployees = sup.TotalEmployees;
                ctx.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
