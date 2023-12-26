using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.DrawResultDtos
{
    public class DrawResultGetListDto : IDto
    {
        public string GroupName { get; set; }
        public string TeamName { get; set; }
    }
}
