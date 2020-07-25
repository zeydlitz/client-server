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
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace texode.Controllers
{
    
    
    [Route("api/book")]
    [ApiController]
    public class ActionControllers : ControllerBase
    {
        private ILoggerManager _logger;
        public static DataWarehouse data=new DataWarehouse();
        private readonly string path = @"D:\programmig\C#\texode\texode\data\book.json";

        public ActionControllers(DataWarehouse buff, ILoggerManager logger)
        {
            _logger = logger;

            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                data.books = JsonConvert.DeserializeObject<List<InformationCard>>(json);
            }
        }



// GET: api/<Action>
        [HttpGet]
        [Route("GetAllBooks")]
        public List<InformationCard> GetAllBooks()
        {
            // Возвратить все книги
            throw new Exception("Exception");
            return data.books;
        }

        // GET api/<Action>/5
        [HttpGet]
        [Route("GetBook")]
        public InformationCard GetBook(int id)
        {
            // Возврат определенной книги
   
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
        public List<InformationCard> SaveNewUser([FromQuery] InformationCard book)
        {
            //Добавить книгу
            data.books.Add(book);
            return data.books;
        }

        // PUT api/<Action>/5
        [HttpPut("{id}")]
        [Route("UpdateBook")]
        public List<InformationCard> UpdateUser(int id, [FromQuery] InformationCard book)
        {
            // Обновить книгу
            data[id] = book;
            return data.books;
        }

        // DELETE api/<Action>/5
        [HttpDelete("{id}")]
        [Route("DeleteBook")]
        public List<InformationCard> DeleteUser(int id)
        {
            // Delete user at position id
            data.books.RemoveAt(id);
            return data.books;
        }
    }
}

