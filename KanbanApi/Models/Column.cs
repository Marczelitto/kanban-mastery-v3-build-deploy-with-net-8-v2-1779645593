namespace KanbanApi.Models;

public class Column
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public int BoardId { get; set; }

    public Board Board { get; set; } = null!;

    public List<Card> Cards { get; set; } = [];
}