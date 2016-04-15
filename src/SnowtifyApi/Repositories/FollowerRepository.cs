using Microsoft.Extensions.DependencyInjection;
using SnowtifyApi.Models;
using System;
using System.Linq;

namespace SnowtifyApi.Repositories
{
    public class FollowerRepository : IFollowerRepository
    {
        private ApplicationDbContext _applicationDbContext;

        public FollowerRepository(IServiceProvider serviceProvider)
        {
            _applicationDbContext = serviceProvider.GetService<ApplicationDbContext>();
        }

        public void CreateFollower(Follower follower)
        {
            _applicationDbContext.Followers.Add(follower);
            _applicationDbContext.SaveChanges();
        }

        public void DeleteFollower(Follower follower)
        {
            _applicationDbContext.Followers.Remove(follower);
            _applicationDbContext.SaveChanges();
        }

        public Follower GetFollower(string followerId)
        {
            return _applicationDbContext.Followers.Where(x => string.Equals(x.Id, followerId, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
        }

        public void UpdateFollower(Follower follower)
        {
            _applicationDbContext.Followers.Update(follower);
            _applicationDbContext.SaveChanges();
        }
    }
}