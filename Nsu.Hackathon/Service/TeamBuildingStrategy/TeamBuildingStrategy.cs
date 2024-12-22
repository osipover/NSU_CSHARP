using Nsu.HackathonProblem.Model;

namespace Nsu.HackathonProblem.Service
{
    public class TeamBuildingStrategy : ITeamBuildingStrategy
    {

        public List<Team> BuildTeams(            
            List<Employee> juniors,
            List<Employee> teamleads,             
            List<Wishlist> juniorsWishlists,
            List<Wishlist> teamLeadsWishlists
        ) {
            var juniorsDictionary = juniors.ToDictionary(j => j.Id, j => j);
            var freeTeamLeads = new List<Employee>(teamleads);
            var pairs = new Dictionary<Employee, Employee>(); // Занятые тимлиды и их джуны

            // Создание словаря предпочтений для быстрого доступа
            var teamleadsPreferences = CreatePreferencesDictionary(teamLeadsWishlists);
            var juniorsPreferences = CreatePreferencesDictionary(juniorsWishlists);

            // Создание словарей индексов удовлетворенности
            var juniorSatisfactions = CreateSatisfactionDictionary(juniors, teamleads, juniorsWishlists);
            var teamleadSatisfactions = CreateSatisfactionDictionary(teamleads, juniors, teamLeadsWishlists);

            while (freeTeamLeads.Any())
            {
                // Выбор первого свободного тимлида
                var teamLead = freeTeamLeads.First();
                var preferences = teamleadsPreferences[teamLead.Id];
                
                // Предложение первому джуну в списке предпочтений
                foreach (var juniorId in preferences)
                {
                    var junior = juniorsDictionary[juniorId];
                    if (!pairs.ContainsValue(junior)) // Если джун еще не занят
                    {
                        pairs[teamLead] = junior;
                        freeTeamLeads.Remove(teamLead);
                        break;
                    }
                    else
                    {
                        // Проверяем, предпочитает ли джун этого тимлида
                        var currentTeamLeadByJunior = pairs.First(p => p.Value.Id == juniorId).Key;
                        if (juniorSatisfactions[juniorId][teamLead.Id] > juniorSatisfactions[juniorId][currentTeamLeadByJunior.Id])
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
                new Team(
                    p.Key,
                    p.Value, 
                    juniorSatisfactions[p.Key.Id][p.Value.Id],
                    teamleadSatisfactions[p.Value.Id][p.Key.Id]
                )
            ).ToList();
        }

        public int CalcIndexOfSatisfaction(int index, int numOfCandidates) 
        {
            return numOfCandidates - index;
        }

        private Dictionary<int, Dictionary<int, int>> CreateSatisfactionDictionary(List<Employee> employeesFirst, List<Employee> employeesSecond, List<Wishlist> wishlists) 
        {
            var satisfactions = employeesFirst.ToDictionary(j => j.Id, j => new Dictionary<int, int>());
            foreach (var wishlist in wishlists)
            {
                for (int i = 0; i < wishlist.DesiredEmployees.Length; i++)
                {
                    satisfactions[wishlist.EmployeeId][wishlist.DesiredEmployees[i]] = CalcIndexOfSatisfaction(i, employeesSecond.Count); // Индекс предпочтения
                }
            }
            return satisfactions;
        }

        private Dictionary<int, int[]> CreatePreferencesDictionary(List<Wishlist> wishlists) 
        {
            return wishlists.ToDictionary(w => w.EmployeeId, w => w.DesiredEmployees);
        }
    }
}