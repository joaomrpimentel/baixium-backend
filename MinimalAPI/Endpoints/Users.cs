using Microsoft.EntityFrameworkCore;
using MinimalAPI.Dtos;
using MinimalAPI.Models;

namespace MinimalAPI.Endpoints
{
    public static class Users
    {
        public static void UsersEndpoints(this IEndpointRouteBuilder routes)
        {
            var user = routes.MapGroup("/users");
            user.MapGet("/", async (ContextDb db) =>
                await db.Users.ToListAsync()
            );

            user.MapGet("{id}/articles", async (string id, ContextDb db) =>
                await db.Articles.Where(
                    a => a.userId == id
                ).ToListAsync()
            );

           
        }
    }
}
