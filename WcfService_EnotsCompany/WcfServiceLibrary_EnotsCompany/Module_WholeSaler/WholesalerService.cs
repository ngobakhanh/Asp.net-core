using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfServiceLibrary_EnotsCompany.DAL;
namespace WcfServiceLibrary_EnotsCompany
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "WholesalerService" in both code and config file together.
    public class WholesalerService : IWholesalerService
    {
        B2BEntities ctx = new B2BEntities();
        public bool createWholesaler(Wholesaler wholesaler)
        {
            Wholesaler _e = ctx.Wholesalers.Where(c => c.WholesalerId == wholesaler.WholesalerId).SingleOrDefault();
            if (_e != null)
            {
                My_Exception.MyFaultException myex = new My_Exception.MyFaultException();
                myex.errorCode = "1002";
                myex.message = "ID is exist";

                throw new FaultException<My_Exception.MyFaultException>(myex);

            }
            else
            {
                wholesaler.WholesalerId = getWholesalerId(wholesaler.CountryId);
                ctx.Wholesalers.Add(wholesaler);
                ctx.SaveChanges();
                return true;
            }
            return false;
        }

        public bool deleteWholesaler(string wId)
        {
            Wholesaler _e = findWholesalerById(wId);
            if (_e == null)
            {
                My_Exception.MyFaultException myex = new My_Exception.MyFaultException();
                myex.errorCode = "1003";
                myex.message = "ID does not exist";

                throw new FaultException<My_Exception.MyFaultException>(myex);

            }
            else
            {
                _e.StatusWS = "Disable";
                ctx.SaveChanges();
                return true;
            }
            return false;
        }

        public Wholesaler findWholesalerById(string wId)
        {
            Wholesaler e = ctx.Wholesalers.Where(c => c.WholesalerId == wId).SingleOrDefault();
            if (e == null)
            {
                throw new FaultException(new FaultReason("id not found"), FaultCode.CreateReceiverFaultCode(new FaultCode("1001")));
            }
            else
            {
                return e;
            }
        }

        public List<Wholesaler> getAllWholesaler()
        {
            List<Wholesaler> lst = ctx.Wholesalers.Include("Country").Include("ContactPersons").Where(w=>w.StatusWS=="Enable").ToList();
            if (lst.Count == 0)
            {
                throw new FaultException("Data not found!!!");
            }
            else
            {
                return lst;
            }
        }

        public string getWholesalerId(int countryId)
        {
            int maxId = 0;
            try
            {
                maxId = int.Parse(ctx.Wholesalers.Max(p => p.WholesalerId.Substring(2)));
                
            }
            catch (Exception ex)
            {
                maxId = -1;
            }
            string wholesalerId = "";
            var wholesalerList = (from a in ctx.Countries
                                  where a.CountryId == countryId
                                  select new
                                  {
                                      countryCode = a.CountryCode
                                  });
            string cCode = wholesalerList.FirstOrDefault().countryCode;

            if (maxId < 0)
            {
                wholesalerId = cCode + "0001";
            }
            else if (maxId >= 0 && maxId < 9)
            {
                wholesalerId = cCode + "000" + (maxId + 1);
            }
            else if (maxId >= 9 && maxId < 99)
            {
                wholesalerId = cCode + "00" + (maxId + 1);
            }
            else if (maxId >= 99 && maxId < 999)
            {
                wholesalerId = cCode + "0" + (maxId + 1);
            }
            else if (maxId >= 999 && maxId < 9999)
            {
                wholesalerId = cCode + (maxId + 1);
            }

            return wholesalerId;
        }


        public bool updateWholesaler(Wholesaler wholesaler)
        {
            Wholesaler w = findWholesalerById(wholesaler.WholesalerId);
            if (w == null)
            {
                My_Exception.MyFaultException myex = new My_Exception.MyFaultException();
                myex.errorCode = "1003";
                myex.message = "ID does not exist";

                throw new FaultException<My_Exception.MyFaultException>(myex);

            }
            else
            {
                
                w.WholesalerId = wholesaler.WholesalerId;
                w.Fullname = wholesaler.Fullname;
                w.Avatar = wholesaler.Avatar;
                w.Email = wholesaler.Email;
                w.Phone = wholesaler.Phone;
                w.AddressWS = wholesaler.AddressWS;
                w.CountryId = wholesaler.CountryId;
                w.Website = wholesaler.Website;
                w.StatusWS = wholesaler.StatusWS;
                w.Amount = wholesaler.Amount;
                ctx.SaveChanges();
                return true;
            }
                return false;
        }
    }
}
