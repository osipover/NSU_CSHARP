

using Nsu.HackathonProblem.Model;
using Nsu.HackathonProblem.Service;

class Hackathon {

    public Hackathon(IWishlistProvider wishlistProvider, List<Employee> juniors, List<Employee> teamleads) {
        this.wishlistProvider = wishlistProvider;
        Juniors = juniors;
        Teamleads = teamleads;
    }


    public List<Employee> Juniors { get; set; }
    public List<Employee> Teamleads { get; set; }

    private IWishlistProvider wishlistProvider;

    public (List<Wishlist>, List<Wishlist>) GetWishlists() {
        var (juniorsWishlists, teamleadsWishlists) = wishlistProvider.GetWishlists(Juniors, Teamleads);
        return (juniorsWishlists, teamleadsWishlists);
    }
}