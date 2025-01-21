using Nsu.HackathonProblem.Model.Dto;

namespace Nsu.HackathonProblem.Service
{
    public interface IWishlistProvider
    {

        (List<WishlistDto>, List<WishlistDto>) GetWishlists(List<EmployeeDto> juniors, List<EmployeeDto> teamleads);
    }
}