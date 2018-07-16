using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using TimeSheetList.Models;

namespace TimeSheetList.Controllers
{
    public class SearchGuestController : Controller
    {
        public IMongoDatabase database;
        public SearchGuestController()
        {
            database = DataBaseConnection.DataBase();
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("api/guest")]
        public async Task<IActionResult> SearchData([FromQuery]string find)
        {
            var collection = database.GetCollection<GuestResponse>("NumberOfguest");
            var filter = Builders<GuestResponse>.Filter.Eq("Name", find);
            var AllGuest = await collection.Find(filter).ToListAsync();
            for (int i = 0; i < AllGuest.Count; i++)
                AllGuest[i].Id = null;

            return Ok(AllGuest);

        }
    }
}