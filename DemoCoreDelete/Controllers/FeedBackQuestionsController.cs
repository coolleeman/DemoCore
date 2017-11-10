using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DemoCoreDelete.Data;

namespace DemoCoreDelete.Controllers
{
    [Produces("application/json")]
    [Route("api/FeedBackQuestions")]
    public class FeedBackQuestionsController : ControllerBase
    {
        private readonly LincContext _context;

        public FeedBackQuestionsController(LincContext context)
        {
            _context = context;
        }

        // GET: api/FeedBackQuestions
        [HttpGet("cultureCode=en-CA")]
        public IEnumerable<FeedBackQuestion> GetFeedBackQuestions(string cultureCode)
        {
            var feedbackQuestions = new List<FeedBackQuestion>();
            
            var qResults =
                _context.CodeDisplays.Where(cd => cd.Code.CodeTypeId == 2 && cd.Language.Code == cultureCode).OrderBy(cd=>cd.Code.DisplayOrder).ToList();

            foreach (var result in qResults)
            {
                
            }


            return feedbackQuestions;
        }

        // GET: api/FeedBackQuestions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeedBackQuestion([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var feedBackQuestion = await _context.FeedBackQuestions.SingleOrDefaultAsync(m => m.Id == id);

            if (feedBackQuestion == null)
            {
                return NotFound();
            }

            return Ok(feedBackQuestion);
        }

        // PUT: api/FeedBackQuestions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFeedBackQuestion([FromRoute] long id, [FromBody] FeedBackQuestion feedBackQuestion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != feedBackQuestion.Id)
            {
                return BadRequest();
            }

            _context.Entry(feedBackQuestion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeedBackQuestionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/FeedBackQuestions
        [HttpPost]
        public async Task<IActionResult> PostFeedBackQuestion([FromBody] FeedBackQuestion feedBackQuestion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.FeedBackQuestions.Add(feedBackQuestion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFeedBackQuestion", new { id = feedBackQuestion.Id }, feedBackQuestion);
        }

        // DELETE: api/FeedBackQuestions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeedBackQuestion([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var feedBackQuestion = await _context.FeedBackQuestions.SingleOrDefaultAsync(m => m.Id == id);
            if (feedBackQuestion == null)
            {
                return NotFound();
            }

            _context.FeedBackQuestions.Remove(feedBackQuestion);
            await _context.SaveChangesAsync();

            return Ok(feedBackQuestion);
        }

        private bool FeedBackQuestionExists(long id)
        {
            return _context.FeedBackQuestions.Any(e => e.Id == id);
        }
    }
}