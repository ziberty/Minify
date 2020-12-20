using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Minify.Model;

namespace Minify.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MinifyController : ControllerBase
    {
        [HttpPost]
        public string Add([FromBody] MinifyData data)
        {
            data = new MinifyData
            {
                Key = "",
                Url = "https://www."+data.Url
            };
            new Repository().Add(data);
            return data.Url;
        }

        [HttpGet]
        public IEnumerable<MinifyData> Get()
        {
            return new Repository().Get();
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            new Repository().Delete(id);
        }
    }
}