using Microsoft.EntityFrameworkCore;
using MinimalAPI.Dtos;
using MinimalAPI.Models;

namespace MinimalAPI.Endpoints
{
    public static class Users
    {
        public static async void UsersEndpoints(this IEndpointRouteBuilder routes)
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

            user.MapPut("{id}", async (string id, UpdateUserDTO userUpdate, ContextDb db) =>
            {
                var user = await db.Users.FindAsync(id);
                if (user is null) return Results.NotFound();
                user.Name = userUpdate.Name;
                user.Description = userUpdate.Description;
                user.AvatarURL = userUpdate.AvatarURL;
                await db.SaveChangesAsync();
                return Results.Ok();
            }
            );

            user.MapDelete("{id}", async (string id, ContextDb db) =>
            {
                var user = await db.Users.FindAsync(id);
                if (user is null) return Results.NotFound();
                db.Users.Remove(user);
                await db.SaveChangesAsync();
                return Results.NoContent();
            });
        }
    }
}
