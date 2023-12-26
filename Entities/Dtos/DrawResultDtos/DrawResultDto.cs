using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.DrawResultDtos
{
    public class DrawResultDto : IDto
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public string CountryName { get; set; }
        public string TeamName { get; set; }
        public string UserName { get; set; }
        public int GroupId { get; set; }
        public int TeamId { get; set; }
        public int CountryId { get; set; }
    }
}
