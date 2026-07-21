using KanbanApi.Services;

namespace KanbanApi.Endpoints;

public static class BoardEndpoints
{
    public static void MapBoardEndpoints(this WebApplication app)
    {
        app.MapGet("/boards/{id}", async (int id, IBoardService boardService) => 
        {
            var board = await boardService.GetBoardByIdAsync(id);
            
            if (board == null)
            {
                return Results.NotFound();
            }
            
            return Results.Ok(board); 
        })
        .WithName("GetBoardById");
    }
}