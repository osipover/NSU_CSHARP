using Microsoft.EntityFrameworkCore;
using Nsu.HackathonProblem.Database;
using Nsu.HackathonProblem.Model.Entity;
using Nsu.HackathonProblem.Model.Dto;
using Nsu.HackathonProblem.Service;
using Nsu.HackathonProblem.Repository;


namespace Nsu.HackathonProblem.Service;

public class WishlistService(
    IWishlistRepository wishlistRepository
)
{
    public void SaveWishlists(List<WishlistDto> wishlistsDto, Role role, int hackathonId)
    {
        var wishlists = new List<Wishlist>();
        foreach (var wishlist in wishlistsDto)
        {
            foreach (var pref in wishlist.preferredEmployee)
            {
                var newWishlist = new Wishlist
                {
                    HackathonId = hackathonId,
                    EmployeeId = wishlist.employee.Id,
                    PreferredEmployeeId = pref.Key.Id,
                    Priority = pref.Value,
                    Role = role
                };
                wishlists.Add(newWishlist);
            }            
        }
        wishlistRepository.SaveAll(wishlists);
    }
}