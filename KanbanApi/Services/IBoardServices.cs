using KanbanApi.Models;

namespace KanbanApi.Services;

/// <summary>
/// Contract for managing Kanban boards, including authorization checks.
/// </summary>
public interface IBoardService
{
    Task<IReadOnlyList<Board>> GetAllBoardsAsync(string userId, CancellationToken cancellationToken = default);

    Task<Board?> GetBoardByIdAsync(int id, CancellationToken cancellationToken = default);

    Task<Board> CreateBoardAsync(string name, string ownerId, CancellationToken cancellationToken = default);

    Task<Board?> UpdateBoardAsync(int id, string name, string requestingUserId, CancellationToken cancellationToken = default);

    Task<DeleteBoardResult> DeleteBoardAsync(int id, string requestingUserId, CancellationToken cancellationToken = default);    
}

public enum DeleteBoardResult
{
    Success,
    NotFound,
    Forbidden
}