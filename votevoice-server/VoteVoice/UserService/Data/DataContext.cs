using Microsoft.EntityFrameworkCore;
using UserService.Business.Services.Dto;
using UserService.Models;

namespace UserService.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<UserDetails> UserDetails { get; set; }
        public DbSet<Countries> Countries { get; set; }
        public DbSet<States> States { get; set; }
        public DbSet<Users> Users { get; set; }

        public DbSet<UserDetailDto> UserDetailDto { get; set; }
        public DbSet<SignUpUserDetailsDto> SignUpUserDetailsDto { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserDetailDto>().ToView(null);
            modelBuilder.Entity<SignUpUserDetailsDto>().ToView(null);
        }
     }
}