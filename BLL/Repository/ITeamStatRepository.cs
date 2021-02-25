using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Repository
{
    public interface ITeamStatRepository
    {
        List<TeamStatSummary> FindAll(Func<TeamStatSummary, bool> func);
    }
}
