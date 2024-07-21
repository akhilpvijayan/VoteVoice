using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PollService.Business.Services;
using PollService.Business.Services.Dto;

namespace PollService.Controllers
{
    [Route("poll")]
    public class PollController : Controller
    {
        #region properties
        private readonly IPollService _pollService;
        #endregion

        #region constructor
        public PollController(IPollService pollService)
        {
            this._pollService = pollService;
        }
        #endregion

        [HttpGet]
        public async Task<IActionResult> GetAllPolls([FromQuery] int skip, [FromQuery] int take)
        {
            try
            {
                var polls = await _pollService.GetAllPolls(skip, take);
                if(polls == null)
                {
                    return NotFound();
                }
                return Ok(polls);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Authorize]
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetAllPollsByUser([FromQuery] int skip, [FromQuery] int take, long userId)
        {
            try
            {
                var polls = await _pollService.GetAllPolls(skip, take, userId);
                if (polls == null)
                {
                    return NotFound();
                }
                return Ok(polls);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Authorize]
        [HttpGet("{pollId}")]
        public async Task<IActionResult> GetPoll(long pollId)
        {
            try
            {
                var poll = await _pollService.GetPoll(pollId);
                return Ok(poll);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddPoll([FromForm] AddPollOptionsDto pollDetails)
        {
            try
            {
                if (pollDetails != null)
                {
                    var result = await _pollService.AddPoll(pollDetails);
                    if (result != null)
                    {
                        return Ok(new
                        {
                            Message = "Poll Creation Success.",
                            PollId = result,
                        });
                    };
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Authorize]
        [HttpPut("{pollId}")]
        public async Task<IActionResult> UpdatePoll([FromForm] AddPollOptionsDto pollDetails, long pollId)
        {
            try
            {
                if (pollDetails != null)
                {
                    var result = await _pollService.UpdatePoll(pollDetails, pollId);
                    if (result != null)
                    {
                        return Ok(new
                        {
                            Message = "Poll Updated Successfully.",
                            PollId = result,
                        });
                    };
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Authorize]
        [HttpDelete("{pollId}")]
        public async Task<IActionResult> DeletePoll(long pollId)
        {
            try
            {
                var result = await _pollService.DeletePoll(pollId);
                if (result != null)
                {
                    return Ok(new
                    {
                        Message = "Poll Deletion Success.",
                        PollId = result,
                    });
                };
                return BadRequest();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Authorize]
        [HttpDelete("{pollId}/polloption/{pollOptionId}")]
        public async Task<IActionResult> DeletePollOption(long pollId, long pollOptionId)
        {
            try
            {
                var result = await _pollService.DeletePollOption(pollId, pollOptionId);
                if (result != null)
                {
                    return Ok(new
                    {
                        Message = "Poll Deletion Success.",
                        PollId = result,
                    });
                };
                return BadRequest();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Authorize]
        [HttpGet("polloption/{pollOptionId}")]
        public async Task<IActionResult> ValidatePollOption(long pollOptionId)
        {
            var result = await _pollService.ValidatePollOption(pollOptionId);
            if (!result)
            {
                return NotFound();
            }

            return Ok();
        }

        [Authorize]
        [HttpPut("polloption/{pollOptionId}/{isAdd}")]
        public async Task<IActionResult> UpdateVoteCount(long pollOptionId, bool isAdd)
        {
            var result = await _pollService.UpdateVoteCount(pollOptionId, isAdd);
            if (!result)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
