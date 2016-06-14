using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

using MongoDB.Driver;
using MongoDB.Bson;
using InventoryService.Models;
using MongoDB.Driver.Linq;

namespace InventoryService.Controllers
{
    public class ServerController : Controller
    {
        protected static IMongoClient _client;
        protected static IMongoDatabase _database;
        public Col_Servers[] server { get; set; }

        // GET: Server
        public async System.Threading.Tasks.Task<ActionResult> Index()
        {
            ServerList serverList = new ServerList();
            serverList._serverList = new List<Col_Servers>();


            _client = new MongoClient();
            _database = _client.GetDatabase("Inventory");

            var collection = _database.GetCollection<Col_Servers>("col_servers");


            var filter = new BsonDocument();
            var count = 0;
            using (var cursor = await collection.FindAsync(filter))
            {
                while (await cursor.MoveNextAsync())
                {
                    var batch = cursor.Current;
                    foreach (var document in batch)
                    {
                        serverList._serverList.Add(document);
                        count++;
                    }
                }
            }

            return View(serverList);
        }
        
        public ActionResult AddHost()
        {
            return View("AddHost");
        }

        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> CreateHost(Col_Servers server)
        {
            if (ModelState.IsValid)
            {
                var collection = _database.GetCollection<Col_Servers>("col_servers");
                await collection.InsertOneAsync(server);                
                return RedirectToAction("Index");                              
            }
            return RedirectToAction("AddHost");
        }

        public ActionResult AddVM(string _serverId)
        {
            Col_Servers server = new Col_Servers();                    
            var collection = _database.GetCollection<Col_Servers>("col_servers");

            //_serverId="570f1f3c25ff536a72584528";
            var query = 
                from e in collection.AsQueryable<Col_Servers>()
                where e._id == _serverId
                select e;            

            foreach (var item in query)
                {
                    server = item;
                }            
            return View("AddVM", server);
        }

        [HttpPost]
        public ActionResult CreateVM(Col_Servers _server)
        {

            return RedirectToAction("Index");
        }

        public ActionResult AddHDD(string _serverId)
        {
            Col_Servers server = new Col_Servers();
            var collection = _database.GetCollection<Col_Servers>("col_servers");

            //_serverId="570f1f3c25ff536a72584528";
            var query =
                from e in collection.AsQueryable<Col_Servers>()
                where e._id == _serverId
                select e;

            foreach (var item in query)
            {
                server = item;
            }
           
            return View("AddHDD",server);
        }

        [HttpPost]
        public ActionResult CreateHDD(Col_Servers server)
        {
            return RedirectToAction("Index");
        }

        // GET: Server/Details/5
        public ActionResult Details(int id)
        {
            return View("Index");
        }

        // GET: Server/Create
        public ActionResult Create()
        {

            return View("AddHost");
        }

        // POST: Server/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Server/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Server/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Server/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Server/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
