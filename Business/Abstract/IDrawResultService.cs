using Core.Utilities.Results;
using Entities.Dtos.DrawResultDtos;
using Entities.Dtos.GroupDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IDrawResultService
    {
        Task<IDataResult<bool>> DrawResult(string name, string surname);
        IDataResult<Dictionary<string, List<DrawResultGetListDto>>> GroupGetList();
    }
}
