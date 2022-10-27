using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace GatewayAPI.Controllers
{
    public class APIGatewayController : ControllerBase
    {
        [HttpPost]
        [Route("~/apigateaway/GetState")]
        public IActionResult GetState() 
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:60903/");
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var data = "test=something";
                StringContent queryString = new StringContent(data);
                HttpResponseMessage response = client.PostAsync("api/State/StateList", queryString).Result;
                if (response.IsSuccessStatusCode)
                {
                    return Ok(response.Content.ReadAsStringAsync().Result);
                }
                else
                {
                    return BadRequest("Something went wrong in request please check Uri");
                }
            }
            catch(Exception ex)
            {
                return Ok(ex.Message);
            }
        }

    }
}
