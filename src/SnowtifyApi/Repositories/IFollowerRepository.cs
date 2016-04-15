using SnowtifyApi.Models;

namespace SnowtifyApi.Repositories
{
    public interface IFollowerRepository
    {
        void CreateFollower(Follower follower);

        void DeleteFollower(Follower follower);

        Follower GetFollower(string followerId);

        void UpdateFollower(Follower follower);
    }
}