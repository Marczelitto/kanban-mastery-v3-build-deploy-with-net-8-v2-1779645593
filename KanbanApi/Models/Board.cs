using System.ComponentModel.DataAnnotations.Schema;

namespace KanbanApi.Models;

public class Board
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public List<Column> Columns { get; set; } = [];
}