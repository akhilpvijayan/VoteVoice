﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using VoteService.Models;

namespace VoteService.Business.Services.Dto
{
    [Keyless]
    public class PollDetailsDto : BaseEntity
    {
        public long PollId { get; set; }
        public long UserId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfileImage { get; set; }
        public DateTime ExpiryDate { get; set; }
        public long TotalVotes { get; set; }
    }
}
