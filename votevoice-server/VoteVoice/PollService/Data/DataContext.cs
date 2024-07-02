using Microsoft.EntityFrameworkCore;
using PollService.Business.Services.Dto;
using PollService.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace PollService.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Poll> Polls { get; set; }
        public DbSet<PollOptions> PollOptions { get; set; }

        public DbSet<PollDetailsDto> PollDetailsDto { get; set; }
        public DbSet<AddPollOptionsDto> AddPollOptionsDto { get; set; }
        public DbSet<PollOptionsDetailDto> PollOptionsDetailDto { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PollDetailsDto>().ToView(null);
            modelBuilder.Entity<AddPollOptionsDto>().ToView(null);
            modelBuilder.Entity<PollOptionsDetailDto>().ToView(null);
        }
    }
}
