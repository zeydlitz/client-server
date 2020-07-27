using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Web.Http;
using baseIC;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace texode.Controllers
{
    
    
    [Route("api/book")]
    [ApiController]
    public class ActionControllers : ControllerBase
    {
        private ILoggerManager _logger;
        public static DataWarehouse<InformationCard> data=new DataWarehouse<InformationCard>();
        public static List<InformationCard> deep_copy=new List<InformationCard>();
        private readonly string path = @"data\\book.json";
        public ActionControllers(DataWarehouse<InformationCard> buff, ILoggerManager logger)
        {
            _logger = logger;

            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                if (data.books==null)
                {
                    data.books = JsonConvert.DeserializeObject<List<InformationCard>>(json);
                    for (int i = 0; i < data.books.Count; i++)
                    {
                        //data.books[i].SetImarray();
                        deep_copy.Add(data.books[i]);
                    }
                    foreach (var variable in data.books)
                    {
                        variable.SetImarray();
                    }
                }

                if (deep_copy.Count == 0)
                {
                    deep_copy = data.books;
                }

                
            }
            
        }



// GET: api/<Action>
        [HttpGet]
        [Route("GetAllBooks")]
        public List<InformationCard> GetAllBooks()
        {
            _logger.LogInfo("return All books");
            // Возвратить все книги
            //foreach (var buff in data.books)
            //{
            //    buff.SetImarray();
            //}
            return data.books;
        }

        // GET api/<Action>/5
        [HttpGet]
        [Route("GetBook")]
        public InformationCard GetBook(int id)
        {
            _logger.LogInfo($"return books with id={id}");
            deep_copy.Add(data[id]);
            return data[id];
            
            //catch (ArgumentOutOfRangeException e)
            //{
            //    Console.WriteLine(e.Message);
            //    throw;
            //}
            //catch(NullReferenceException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //    throw;
            //}
            
        }

        // POST api/<Action>
        [HttpPost]
        [Route("SaveNewBook")]
        //public List<InformationCard> SaveNewUser([FromQuery] string name ,string path)
        //{
        //    _logger.LogInfo("Save book");
        //    //Добавить книгу
        //    data.books.Add(new InformationCard(name,path));
        //    return data.books;
        //}

        // PUT api/<Action>/5
        [Route("UpdateBook")]
        public List<InformationCard> UpdateUser(int id, [FromQuery] string name, string path)
        {
            _logger.LogInfo($"update book with id={id}");
            // Обновить книгу
            data[id] = new InformationCard(name,path);
            return data.books;
        }

        // DELETE api/<Action>/5
        [Route("DeleteBook")]
        public List<InformationCard> DeleteUser(int id)
        {
            _logger.LogInfo($"delete book with id={id}");
            // Delete user at position id
            deep_copy.RemoveAt(id);
            
            //foreach (var buff in buff.books)
            //{
            //    buff.SetImarray();
            //}
            return deep_copy;
        }
    }
}

