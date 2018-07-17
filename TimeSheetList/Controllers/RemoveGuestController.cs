using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using TimeSheetList.Models;

namespace TimeSheetList.Controllers
{
    public class RemoveGuestController : Controller
    {
        public IMongoDatabase database;
        public RemoveGuestController()
        {
            database = DataBaseConnection.DataBase();
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [Route("api/guests/remove")]
        public IActionResult DeleteData([FromBody]GuestSender guest)
        {
            try
            {

                var collection = database.GetCollection<GuestSender>("NumberOfguest");
                var filter = Builders<GuestSender>.Filter.Eq("Name", guest.Name);
                var result = collection.DeleteOne(filter);
                return Ok(result);
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
    }
}