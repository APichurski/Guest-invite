using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheetList.Models
{
    public class DataBaseConnection
    {
        public static IMongoDatabase DataBase(string connectionString= "mongodb+srv://admin:admin@cluster0-s6j4s.mongodb.net/test?retryWrites=true",string DataBase= "PartyCard")
        {
          
            var client = new MongoClient(connectionString);
            return client.GetDatabase(DataBase);
        }
    }
}
