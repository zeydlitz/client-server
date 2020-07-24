using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace texode.Controllers
{
    public class InformationCard
    {
        public string name;
        public string path;

        InformationCard()
        {
            name = "Swift";
            path = "book\\Swift.jpg";
        }
        InformationCard(string name, string path)
        {
            this.name = name;
            this.path = path;
        }
    }

    [Route("api / Book")]
    [ApiController]
    public class Action : ControllerBase
    {
        private readonly string path = @"D:\programmig\C#\texode\texode\data\book.json";
        public Action()
        {
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                Books = JsonConvert.DeserializeObject<List<InformationCard>>(json);


                //foreach (var item in items)
                //{
                //    Console.WriteLine("{0} {1}", item.name, item.path);
                //}

            }

        }

        public static List<InformationCard> Books;
        // GET: api/<Action>
        [HttpGet]
        [Route("GetAllBooks")]
        public List<InformationCard> GetAllBooks()
        {
            // Возвратить все книги 
            return Books;
        }

        // GET api/<Action>/5
        [HttpGet("{id}")]
        [Route("GetBook")]
        public InformationCard GetBook(int id)
        {
            // Возврат определенной книги
            return Books[id];
        }

        // POST api/<Action>
        [HttpPost]
        [Route("SaveNewBook")]
        public List<InformationCard> SaveNewUser([FromQuery] InformationCard book)
        {
            //Добавить книгу
            Books.Add(book);
            return Books;
        }

        // PUT api/<Action>/5
        [HttpPut("{id}")]
        [Route("UpdateBook")]
        public List<InformationCard> UpdateUser(int id, [FromQuery] InformationCard book)
        {
            // Обновить книгу
            Books[id] = book;
            return Books;
        }

        // DELETE api/<Action>/5
        [HttpDelete("{id}")]
        [Route("DeleteBook")]
        public List<InformationCard> DeleteUser(int id)
        {
            // Delete user at position id
            Books.RemoveAt(id);
            return Books;
        }
    }
}

