using Nsu.HackathonProblem.Model.Dto;

namespace Nsu.HackathonProblem.Service
{
    public class TeamBuildingStrategy : ITeamBuildingStrategy
    {

        public List<TeamDto> BuildTeams(
            List<WishlistDto> juniorsWishlists,
            List<WishlistDto> teamLeadsWishlists
        )
        {
            // Извлечение списка джунов и тимлидов из WishlistDto
            var juniors = juniorsWishlists.Select(w => w.employee).Distinct().ToList();
            var teamleads = teamLeadsWishlists.Select(w => w.employee).Distinct().ToList();

            var freeTeamLeads = new List<EmployeeDto>(teamleads);
            var pairs = new Dictionary<EmployeeDto, EmployeeDto>(); // Занятые тимлиды и их джуны

            // Создание словарей предпочтений
            var teamleadsPreferences = CreatePreferencesDictionary(teamLeadsWishlists);
            var juniorsPreferences = CreatePreferencesDictionary(juniorsWishlists);

            // Создание словарей индексов удовлетворенности
            var juniorSatisfactions = CreateSatisfactionDictionary(juniorsPreferences);
            var teamleadSatisfactions = CreateSatisfactionDictionary(teamleadsPreferences);

            while (freeTeamLeads.Any())
            {
                // Выбор первого свободного тимлида
                var teamLead = freeTeamLeads.First();
                var preferences = teamleadsPreferences[teamLead];

                // Предложение первому джуну в списке предпочтений
                foreach (var (junior, preference) in preferences.OrderByDescending(p => p.Value))
                {
                    if (!pairs.ContainsValue(junior)) // Если джун еще не занят
                    {
                        pairs[teamLead] = junior;
                        freeTeamLeads.Remove(teamLead);
                        break;
                    }
                    else
                    {
                        // Проверяем, предпочитает ли джун этого тимлида
                        var currentTeamLeadByJunior = pairs.First(p => p.Value == junior).Key;
                        if (juniorSatisfactions[junior][teamLead] > juniorSatisfactions[junior][currentTeamLeadByJunior])
                        {
                            // Если текущий тимлид менее предпочтителен, заменяем
                            pairs.Remove(currentTeamLeadByJunior);
                            pairs[teamLead] = junior;
                            freeTeamLeads.Remove(teamLead);
                            freeTeamLeads.Add(currentTeamLeadByJunior); // Текущий тимлид снова свободен
                            break;
                        }
                    }
                }
            }

            // Формируем список команд
            return pairs.Select(p =>
                new TeamDto(
                    p.Key,
                    p.Value,
                    juniorSatisfactions[p.Value][p.Key],
                    teamleadSatisfactions[p.Key][p.Value]
                )
            ).ToList();
        }

        private Dictionary<EmployeeDto, Dictionary<EmployeeDto, int>> CreateSatisfactionDictionary(Dictionary<EmployeeDto, Dictionary<EmployeeDto, int>> preferences)
        {
            // Индексы удовлетворенности теперь можно напрямую использовать из предпочтений
            return preferences;
        }

        private Dictionary<EmployeeDto, Dictionary<EmployeeDto, int>> CreatePreferencesDictionary(List<WishlistDto> wishlists)
        {
            // Теперь предпочтения уже представлены в виде Dictionary<EmployeeDto, int>
            return wishlists.ToDictionary(w => w.employee, w => w.preferredEmployee);
        }
    }
}