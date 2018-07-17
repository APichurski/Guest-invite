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
        public async Task<IActionResult> SearchData([FromQuery]GuestSender guest)
        {

            var database = DataBaseConnection.DataBase();
            var collection = database.GetCollection<GuestResponse>("NumberOfguest");
           

            var filter = Builders<GuestResponse>.Filter.Eq("Name",guest.Name);
            var AllGuest = collection.Find(filter).ToListAsync().Result;
            for (int i = 0; i < AllGuest.Count; i++)
            {
                AllGuest[i].Id = null;
            }
            return Ok(AllGuest);


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
            
            try
            {
                var database = DataBaseConnection.DataBase();
                var collection = database.GetCollection<GuestSender>("NumberOfguest");
                collection.InsertOne(oneguest);

                return Ok("Successfully add into database");
            }
            catch (ArgumentNullException ex)
            {
                return Ok(ex.Message);
            }
            catch (Exception ex)
            {
                return Ok("Unhandled exception");
            }
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













