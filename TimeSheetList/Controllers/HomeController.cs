using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using TimeSheetList.Models;
using MongoDB.Bson.Serialization.Attributes;

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

        [Route("add")]
        public IActionResult Add(GuestResponse guest)
        {
           

            string connectionString = "mongodb+srv://admin:admin@cluster0-s6j4s.mongodb.net/test?retryWrites=true";


            GuestResponse ob1 = new GuestResponse();
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("PartyCard");
            var collection = database.GetCollection<GuestResponse>("NumberOfguest");
            collection.InsertOneAsync(ob1);
            return Ok(ob1);


            

        }


        [Route("search")]
        public IActionResult Search(string _imie)
        {


            string connectionString = "mongodb+srv://admin:admin@cluster0-s6j4s.mongodb.net/test?retryWrites=true";
            _imie = "Kamil";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("PartyCard");
            var collection = database.GetCollection<GuestResponse>("NumberOfguest");
                        
            var builder = Builders<GuestResponse>.Filter;
            var filter = builder.Eq("Name", _imie);
            var result = collection.Find(filter).ToList();


            return Ok(result);

        }



        //[Route("delete")]
        //public IActionResult Delete(string Name,string Surname,int Phone,bool WillAttend)
        //{


        //    string connectionString = "mongodb+srv://admin:admin@cluster0-s6j4s.mongodb.net/test?retryWrites=true";

        //    var client = new MongoClient(connectionString);
        //    var database = client.GetDatabase("PartyCard");
        //    var collection = database.GetCollection<BsonDocument>("NumberOfguest");

        //    var builder = Builders<BsonDocument>.Filter;
        //    var filter = Builders<BsonDocument>.Filter.Eq(builder.Eq("Name", Name), builder.Eq("Surname",Surname), builder.Eq("Phone",Phone), builder.Eq("WillAttend",WillAttend));
        //    var result = collection.DeleteMany(filter);


        //    return Ok(result);

        //}
    }

        
        
 }

