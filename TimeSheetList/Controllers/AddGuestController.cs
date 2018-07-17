using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using TimeSheetList.Models;

namespace TimeSheetList.Controllers
{
    public class AddGuestController : Controller
    {
        public IMongoDatabase database;
        public AddGuestController()
        {
            database = DataBaseConnection.DataBase();
        }
        public IActionResult Index()
        {
            return View();
        }
        [Route("api/guests/add")]
        [HttpPost]
        public IActionResult RecevingData([FromBody]GuestSender oneguest)
        {

            try
            {

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
    }
}