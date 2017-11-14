using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MvcApplication1.Models;
using System.Collections;

namespace MvcApplication1.Controllers
{
    public class IPAddressController : ApiController
    {

        private static IList<Address> addresses = new List<Address>
        {
            new Address(){ IPAddress="1.91.38.31", Province="北京市", City="北京市" },  
            new Address(){ IPAddress = "210.75.225.254", Province = "上海市", City = "上海市"  },
        };

        public IEnumerable GetIPAddresses()
        {
            return addresses;
        }

        public Address GetIPAddressByIP(string IP)
        {
            return addresses.FirstOrDefault(x => x.IPAddress == IP);
        }


        // GET api/ipaddress
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/ipaddress/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/ipaddress
        public void Post([FromBody]string value)
        {
        }

        // PUT api/ipaddress/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/ipaddress/5
        public void Delete(int id)
        {
        }
    }
}
