using Microsoft.AspNetCore.Mvc;
using ProjectHonor1.Dtos.GetStatusDtos;
using ProjectHonor1.Repositories.GetStatusDtos;

namespace ProjectHonor1.Controllers.FeedbackController
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly IStatusRepository _statusRepository;
        public StatusController(IStatusRepository statusRepository)
        {
            _statusRepository=statusRepository;
        }

        //GET: api/status
        [HttpGet]
        public async Task<ActionResult>GetAllStasuses()
        {
            var statuses = await _statusRepository.GetAllAsync();
            return Ok(statuses);    
        }

        //GET: api/status/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<GetStatusDto>> GetStatusById(int id)
        {
            var status = await _statusRepository.GetByIdAsync(id);
            if (status == null)
            {
                return NotFound();
            }
            return Ok(status);  
        }

        //POST: api/status
        [HttpPost]
        public async Task<ActionResult> AddStatus([FromBody] GetStatusDto statusDto)
        {
            await _statusRepository.AddAsync(statusDto);
            return CreatedAtAction(nameof(GetStatusById), new {id = statusDto.Id}, statusDto);
        }

        //PUT: api/status/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateStatus(int id, [FromBody] GetStatusDto statusDto)
        {
            await _statusRepository.UpdateAsync(id , statusDto);
            return NoContent();
        }

        //DELETE: api/status/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteStatus(int id )
        {
            await _statusRepository.DeleteAsync(id);
            return NoContent() ;
        }



    }
}
