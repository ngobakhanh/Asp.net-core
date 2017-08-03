using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Syndication;
using System.Text;
using WcfServiceLibrary_EnotsCompany.DAL;

namespace WcfServiceLibrary_EnotsCompany.Module_RSS
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RSSService" in both code and config file together.
    public class RSSService : IRSSService
    {
        B2BEntities ctx = new B2BEntities();
        public Rss20FeedFormatter ViewProducts()
        {
            List<Item> lst = ctx.Items.ToList();

            SyndicationFeed feed = new SyndicationFeed("Title - New Products", "Desc - san pham moi", new Uri("http://www.enotscompany.com.vn/newproducts"));
            List<SyndicationItem> items = new List<SyndicationItem>();
            foreach (Item item in lst)
            {
                SyndicationItem it = new SyndicationItem(item.ItemName, item.ItemName, new Uri("http://www.enotscompany.com.vn/newproducts"), "" + item.ItemId, DateTime.Now);
                items.Add(it);
            }

            feed.Items = items;

            return new Rss20FeedFormatter(feed);
        }
    }
}
