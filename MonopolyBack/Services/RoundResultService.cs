using MonopolyBack.Data;
using MonopolyBack.Models;
using MonopolyBack.Interfaces;

namespace MonopolyBack.Services
{
    public class RoundResultService:IRoundResultService
    {
        private readonly DefaultContext _context;

        public RoundResultService(DefaultContext context)
        {
            _context = context;
        }

        //記錄每回合金額
        public void WriteRoundResult(RoundData data)
        {
            //取出使用者資料
            Players currentPlayer = _context.Players
                .Where(p => p.GameId == data.token)
                .Where(p => p.Order == data.Order)
                .FirstOrDefault();

            //原始金額
            int originMoney = currentPlayer.money;

            if(data.optionMethod == "income")
            {
                currentPlayer.money += data.money;
            }
            else
            {
                if (currentPlayer.money - data.money < 0)
                {
                    currentPlayer.money = 0;
                }
                else
                {
                    currentPlayer.money -= data.money;
                }   
            }

            _context.Players.Update(currentPlayer);

            //寫入當回合操作資料
            RoundResult result = new RoundResult
            {
                PlayerId = currentPlayer.Id,

                OptionMethod = data.optionMethod,

                Money = data.money,

                OriginMoney = originMoney.ToString(),

            }; 

            _context.RoundResult.Add(result);

            _context.SaveChanges();
        }
    }
}
