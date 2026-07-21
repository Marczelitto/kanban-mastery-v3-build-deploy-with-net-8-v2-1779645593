using KanbanApi.Data;
using KanbanApi.Models;
using Microsoft.EntityFrameworkCore;

namespace KanbanApi.Services;

public class BoardService : IBoardService
{
    private readonly ApplicationDbContext _db;

    public BoardService(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Board?> GetBoardByIdAsync(
        int id,
        CancellationToken cancellationToken = default)
        {
            return await _db.Boards
                .Include(b => b.Columns)
                .Include(b => b.Members)
                .FirstOrDefaultAsync(
                    b => b.Id == id,
                    cancellationToken);
        }

        public Task<IReadOnlyList<Board>>GetAllBoardsAsync(
            string userId,
            CancellationToken cancellationToken = default)
            => throw new NotImplementedException();

        public Task<Board> CreateBoardAsync(
            string name,
            string ownerId,
            CancellationToken cancellationToken = default)
            => throw new NotImplementedException();

        public Task<Board?> UpdateBoardAsync(
            int id,
            string name,
            string requestingUserId,
            CancellationToken cancellationToken = default)
            => throw new NotImplementedException();

        public Task<DeleteBoardResult> DeleteBoardAsync(
            int id,
            string requestingUserId,
            CancellationToken cancellationToken = default)
            => throw new NotImplementedException();
}