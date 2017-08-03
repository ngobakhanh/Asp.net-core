using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfServiceLibrary_EnotsCompany.DAL;
namespace WcfServiceLibrary_EnotsCompany
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SliderService" in both code and config file together.
    public class SliderService : ISliderService
    {
        B2BEntities ctx = new B2BEntities();
        public bool createSlider(Slider slider)
        {
            Slider _e = ctx.Sliders.Where(c => c.SliderId == slider.SliderId).SingleOrDefault();
            if (_e != null)
            {
                My_Exception.MyFaultException myex = new My_Exception.MyFaultException();
                myex.errorCode = "1002";
                myex.message = "ID is exist";
                throw new FaultException<My_Exception.MyFaultException>(myex);

            }
            else
            {
                ctx.Sliders.Add(slider);
                ctx.SaveChanges();
                return true;
            }
            return false;
        }

        public bool deleteSlider(int sliderId)
        {
            Slider _e = ctx.Sliders.Where(c => c.SliderId == sliderId).SingleOrDefault();
            if (_e == null)
            {
                My_Exception.MyFaultException myex = new My_Exception.MyFaultException();
                myex.errorCode = "1003";
                myex.message = "ID does not exist";

                throw new FaultException<My_Exception.MyFaultException>(myex);

            }
            else
            {
                ctx.Sliders.Remove(_e);
                ctx.SaveChanges();
                return true;
            }
            return false;
        }

        public Slider findSliderById(int sliderId)
        {
            Slider slide= ctx.Sliders.Where(s => s.SliderId == sliderId).SingleOrDefault();
            if (slide == null)
            {
                throw new FaultException(new FaultReason("id not found"), FaultCode.CreateReceiverFaultCode(new FaultCode("1001")));
            }
            else
            {
                return slide;
            }
        }

        public List<Slider> getAllSlider()
        {
            List<Slider> lst = ctx.Sliders.ToList();
            if (lst.Count == 0)
            {
                throw new FaultException("Data not found!!!");
            }
            else
            {
                return lst;
            }
        }

        public bool updateSlider(Slider slider)
        {
            Slider s = findSliderById(slider.SliderId);
            if (s == null)
            {
                My_Exception.MyFaultException myex = new My_Exception.MyFaultException();
                myex.errorCode = "1003";
                myex.message = "ID does not exist";

                throw new FaultException<My_Exception.MyFaultException>(myex);

            }
            else
            {
                
                s.SliderId = slider.SliderId;
                s.ImageSlider = slider.ImageSlider;
                s.URL = slider.URL;
                s.IsActive = slider.IsActive;
                ctx.SaveChanges();
                return true;
            }
                return false;
        }
    }
}
