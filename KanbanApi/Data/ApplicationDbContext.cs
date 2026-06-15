using KanbanApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace KanbanApi.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public DbSet<BoardMember> BoardMembers { get; set; } = null!;

    public DbSet<Card> Cards { get; set; } = null!;

    public DbSet<Board> Boards { get; set; } = null!;

    public DbSet<Column> Columns { get; set; } = null!;

    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options
    )
        : base(options)
    {
    }

    protected override void OnModelCreating(
        ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var boardMember = modelBuilder.Entity<BoardMember>();

        boardMember.HasKey(bm => new { bm.UserId, bm.BoardId });
        
        boardMember.HasOne(bm => bm.User)
            .WithMany(u => u.BoardMemberships)
            .HasForeignKey(bm => bm.UserId);

        boardMember.HasOne(bm => bm.Board)
            .WithMany(b => b.Members)
            .HasForeignKey(bm => bm.BoardId);
    }
}
