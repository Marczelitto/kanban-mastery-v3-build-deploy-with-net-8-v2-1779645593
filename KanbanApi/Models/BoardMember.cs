namespace KanbanApi.Models;

public class BoardMember
{
    public int BoardId { get; set; }

    public Board Board { get; set; } = null!;

    public string UserId { get; set; } = string.Empty;

    public ApplicationUser User { get; set; } = null!;

    public string Role { get; set; } = string.Empty;
}