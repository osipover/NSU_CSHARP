
using Nsu.HackathonProblem.Model;
using Nsu.HackathonProblem.Service;

public class Examples {

    public static List<Employee> GetJuniors() 
    {
        return new List<Employee>() { new Employee(1, "Tom"), new Employee(2, "Tim") };
    }

    public static List<Employee> GetTeamleads() 
    {
        return new List<Employee>() { new Employee(10, "Ben"), new Employee(20, "Bob") }; 
    }

    public static List<Team> GetTeams() 
    {
        var juniors = GetJuniors();
        var teamleads = GetTeamleads();
        var team1 = new Team(teamleads[1], juniors[0], 1, 2);
        var team2 = new Team(teamleads[0], juniors[1], 2, 1);
        return new List<Team>() {team1, team2};
    }

    public static (List<Wishlist>, List<Wishlist>) GetWishlists() 
    {
        var juniorsWishlist = new List<Wishlist>() { createWishlist(1, new int[]{20, 10}), createWishlist(2, new int[]{20, 10}) };
        var teamleadsWishlist = new List<Wishlist>() { createWishlist(10, new int[]{1, 2}), createWishlist(20, new int[]{1, 2}) };
        return (juniorsWishlist, teamleadsWishlist);
    }

    private static Wishlist createWishlist(int EmployeeId, int[] DesiredEmployees) 
    {
        return new Wishlist(EmployeeId, DesiredEmployees);
    }
}