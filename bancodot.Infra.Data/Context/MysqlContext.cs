using bancodot.Domain;
using bancodot.Domain.Entities;
using bancodot.Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;


namespace bancodot.Infra.Data.Context
{
   public class MysqlContext : DbContext
    {
       
        public MysqlContext(DbContextOptions<MysqlContext> options) : base(options)
        {
           
        }
       

        public DbSet<User> Users { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Agency> Agency { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Account> Accounts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(new UserMap().Configure);
            modelBuilder.Entity<Agency>(new AgencyMap().Configure);
            modelBuilder.Entity<Address>(new AddressMap().Configure);
            modelBuilder.Entity<Client>(new ClientMap().Configure);
            modelBuilder.Entity<Agency>(new AgencyMap().Configure);
            modelBuilder.Entity<Employee>(new EmployeeMap().Configure);
            modelBuilder.Entity<Account>(new AccountMap().Configure);
        }
    }

    }

