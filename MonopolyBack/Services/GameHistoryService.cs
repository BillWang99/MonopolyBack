using MonopolyBack.Data;
using MonopolyBack.Models;
using MonopolyBack.Interfaces;

namespace MonopolyBack.Services
{
    public class GameHistoryService:IGameHistoryService
    {
        private readonly DefaultContext _context;

        public GameHistoryService(DefaultContext context)
        {
            _context = context;
        }

        //取得所有可存取的遊戲紀錄
        public List<GameHistory> GetAllGames()
        {
            return _context.GameHistory.Where(g => !g.IsDelete)
                .OrderByDescending(g=>g.CreateTime).ToList();
        }

        //新增遊戲
        public Guid NewGame(int playersCount)
        {
            Guid GameToken = Guid.NewGuid();

            GameHistory newGame = new GameHistory
            {
                GameToken = GameToken,
                CreateTime = DateTime.Now,
                PlayersCount = playersCount,
                IsDelete = false,
            };

            _context.GameHistory.Add(newGame);
            _context.SaveChanges();

            //新增玩家
            for (int i = 1; i <= playersCount; i++) 
            {
                Players player = new Players
                {
                    Order = i.ToString(),
                    money = 2000,
                    GameId = GameToken,
                    IsTarget = i == 1?true:false,
                };

                _context.Players.Add(player);
                _context.SaveChanges();
            }
            return GameToken;
        }

        //取得特定遊戲的token
        public Guid GetToken(int Id)
        {
            return _context.GameHistory.Where(g => g.Id == Id)
                .Select(g => g.GameToken).FirstOrDefault();
        }

        //將遊戲紀錄變更為刪除
        public void SetGameToDelete(int Id)
        {
            GameHistory Game = _context.GameHistory.Where(g => g.Id == Id).First();

            Game.IsDelete = true;

            _context.Update(Game);

            _context.SaveChanges();
        }
    }
}
