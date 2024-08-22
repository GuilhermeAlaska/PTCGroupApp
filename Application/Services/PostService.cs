using Application.Common;
using Application.Common.Interfaces;
using Application.Dtos.Posts;
using Application.Interfaces;
using Domain.Enums;
using Domain.Models;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class PostService : IPostService
    {
        private readonly IApplicationDbContext context;
        private readonly IHubContext<NotificationHub> hubContext;

        public PostService(IApplicationDbContext context, IHubContext<NotificationHub> hubContext)
        {
            this.context = context;
            this.hubContext = hubContext;
        }

        public async Task<BaseResult<PostDto>> CreatePost(string title, string shortDescription, string fullPost, Category? category)
        {
            var post = new Post(title, shortDescription, fullPost, category);

            try
            {
                await context.Posts.AddAsync(post);

                await context.SaveChangesAsync(new CancellationToken());

                var notification = new Notification(title);

                await hubContext.Clients.All.SendAsync("ReceiveNotification", notification);

                return new BaseResult<PostDto>(201, "Post criado com sucesso!");
            }
            catch
            {
                return new BaseResult<PostDto>(500, "Não foi possível criar um post, tente novamente mais tarde.");
            }
        }

        public async Task<BaseResult<PostDto>> DeletePost(Guid id)
        {
            var post = await context.Posts.FirstAsync(p => p.Id == id);

            try
            {
                context.Posts.Remove(post);
                await context.SaveChangesAsync(new CancellationToken());
                return new BaseResult<PostDto>(200, "Post deletado com sucesso!", true);
            }
            catch
            {
                return new BaseResult<PostDto>(500, "Não foi possível apagar o post, tente novamente mais tarde.");
            }
        }

        public async Task<List<PostDto>> GetAllPosts()
        {
            return await context
                .Posts
                .AsNoTracking()
                .Select(p => new PostDto(p.Id, p.CreatedAt, p.Title, p.ShortDescription, p.FullPost, p.Category))
                .ToListAsync();
        }

        public async Task<PostDto> GetPostById(Guid id)
        {
            return await context
                .Posts
                .AsNoTracking()
                .Where(p => p.Id == id)
                .Select(p => new PostDto(p.Id, p.CreatedAt, p.Title, p.ShortDescription, p.FullPost, p.Category))
                .FirstAsync();
        }

        public async Task<List<PostDto>> GetPostsByCategory(Category category)
        {
            return await context
                .Posts
                .AsNoTracking()
                .Where(p => p.Category == category)
                .OrderByDescending(p => p.CreatedAt)
                .Select(p => new PostDto(p.Id, p.CreatedAt, p.Title, p.ShortDescription, p.FullPost, p.Category))
                .ToListAsync();
        }

        public async Task<BaseResult<PostDto>> UpdatePost(Guid postId, string title, string shortDescription, string fullPost, Category category)
        {
            var post = await context.Posts.FirstAsync(p => p.Id == postId);

            post.Edit(title, shortDescription, fullPost, category);

            try
            {
                context.Posts.Update(post);

                await context.SaveChangesAsync(new CancellationToken());

                return new BaseResult<PostDto>(200, "Post alterado com sucesso!");
            }
            catch
            {
                return new BaseResult<PostDto>(500, "Não foi possível editar um post, tente novamente mais tarde.");
            }
        }
    }
}