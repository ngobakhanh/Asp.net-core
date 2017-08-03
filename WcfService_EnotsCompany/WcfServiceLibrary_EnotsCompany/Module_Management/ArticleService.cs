using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfServiceLibrary_EnotsCompany.DAL;

namespace WcfServiceLibrary_EnotsCompany
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ArticleService" in both code and config file together.
    public class ArticleService : IArticleService
    {
        B2BEntities ctx = new B2BEntities();

        public bool createArticle(Article a)
        {
            Article _e = ctx.Articles.Where(c => c.ArticleId == a.ArticleId).SingleOrDefault();
            if (_e != null)
            {
                My_Exception.MyFaultException myex = new My_Exception.MyFaultException();
                myex.errorCode = "1002";
                myex.message = "ID is exist";

                throw new FaultException<My_Exception.MyFaultException>(myex);

            }
            else
            {
                ctx.Articles.Add(a);
                ctx.SaveChanges();
                return true;
            }
            return false;
        }

        public bool deleteArticle(int id)
        {
            Article _e = ctx.Articles.Where(c => c.ArticleId == id).SingleOrDefault();
            if (_e == null)
            {
                My_Exception.MyFaultException myex = new My_Exception.MyFaultException();
                myex.errorCode = "1003";
                myex.message = "ID does not exist";

                throw new FaultException<My_Exception.MyFaultException>(myex);

            }
            else
            {
                _e.StatusArticle = "Disable";
                ctx.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Article> findArticlebyDate(DateTime date)
        {
            List<Article> a = ctx.Articles.Where(c => c.AddDate == date).ToList();
            return a;
        }

        public Article findArticlebyID(int id)
        {
            Article e = ctx.Articles.Where(c => c.ArticleId == id).SingleOrDefault();
            if (e == null)
            {
                throw new FaultException(new FaultReason("id not found"), FaultCode.CreateReceiverFaultCode(new FaultCode("1001")));
            }
            else
            {
                return e;
            }
        }

        public List<Article> getAllArticle()
        {
            List<Article> lst = ctx.Articles.ToList();
            if (lst.Count == 0)
            {
                throw new FaultException("Data not found!!!");
            }
            else
            {
                return lst;
            }
        }

        public bool updateArticle(Article a)
        {
            Article ar = ctx.Articles.Where(c => c.ArticleId == a.ArticleId).SingleOrDefault();
            if (ar == null)
            {
                My_Exception.MyFaultException myex = new My_Exception.MyFaultException();
                myex.errorCode = "1003";
                myex.message = "ID does not exist";

                throw new FaultException<My_Exception.MyFaultException>(myex);

            }
            else
            {
                ar.ArticleId = a.ArticleId;
                ar.Content = a.Content;
                ar.ImageArticle = a.ImageArticle;
                ar.Content = a.Content;
                ar.AddDate = a.AddDate;
                ar.Link = a.Link;
                ar.Title = a.Title;
                ar.ViewCount = a.ViewCount;
                ar.StatusArticle = a.StatusArticle;
                ctx.SaveChanges();
                return true;
            }
                return false;
        }
    }
}
