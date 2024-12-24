using Nsu.HackathonProblem.Model;

namespace Nsu.HackathonProblem.Service;

public class RandomWishlistProvider : IWishlistProvider
{

    private static Random _random = new Random();

    public (List<Wishlist>, List<Wishlist>) GetWishlists(List<Employee> juniors, List<Employee> teamleads) {
        List<Wishlist> juniorsWishlists = new List<Wishlist>();
        List<Wishlist> teamleadsWishlists = new List<Wishlist>();
        
        juniors.ForEach(junior => juniorsWishlists.Add(generateRandomWishlist(junior, teamleads)));
        teamleads.ForEach(teamlead => teamleadsWishlists.Add(generateRandomWishlist(teamlead, juniors)));
        return (juniorsWishlists, teamleadsWishlists);
    }

    private Wishlist generateRandomWishlist(Employee employee, List<Employee> employees) {
        int employeeId = employee.Id;
        Shuffle(employees);
        int[] employeesIds = employees.Select(e => e.Id).ToArray();
        Wishlist wishlist = new Wishlist(employeeId, employeesIds);
        return wishlist;
    }

    private void Shuffle(List<Employee> employees) {
        int n = employees.Count;
        while (n > 1)
        {
            int k = _random.Next(n--);
            Employee employee = employees[n];
            employees[n] = employees[k];
            employees[k] = employee;
        }
    }

}