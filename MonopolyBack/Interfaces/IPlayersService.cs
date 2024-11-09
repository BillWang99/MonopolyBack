using MonopolyBack.Models;

namespace MonopolyBack.Interfaces
{
    public interface IPlayersService
    {
        //取出目前玩家的狀態
        public List<Players> GetPlayersStatus(Guid token);

        //回合結束，切換玩家
        public void ChangePlayer(Guid token);

        //返回上一位玩家
        public void BackToPlayer(Guid token);
    }
}
