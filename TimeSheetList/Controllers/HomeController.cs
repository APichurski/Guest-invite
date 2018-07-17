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
        public IMongoDatabase database;
        public HomeController()
        {
            database=DataBaseConnection.DataBase();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            ViewData["RequestId"] = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            return View();
        }
        
        
        



    }


}













