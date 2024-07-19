using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VoteService.Business.Services;
using VoteService.Models;

namespace VoteService.Controllers
{
    [Route("vote")]
    public class VoteController : Controller
    {
        #region properties
        private readonly IVoteService _voteService;
        #endregion

        #region constructor
        public VoteController(IVoteService voteService)
        {
            this._voteService = voteService;
        }

        #endregion

        [HttpGet("{pollOptionId}")]
        public async Task<IActionResult> GetVotesCount(long pollOptionId)
        {
            try
            {
                var result = await _voteService.GetVotesCount(pollOptionId);
                if (result != null)
                {
                    return Ok(new
                    {
                        TotalCount = result
                    }); ;
                };
                return BadRequest();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult>  AddVote([FromForm] Vote voteDetails)
        {
            try
            {
                var result = await _voteService.AddVote(voteDetails);
                if (result != null)
                {
                    return Ok(new
                    {
                        Message = "Vote Added Successfully.",
                        PollId = result,
                    });
                };
                return BadRequest();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("poll")]
        public async Task<IActionResult> DeleteVotesByPollIds([FromBody] List<long> pollIds)
        {
            var result = await _voteService.DeleteVotesByPollIds(pollIds);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("polloption/{pollOptionId}")]
        public async Task<IActionResult> DeleteVotesByPollOptionIds(long pollOptionId)
        {
            var result = await _voteService.DeleteVoteByPollOptionId(pollOptionId);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
