using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using OrderItemWebApplication.Models;
using Newtonsoft.Json;

namespace OrderItemWebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult GetCartBy(int id)
        {

            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("http://localhost:7733/");
                var responseTask = client.GetAsync("MenuItem");
                responseTask.Wait();
                var result = responseTask.Result;


                


                if (result.IsSuccessStatusCode)
                {
                    List<Cart> Items = new List<Cart>();

                    string jsonData = result.Content.ReadAsStringAsync().Result;


                    Items = JsonConvert.DeserializeObject<List<Cart>>(jsonData);
                    Cart obj = Items.SingleOrDefault(item => item.Id == id);
                    
                    obj.UserId = 1;

                  
                   


                   return Ok(obj);

                }
                else
                {

                    return BadRequest();

                }

            }



        }





    }
}
