using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfServiceLibrary_EnotsCompany.DAL;

namespace WcfServiceLibrary_EnotsCompany
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CountryService" in both code and config file together.
    public class CountryService : ICountryService
    {
        B2BEntities ctx = new B2BEntities();
        public bool createCountry(Country co)
        {
            Country _e = ctx.Countries.Where(c => c.CountryId == co.CountryId).SingleOrDefault();
            if (_e != null)
            {
                My_Exception.MyFaultException myex = new My_Exception.MyFaultException();
                myex.errorCode = "1002";
                myex.message = "ID is exist";

                throw new FaultException<My_Exception.MyFaultException>(myex);

            }
            else
            {
                ctx.Countries.Add(co);
                ctx.SaveChanges();
                return true;
            }
            return false;
        }

        public bool deleteCountry(int id)
        {
            Country _e = findCountrybyId(id);
            if (_e == null)
            {
                My_Exception.MyFaultException myex = new My_Exception.MyFaultException();
                myex.errorCode = "1003";
                myex.message = "ID does not exist";

                throw new FaultException<My_Exception.MyFaultException>(myex);

            }
            else
            {
                _e.StatusCountry = "Disable";
                ctx.SaveChanges();
                return true;
            }
            return false;
        }

        public Country findCountrybyCode(string code)
        {
            Country cn = ctx.Countries.Where(c => c.CountryCode==code).SingleOrDefault();
            if (cn == null)
            {
                throw new FaultException(new FaultReason("Country code not found"), FaultCode.CreateReceiverFaultCode(new FaultCode("1001")));
            }
            else
            {
                return cn;
            }
        }

        public Country findCountrybyId(int id)
        {
            Country cn = ctx.Countries.Where(c => c.CountryId == id).SingleOrDefault();
            if (cn == null)
            {
                throw new FaultException(new FaultReason("id not found"), FaultCode.CreateReceiverFaultCode(new FaultCode("1001")));
            }
            else
            {
                return cn;
            }
        }

        public List<Country> findCountrybyName(string nameCountry)
        {
            List<Country> cn = ctx.Countries.Where(c => c.CommonName.Contains(nameCountry)).ToList();
            if (cn == null)
            {
                throw new FaultException(new FaultReason("name not found"), FaultCode.CreateReceiverFaultCode(new FaultCode("1001")));
            }
            else
            {
                return cn;
            }
        }

        public List<Country> getAllCountry()
        {
            List<Country> lst = ctx.Countries.ToList();
            if (lst.Count == 0)
            {
                throw new FaultException("Data not found!!!");
            }
            else
            {
                return lst;
            }
        }

        public bool updateCountry(Country c)
        {
            Country ct = findCountrybyId(c.CountryId);
            if (ct == null)
            {
                My_Exception.MyFaultException myex = new My_Exception.MyFaultException();
                myex.errorCode = "1003";
                myex.message = "ID does not exist";

                throw new FaultException<My_Exception.MyFaultException>(myex);

            }
            else
            { 
                
                ct.CountryId = c.CountryId;
                ct.CommonName = c.CommonName;
                ct.CountryCode = c.CountryCode;
                ct.StatusCountry = c.StatusCountry;
                ctx.SaveChanges();
                return true;
            }
                return false;
        }
    }
}
