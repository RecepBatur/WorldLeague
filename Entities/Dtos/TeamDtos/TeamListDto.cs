using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.TeamDtos
{
    public class TeamListDto : IDto
    {
        public int Id { get; set; }
        public string TeamName { get; set; }
        public string CountryName { get; set; }
    }
}
