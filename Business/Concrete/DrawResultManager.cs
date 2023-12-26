using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.DrawResultDtos;
using Entities.Dtos.GroupDtos;
using Entities.Dtos.TeamDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class DrawResultManager : IDrawResultService
    {
        private readonly IDrawResultDal _drawResultDal;
        private readonly IGroupDal _groupDal;
        private readonly ITeamDal _teamDal;
        private readonly ICountryDal _countryDal;

        public DrawResultManager(IDrawResultDal drawResultDal, IGroupDal groupDal, ITeamDal teamDal, ICountryDal countryDal)
        {
            _drawResultDal = drawResultDal;
            _groupDal = groupDal;
            _teamDal = teamDal;
            _countryDal = countryDal;
        }

        public async Task<IDataResult<bool>> DrawResult(string name, string surname)
        {
            var groups = _groupDal.GetList();
            var allTeams = _teamDal.GetList();

            List<DrawResultDto> drawResultList = new List<DrawResultDto>();
            List<GroupListDto> groupList = new List<GroupListDto>();

            while (groupList.Count < groups.Count * 4)
            {
                foreach (var group in groups)
                {
                    Team selectedTeam = GetRandomTeam(allTeams.ToList(), drawResultList.Select(x => x.TeamName).ToList());

                    if (selectedTeam != null)
                    {

                        groupList.Add(new GroupListDto
                        {
                            Id = group.Id,
                            GroupName = group.GroupName
                        });

                        drawResultList.Add(new DrawResultDto
                        {
                            GroupName = group.GroupName,
                            TeamName = selectedTeam.TeamName,
                            CountryName = selectedTeam.CountryName,
                            UserName = name + surname
                        });
                    }
                }
            }


            foreach (var drawResultDto in drawResultList)
            {
                DrawResult drawResult = new DrawResult
                {
                    Id = drawResultDto.Id,
                    GroupName = drawResultDto.GroupName,
                    TeamName = drawResultDto.TeamName,
                    CountryName = drawResultDto.CountryName,
                    UserName = drawResultDto.UserName
                };

                _drawResultDal.Add(drawResult);
            }
            return new SuccessDataResult<bool>(Messages.DrawResult);
        }

        private Team GetRandomTeam(List<Team> teams, List<string> selectedTeamNames)
        {
            var availableTeams = teams.Where(team => !selectedTeamNames.Contains(team.TeamName)).ToList();

            if (availableTeams.Count > 0)
            {
                Random random = new Random();
                int randomIndex = random.Next(availableTeams.Count);
                Team selectedTeam = availableTeams[randomIndex];

                selectedTeamNames.Add(selectedTeam.TeamName);

                return selectedTeam;
            }

            return null;
        }
        public IDataResult<Dictionary<string, List<DrawResultGetListDto>>> GroupGetList()
        {
            var list = _drawResultDal.GetList();
            if (list == null)
            {
                return new ErrorDataResult<Dictionary<string, List<DrawResultGetListDto>>>(Messages.DrawResultError);
            }

            var groupedResult = new Dictionary<string, List<DrawResultGetListDto>>();

            foreach (var item in list)
            {
                if (!groupedResult.ContainsKey(item.GroupName))
                {
                    groupedResult[item.GroupName] = new List<DrawResultGetListDto>();
                }

                groupedResult[item.GroupName].Add(new DrawResultGetListDto
                {
                    GroupName = item.GroupName,
                    TeamName = item.TeamName,
                });
            }

            return new SuccessDataResult<Dictionary<string, List<DrawResultGetListDto>>>(groupedResult, Messages.List);
        }


    }
}
