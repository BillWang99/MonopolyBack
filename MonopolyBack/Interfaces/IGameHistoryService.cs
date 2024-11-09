using MonopolyBack.Models;

namespace MonopolyBack.Interfaces
{
    public interface IGameHistoryService
    {
        //取得所有可存取的遊戲紀錄
        public List<GameHistory> GetAllGames();

        //取得特定遊戲的token
        public Guid GetToken(int Id);

        //新增遊戲
        public Guid NewGame(int playersCount);

        //刪除紀錄
        public void SetGameToDelete(int Id);
    }
}
