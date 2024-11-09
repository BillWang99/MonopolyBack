using MonopolyBack.Data;
using MonopolyBack.Models;
using MonopolyBack.Interfaces;

namespace MonopolyBack.Services
{
    public class PlayersService:IPlayersService
    {
        private readonly DefaultContext _context;

        public PlayersService(DefaultContext context)
        {
            _context = context;
        }

        //取出目前玩家的狀態
        public List<Players> GetPlayersStatus(Guid token)
        {
            return _context.Players.Where(p => p.GameId == token).ToList();
        }

        //回合結束，切換玩家
        public void ChangePlayer(Guid token)
        {
            //取出目前玩家
            Players currentPlayer = _context.Players.Where(p => p.GameId == token)
                .Where(p => p.IsTarget).FirstOrDefault();

            //取出玩家總數
            int AllPlayers = _context.GameHistory.Where(g => g.GameToken == token)
                .Select(g => g.PlayersCount).FirstOrDefault();

            //要切換的玩家Id
            int switchId = Int32.Parse(currentPlayer.Order)+1;

            //如果是最後一個玩家，需切換回第一位玩家
            if(switchId > AllPlayers)
            {
                switchId = 1;
            }

            //更新註記
            currentPlayer.IsTarget = false;
            _context.Players.Update(currentPlayer);

            //設定下一位玩家
            Players NextPlayer = _context.Players.Where(p => p.Order == switchId.ToString())
                .Where(p => p.GameId == token).FirstOrDefault();
            NextPlayer.IsTarget = true;
            _context.Players.Update(NextPlayer);

            _context.SaveChanges();
        }

        //返回上一位玩家
        public void BackToPlayer(Guid token) 
        {
            //取得目前遊玩的玩家
            Players currentPlayer = _context.Players
                .Where(p => p.GameId == token)
                .Where(p => p.IsTarget == true)
                .FirstOrDefault();

            //找出目前玩家的順序
            int order = Int32.Parse(currentPlayer.Order);

            //找出遊戲人數
            int totalPlayer = _context.Players
                .Where(p => p.GameId == token)
                .Count();

            //計算要回到哪位玩家
            if(order ==1)
            {
                //如果第一位玩家要返回，須回到最後一位玩家
                order = totalPlayer;
            }
            else
            {
                //順序減1
                --order;
            }

            //找出要返回的玩家
            Players prePlayer = _context.Players
                .Where(p => p.GameId == token)
                .Where(p => p.Order == order.ToString())
                .FirstOrDefault();

            //檢查上一位玩家是否有金額異動紀錄
            RoundResult roundResult = _context.RoundResult
                .Where(r => r.isDelete == false)
                .OrderByDescending(r => r.Id)
                .FirstOrDefault();

            //如果上一位玩家有金額異動
            if(roundResult != null && roundResult.PlayerId == prePlayer.Id)
            {
                prePlayer.money = Int32.Parse(roundResult.OriginMoney);
            }

            //更新玩家金額資料與刪除回合紀錄
            currentPlayer.IsTarget = false;
            prePlayer.IsTarget = true;
            roundResult.isDelete = true;

            _context.Players.Update(currentPlayer);
            _context.Players.Update(prePlayer);
            _context.RoundResult.Update(roundResult);

            //修改資料庫
            _context.SaveChanges();
            
        }

       
    }
}
