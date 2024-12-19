
using Microsoft.AspNetCore.Mvc;
using ProjectHonor1.Dtos.FeedbackDtos;
using ProjectHonor1.Dtos.GetFeedbackDtos;
using ProjectHonor1.Repositories.GetFeedbackDtos;
using System.Data.SqlTypes;


namespace ProjectHonor1.Controllers.FeedbackController
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackRepository _feedbackRepository;
        public FeedbackController(IFeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }

        //GET: api/feedback
        [HttpGet]
        public async Task<IActionResult> GetAllfeedbacks()
        {
            var feedbacks = await _feedbackRepository.GetAllAsync();
            if (feedbacks == null || !feedbacks.Any())
            {
                return NotFound(); //feedback yoksa 404
            }
            return Ok(feedbacks); //varsa 200ok ve feedbackleri döndür
        }

        //GET: api/feedback/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeedbackById(int id)
        {
            var feedback = await _feedbackRepository.GetByIdAsync(id);
            if ( feedback == null)
            {
                return NotFound();
            }
            return Ok(feedback);
        }

        //POST: api/feedback
        [HttpPost]
        public async Task<IActionResult> AddFeedback([FromBody] GetFeedbackDto feedback)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _feedbackRepository.AddAsync(feedback);
            return CreatedAtAction(nameof(GetFeedbackById), new { id = feedback.Id }, feedback); //201 Created
        }

        //PUT:api/feedback/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFeedback(int id, [FromBody] GetFeedbackDto feedback)
        {
            if (!ModelState.IsValid)
            { 
                return BadRequest(ModelState); //400 bad request
            }

            var existingFeedback = await _feedbackRepository.GetByIdAsync(id);
            if (existingFeedback == null)
            {
                return NotFound();
            }

            await _feedbackRepository.UpdateAsync(id, feedback);
            return NoContent();

        }

        //DELETE: api/feedback/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeedback(int id)
        {
            var existingFeedback = await _feedbackRepository.GetByIdAsync(id);
            if (existingFeedback == null)
            {
                return NotFound(); //404
            }

            await _feedbackRepository.DeleteAsync(id);

            return NoContent(); //204 No content 
        }
    }
}
