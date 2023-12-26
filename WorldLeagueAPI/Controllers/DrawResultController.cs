using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WorldLeagueAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrawResultController : ControllerBase
    {
        private IDrawResultService _drawResultService;

        public DrawResultController(IDrawResultService drawResultService)
        {
            _drawResultService = drawResultService;
        }
        [HttpPost(template: "drawresultadd")]
        public async Task<IActionResult> DrawResult(string name, string surname)
        {
            var result = await _drawResultService.DrawResult(name, surname);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }
        [HttpGet(template: "getall")]
        public IActionResult GetList()
        {
            var result = _drawResultService.GroupGetList();
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }
    }
}
