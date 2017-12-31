using System.Collections.Generic;
using TeamService.Models;

namespace TeamService.Persistence 
{
    public class MemoryTeamRepository : ITeamRepository
    {
        protected static ICollection<Team> teams;

        public MemoryTeamRepository()
        {
            if (teams == null)
            {
                teams = new List<Team>();
            }
        }

        public MemoryTeamRepository(ICollection<Team> teams)
        {
            MemoryTeamRepository.teams = teams;
        }

        public IEnumerable<Team> GetTeams()
        {
            return teams;
        }

        public void AddTeam(Team t)
        {
            MemoryTeamRepository.teams.Add(t);
        }
    }
}