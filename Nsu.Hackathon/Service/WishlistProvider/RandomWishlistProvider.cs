using Nsu.HackathonProblem.Model.Dto;

namespace Nsu.HackathonProblem.Service;

public class RandomWishlistProvider : IWishlistProvider
{

    private static Random _random = new Random();

    public (List<WishlistDto>, List<WishlistDto>) GetWishlists(List<EmployeeDto> juniors, List<EmployeeDto> teamleads) {
        List<WishlistDto> juniorsWishlists = new List<WishlistDto>();
        List<WishlistDto> teamleadsWishlists = new List<WishlistDto>();
        
        juniors.ForEach(junior => juniorsWishlists.Add(generateRandomWishlist(junior, teamleads)));
        teamleads.ForEach(teamlead => teamleadsWishlists.Add(generateRandomWishlist(teamlead, juniors)));
        return (juniorsWishlists, teamleadsWishlists);
    }

    private WishlistDto generateRandomWishlist(EmployeeDto employee, List<EmployeeDto> employees) {
        Shuffle(employees);
        var preferedEmployees = employees
            .Select((value, index) => new { value, index })
            .ToDictionary(x => x.value, x => x.index);
        WishlistDto wishlist = new WishlistDto(employee, preferedEmployees);
        return wishlist;
    }

    private void Shuffle(List<EmployeeDto> employees) {
        int n = employees.Count;
        while (n > 1)
        {
            int k = _random.Next(n--);
            EmployeeDto employee = employees[n];
            employees[n] = employees[k];
            employees[k] = employee;
        }
    }

}