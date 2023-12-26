using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.GroupDtos
{
    public class GroupListDto : IDto
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public string CountryName { get; set; }
    }
}
