using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace TimeSheetList.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            ViewData["RequestId"] = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            return View();
        }

        [Route("api/1")]
        public IActionResult Test(string name,string surname,int number,bool choice)
        {
            GuestResponse ob1 = new GuestResponse { Id = 300 };
            var client = new MongoClient();
            var database = client.GetDatabase("PartyCard");
            var collection = database.GetCollection<GuestResponse>("NumberOfguest");
            collection.InsertOneAsync(ob1);
            return Ok(ob1);
        }

        
    }
}
