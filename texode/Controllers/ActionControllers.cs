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
        public static DataWarehouse data=new DataWarehouse();
        private readonly string path = @"D:\programmig\C#\texode\texode\data\book.json";
        [GloblaException]
        public ActionControllers(DataWarehouse buff)
        {
            
            
                StreamReader r = new StreamReader(path);
                string json = r.ReadToEnd();
                data.books = JsonConvert.DeserializeObject<List<InformationCard>>(json);
                var test = data.books[0];


            //catch (FileNotFoundException e)
            //{
            //    var response = new HttpResponseMessage(HttpStatusCode.NotFound)
            //    {
            //        Content = new StringContent(string.Format("No file found with name = {0}", path)),
            //        ReasonPhrase = e.Message
            //    };

            //    throw new System.Web.Http.HttpResponseException(response);
            //}
            //catch (NullReferenceException e)
            //{
            //    var response = new HttpResponseMessage(HttpStatusCode.NotFound)
            //    {
            //        Content = new StringContent(string.Format("File doesnt contain object = {0}", 0)),
            //        ReasonPhrase = e.Message
            //    };

            //    throw new System.Web.Http.HttpResponseException(response);
            //}
        }



// GET: api/<Action>
        [HttpGet]
        [Route("GetAllBooks")]
        public List<InformationCard> GetAllBooks()
        {
            // Возвратить все книги
            return data.books;
        }

        // GET api/<Action>/5
        [HttpGet]
        [Route("GetBook")]
        public InformationCard GetBook(int id)
        {
            // Возврат определенной книги
            try
            {
                return data[id];
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            catch(NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            
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

