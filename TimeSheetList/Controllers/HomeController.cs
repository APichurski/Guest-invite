using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using TimeSheetList.Models;

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
        public IActionResult Test()
        {


            string connectionString = "mongodb+srv://admin:admin@cluster0-s6j4s.mongodb.net/test?retryWrites=true";


            GuestResponse ob1 = new GuestResponse { Name = "777777777" };
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("PartyCard");
            var collection = database.GetCollection<GuestResponse>("NumberOfguest");
            collection.InsertOneAsync(ob1);
            return Ok(ob1);


        }
        [Route("api/2")]
        [HttpPost]
        public IActionResult RecevingData([FromBody]GuestResponse oneguest)
        {
            var database = DataBaseConnection.DataBase();
            var collection = database.GetCollection<GuestResponse>("NumberOfguest");
            collection.InsertOneAsync(oneguest);
           
            return Ok(oneguest);
        }
        [Route("api/guest/get-all-guest")]
        public async Task<IActionResult> EndpointAllGuest()
        {
            var database = DataBaseConnection.DataBase();
            var collection =database.GetCollection<GuestResponse>("NumberOfguest");
            var AllGuest =  collection.Find(b => true).ToListAsync().Result;
            for(int i=0;i<AllGuest.Capacity;i++)
            {
                AllGuest[i].Id =null;
            }
           
            return Ok(AllGuest);
        }



    }


}













