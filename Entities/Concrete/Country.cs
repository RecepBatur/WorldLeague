using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Country : IEntity
    {
        [Key]
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public List<Team> Teams { get; set; }
    }
}
