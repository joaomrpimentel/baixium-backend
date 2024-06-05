using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

// modules


namespace MinimalAPI
{
    internal class Program
    {
        private static void Main(String[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<ContextDb>(opt => opt.UseInMemoryDatabase("db"));
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            // Authorization
            builder.Services.AddIdentityApiEndpoints<IdentityUser>()
                .AddEntityFrameworkStores<ContextDb>();

            builder.Services.AddAuthorization();
            // End Authorization

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // Authentication Mapgroup
            app.MapGroup("/identity").MapIdentityApi<IdentityUser>();

            // Mapgroups:

            var user = app.MapGroup("/User");
            user.MapGet("/", async (ContextDb db) =>
                await db.Users.ToListAsync());
            user.MapGet("/{id}", async (int id, ContextDb db) =>
                await db.Users.FindAsync(id)
                    is User user
                    ? Results.Ok(user)
                    : Results.NotFound());

            user.MapPost("/", async (User user, ContextDb db) =>
            {
                db.Users.Add(user);
                await db.SaveChangesAsync();
                return Results.Created($"/user/{user.Id}", user);
            });

            user.MapPut("/{id}", async (int id, User inputUser, ContextDb db) =>
            {
                var user = await db.Users.FindAsync(id);
                if (user is null) return Results.NotFound();
                user.Nome = inputUser.Nome;
                user.createdAt = inputUser.createdAt;
                user.avatarURl = inputUser.avatarURl;
                user.Email = inputUser.Email;
                user.Description = inputUser.Description;
                await db.SaveChangesAsync();
                return Results.NoContent();
            });

            user.MapDelete("/{id}", async (int id, ContextDb db) =>
            {
                if (await db.Users.FindAsync(id) is User user)
                {
                    db.Users.Remove(user);
                    await db.SaveChangesAsync();
                    return Results.NoContent();
                }

                return Results.NotFound();
            });

            var article = app.MapGroup("/Article");
            article.MapGet("/", async (ContextDb db) =>
                await db.Articles.ToListAsync());
            article.MapGet("/{id}", async (int id, ContextDb db) =>
                await db.Articles.FindAsync(id)
                    is Article article
                    ? Results.Ok(article)
                    : Results.NotFound());

            article.MapPost("/", async (Article article, ContextDb db) =>
            {
                db.Articles.Add(article);
                await db.SaveChangesAsync();
                return Results.Created($"/article/{article.Id}", article);
            });

            article.MapPut("/{id}", async (int id, Article inputArticle, ContextDb db) =>
            {
                var article = await db.Articles.FindAsync(id);
                if (article is null) return Results.NotFound();
                article.createdAt = inputArticle.createdAt;
                article.Title = inputArticle.Title;
                article.Content = inputArticle.Content;
                article.Likes = inputArticle.Likes;
                article.Tags = inputArticle.Tags;
                await db.SaveChangesAsync();
                return Results.NoContent();
            });

            article.MapDelete("/{id}", async (int id, ContextDb db) =>
            {
                if (await db.Articles.FindAsync(id) is Article article)
                {
                    db.Articles.Remove(article);
                    await db.SaveChangesAsync();
                    return Results.NoContent();
                }

                return Results.NotFound();
            });



            app.MapGet("/", () => "Hello World!");
            app.Run();
        }
    }

}