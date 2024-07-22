using Assignment04part3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment04part3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookStoreController : ControllerBase
    {
        private static BooksDataReturn bdr = new BooksDataReturn();

        [HttpGet]
        public ActionResult<List<OnlineBookStore>> GetData()
        {
            return Ok(bdr.GetAllData());
        }

        [HttpGet("{id}")]
        public OnlineBookStore GetBooksById(int id)
        {
            return bdr.GetDataById(id);
        }

        [HttpPost]
        public ActionResult AddNewBook(OnlineBookStore newbook)
        {
            bdr.AddBooks(newbook);
            return Ok();
        }

        [HttpPut]
        public void UpdatBookData(int id, string updateTitle, string updateAuthor, string updateDescription)
        {
            bdr.UpdateBooks(id,updateTitle,updateAuthor,updateDescription);
        }

        [HttpDelete]
        public void DeleteData(int id)
        {
            bdr.DeleteDataById(id);
        }

        [HttpGet("author/{author}")]
        public OnlineBookStore GetBooksByAuthor(string author)
        {
            return bdr.GetDataByAuthor(author);
        }

    }
}
