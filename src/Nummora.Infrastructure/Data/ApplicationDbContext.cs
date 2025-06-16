using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Nummora.Domain.Entities;

namespace Nummora.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<UserDocument> UserDocuments { get; set; }
    public DbSet<UserWallet> UserWallets { get; set; }
    public DbSet<Loan> Loans { get; set; }
    public DbSet<LoanContract> LoanContracts { get; set; }
    public DbSet<LoanFinancialDetail> LoanFinancialDetails { get; set; }
    public DbSet<LoanParticipation> LoanParticipations { get; set; }
    public DbSet<Lender> Lenders { get; set; }
    public DbSet<Debtor> Debtors { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<Role> Roles { get; set; }
    
    public DbSet<UserToken> UserTokens { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base  (options)
    {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //User Entity
        modelBuilder.Entity<User>()
            .HasMany(ud => ud.UserDocuments)
            .WithOne(ud => ud.User)
            .HasForeignKey(ud => ud.UserId);
        
        modelBuilder.Entity<User>()
            .HasMany(l => l.Lenders)
            .WithOne(l => l.User)
            .HasForeignKey(l => l.UserId);
        
        modelBuilder.Entity<User>()
            .HasMany(d => d.Debtors)
            .WithOne(d => d.User)
            .HasForeignKey(d => d.UserId);
        
        modelBuilder.Entity<User>()
            .HasMany(uw => uw.UserWallets)
            .WithOne(uw => uw.User)
            .HasForeignKey(uw => uw.UserId);
        
        modelBuilder.Entity<User>()
            .HasMany(ur => ur.UserRoles)
            .WithOne(ur => ur.User)
            .HasForeignKey(ur => ur.UserId);
        
        modelBuilder.Entity<User>()
            .HasMany(ut => ut.UserTokens)
            .WithOne(ut => ut.User)
            .HasForeignKey(ut => ut.UserId);
        
        //Role Entity
        modelBuilder.Entity<Role>().ToTable("Roles");
        modelBuilder.Entity<Role>()
            .HasMany(ur => ur.UserRoles)
            .WithOne(ur => ur.Role)
            .HasForeignKey(ur => ur.RoleId);
        
        //Lender Entity
        modelBuilder.Entity<Lender>()
            .HasMany(lp => lp.LoanParticipations)
            .WithOne(lp => lp.Lender)
            .HasForeignKey(lp => lp.LenderId);
        
        //Loan Entity
        modelBuilder.Entity<Loan>()
            .HasMany(lf => lf.LoanFinancialDetails)
            .WithOne(lf => lf.Loan)
            .HasForeignKey(lf => lf.LoanId);

        modelBuilder.Entity<Loan>()
            .HasMany(lc => lc.LoanContracts)
            .WithOne(lc => lc.Loan)
            .HasForeignKey(lc => lc.LoanId);

        modelBuilder.Entity<Loan>()
            .Property(l => l.Status)
            .HasConversion<string>();
        
        //Debtor Entity
        modelBuilder.Entity<Debtor>()
            .HasMany(Lp => Lp.LoanParticipations)
            .WithOne(lp => lp.Debtor)
            .HasForeignKey(lp => lp.DebtorId);
        
        //UserWallet Entity
        modelBuilder.Entity<UserWallet>()
            .HasMany(lp => lp.LoanParticipations)
            .WithOne(lp => lp.UserWallet)
            .HasForeignKey(lp => lp.UserWalletId);
    }
}