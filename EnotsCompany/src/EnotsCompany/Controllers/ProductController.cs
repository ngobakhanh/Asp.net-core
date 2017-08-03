using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServiceReference_Item;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace EnotsCompany.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        ItemServiceClient itm = new ItemServiceClient();
        // GET: api/values
        [HttpGet]
        public async Task<JsonResult> Get()
        {
            var lst_item = (await itm.getAllItemAsync()).OrderByDescending(i=>i.AddedDate).Take(10);
            return Json(lst_item);
        }


        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<JsonResult> Get(int id)
        {
            var item = await itm.findItembyIdAsync(id);
            return Json(item);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
