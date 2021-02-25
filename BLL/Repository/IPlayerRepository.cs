using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Repository
{
    public interface IPlayerRepository
    {
        ICollection<Player> GetAll();
        ICollection<Player> Find(Func<Player, bool> predicate);
    }
}
