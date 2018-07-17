using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using TimeSheetList.Models;

namespace TimeSheetList.Controllers
{
    public class GetGuestController : Controller
    {
        public IMongoDatabase database;
        public GetGuestController()
        {
            database = DataBaseConnection.DataBase();
        }
        public IActionResult Index()
        {
            return View();
        }
        [Route("api/guest/get-all-guest")]
        public async Task<IActionResult> EndpointAllGuest()
        {

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