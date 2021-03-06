﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RpcClient;

namespace ExposeAPIWithEndpointsCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            try
            {
                RPCClient rpcClient = new RPCClient();

                Console.WriteLine(" [x] Requesting fib({0})", id);
                var response = rpcClient.Call(id.ToString());
                Console.WriteLine(" [.] Got '{0}'", response);

                rpcClient.Close();
                return response;
            }
            catch
            {
                return "404 error";
            }
        }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class HeartBeatController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}