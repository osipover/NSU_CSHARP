using Nsu.HackathonProblem.Model.Entity;

namespace Nsu.HackathonProblem.Repository;

public interface IWishlistRepository
{
    void SaveAll(List<Wishlist> wishlists);
}