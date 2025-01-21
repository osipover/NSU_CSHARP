using Microsoft.EntityFrameworkCore;
using Nsu.HackathonProblem.Database;
using Nsu.HackathonProblem.Model.Entity;

namespace Nsu.HackathonProblem.Repository;

public class WishlistRepository(HackathonDB context)
    : IWishlistRepository
{

    public void SaveAll(List<Wishlist> wishlists)
    {
        foreach (var wishlist in wishlists)
        {
            context.Wishlists.Add(wishlist);
        }
        context.SaveChanges();
    }
}