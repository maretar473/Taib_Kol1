using Microsoft.AspNetCore.Mvc;
using MT_Kol_Term_1.BLL;
using MT_Kol_Term_1.DTO;
using MT_Kol_Term_1.Model;

namespace MT_Kol_Term_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MiceController : ControllerBase
    {
        private readonly IMouseService _mouseService = new MouseService();

        [HttpGet]
        public ActionResult<IEnumerable<MouseResponseDTO>> Get()
        {
            try
            {
                var mice = _mouseService.GetMice();
                return Ok(mice);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<MouseResponseDTO> Get(int id)
        {
            try
            {
                var mouse = _mouseService.GetMouse(id);
                return Ok(mouse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _mouseService.DeleteMouse(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] MouseRequestDTO mouseRequestDTO)
        {
            try
            {
                _mouseService.PutMouse(id, mouseRequestDTO);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] MouseRequestDTO mouseRequestDTO)
        {
            try
            {
                _mouseService.PostMouse(mouseRequestDTO);
                return CreatedAtAction(nameof(Get), new { id = mouseRequestDTO }, mouseRequestDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
