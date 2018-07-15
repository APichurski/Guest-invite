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
        public async Task<IActionResult> SearchData(string _name)
        {
           

            string connectionString = "mongodb+srv://admin:admin@cluster0-s6j4s.mongodb.net/test?retryWrites=true";


            
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("PartyCard");
            var collection = database.GetCollection<GuestResponse>("NumberOfguest");
           

            var filter = Builders<GuestResponse>.Filter.Eq("Name", _name);
            var list = await collection.Find(new BsonDocument()).ToListAsync();
            return Ok(list);


         }
        [HttpPost]
        [Route("api/guests/remove")]
        public IActionResult DeleteData([FromBody]GuestSender guest)
        {
           
                var database = DataBaseConnection.DataBase();
                var collection = database.GetCollection<GuestSender>("NumberOfguest");
                var filter = Builders<GuestSender>.Filter.Eq("Name", guest.Name);
                var result = collection.DeleteOne(filter);
              
                return Ok(result);
            

        }
        [Route("api/2")]
        [HttpPost]
        public IActionResult RecevingData([FromBody]GuestSender oneguest)
        {
            var database = DataBaseConnection.DataBase();
            var collection = database.GetCollection<GuestSender>("NumberOfguest");
            collection.InsertOne(oneguest);
           
            return Ok(oneguest);
        }


        [Route("api/guest/get-all-guest")]
        public async Task<IActionResult> EndpointAllGuest()
        {
            var database = DataBaseConnection.DataBase();
            var collection = database.GetCollection<GuestResponse>("NumberOfguest");
            var AllGuest = collection.Find(b => true).ToListAsync().Result;
           


            for (int i = 0; i < AllGuest.Count; i++)
            {
                AllGuest[i].Id = null;
            }

            return Ok(AllGuest);
        }



    }


}













