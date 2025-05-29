using Microsoft.EntityFrameworkCore;
using Nummora.Domain.Entities;

namespace Nummora.Infrastructure.Persistence;

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
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base  (options)
    {}
}