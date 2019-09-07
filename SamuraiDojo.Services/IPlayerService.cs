using System.Collections.Generic;
using SamuraiDojo.Interfaces;

namespace SamuraiDojo.Services
{
    public interface IPlayerService
    {
        List<IPlayer> GetAllPlayers();
        IPlayer GetPlayer(string name);
    }
}