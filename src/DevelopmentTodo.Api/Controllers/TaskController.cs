using System.Threading.Tasks;
using DevelopmentTodo.Api.Controllers.Common;
using Microsoft.AspNetCore.Mvc;

namespace DevelopmentTodo.Api.Controllers
{
    public class TaskController : BaseApiController
    {
        [HttpGet("{providerId}")]
        public async Task<ActionResult> GetAllFoProvider(int providerId)
        {
            return NoContent();
        }

        [HttpGet("{developerId}")]
        public async Task<ActionResult> GetAllForDeveloper(int developerId)
        {
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Edit(int id)
        {
            return NoContent();
        }

        [HttpPost("{id}")]
        public async Task<ActionResult> EditStatus(int id)
        {
            return NoContent();
        }

        [HttpPost("{id}")]
        public async Task<ActionResult> ChangeDeveloper(int id)
        {
            return NoContent();
        }
    }
}
