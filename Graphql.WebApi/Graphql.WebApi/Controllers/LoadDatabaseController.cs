using Graphql.WebApi.Interfaces.Repositories;
using Graphql.WebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace Graphql.WebApi.Controllers
{
    [ApiController]
    [Route("/[Controller]")]
    public class LoadDatabaseController : Controller
    {
        private readonly IBookRepository _bookRepository;

        public LoadDatabaseController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create()
        {
            var books = LoadDatabase.Register();
            await _bookRepository.Save(books);

            return Ok(true);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            var result = await _bookRepository.Delete();

            return Ok(result);
        }
    }
}