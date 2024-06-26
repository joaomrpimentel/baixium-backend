using Microsoft.EntityFrameworkCore;
using MinimalAPI.Dtos;
using MinimalAPI.Models;

namespace MinimalAPI.Endpoints
{
    public static class Articles
    {
        public static void ArticleEndpoints(this IEndpointRouteBuilder routes)
        {
            var article = routes.MapGroup("/articles");
            article.MapGet("/", async (ContextDb db) =>
            await db.Articles.ToListAsync());


            article.MapGet("/{id}", async (string id, ContextDb db) =>
                await db.Articles.FindAsync(new Guid(id))
                    is Article article
                    ? Results.Ok(article)
                    : Results.NotFound());

            article.MapPost("/", async (CreateArticleDTO cretateArticleDTO, ContextDb db) =>
            {
                var newArticle = new Article
                {

                    Title = cretateArticleDTO.Title,
                    Content = cretateArticleDTO.Content,
                    userId = cretateArticleDTO.UserId.ToString()
                };

                db.Articles.Add(newArticle);
                await db.SaveChangesAsync();
                return Results.Created($"/articles/{newArticle.Id}", article);
            });

            article.MapPut("/{id}", async (string id, UpdateArticleDTO inputArticle, ContextDb db) =>
            {
                var article = await db.Articles.FindAsync(new Guid(id));
                if (article is null) return Results.NotFound();
                article.Title = inputArticle.Title;
                article.Content = inputArticle.Content;
                await db.SaveChangesAsync();
                return Results.NoContent();
            });

            article.MapDelete("/{id}", async (string id, ContextDb db) =>
            {
                if (await db.Articles.FindAsync(new Guid(id)) is Article article)
                {
                    db.Articles.Remove(article);
                    await db.SaveChangesAsync();
                    return Results.NoContent();
                }

                return Results.NotFound();
            });

            article.MapPut("{id}/like", async (string id, ContextDb db) =>
            {
                var article = await db.Articles.FirstOrDefaultAsync(a => a.Id.ToString() == id);
                if (article == null)
                {
                    return Results.NotFound();
                }

                article.Likes++;
                await db.SaveChangesAsync();

                return Results.Ok();
            }
           );
        }
    }
}
