using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Repository
{
    public interface IGameRepository
    {
        ICollection<Game> GetTodaysGames();
    }
}
