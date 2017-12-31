using Xunit;
using TeamService.Models;
using TeamService.Controllers;
using TeamService.Persistence;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace TeamService.Tests
{
    public class TeamControllerTest
    {
        [Fact]
        public async void QueryTeamListReturnsCorrectTeams()
        {
            var expectedTeams = new List<Team>() { new Team("one"), new Team("two") };
            var controller = new TeamsController(new MemoryTeamRepository(expectedTeams));

            var teamsRaw = (IEnumerable<Team>)(await controller.GetAllTeams() as ObjectResult).Value;

            List<Team> teams = new List<Team>(teamsRaw);
            Assert.Equal(expectedTeams.Count, teams.Count);
        }

        // [Fact]
        // public async void CreateTeamAddsTeamToList()
        // {
        //     TeamsController controller = new TeamsController();
        //     var teams = (IEnumerable<Team>)(await controller.GetAllTeams() as ObjectResult).Value;
        //     List<Team> original = new List<Team>(teams);

        //     Team t = new Team("sample");
        //     var result = await controller.CreateTeam(t);

        //     var newTeamsRaw = (IEnumerable<Team>)(await controller.GetAllTeams() as ObjectResult).Value;
            
        //     List<Team> newTeams = new List<Team>(newTeamsRaw);
        //     Assert.Equal(original.Count + 1, newTeams.Count);
        //     var sampleTeam = newTeams.FirstOrDefault(target => target.Name == "sample");
        //     Assert.NotNull(sampleTeam);
        // }
    }
}