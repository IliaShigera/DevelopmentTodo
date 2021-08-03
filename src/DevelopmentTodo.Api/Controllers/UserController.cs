using System.Threading.Tasks;
using DevelopmentTodo.Api.Controllers.Common;
using Microsoft.AspNetCore.Mvc;

namespace DevelopmentTodo.Api.Controllers
{
    public class UserController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Edit(int id)
        {
            return NoContent();
        }

        [HttpPost("{providerId}/{developerId}")]
        public async Task<ActionResult> CreateTask(int providerId, int developerId)
        {
            return NoContent();
        }
    }
}
