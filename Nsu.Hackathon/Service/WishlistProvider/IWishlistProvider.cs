using Nsu.HackathonProblem.Model;

namespace Nsu.HackathonProblem.Service
{
    public interface IWishlistProvider
    {

        (List<Wishlist>, List<Wishlist>) GetWishlists(List<Employee> juniors, List<Employee> teamleads);
    }
}