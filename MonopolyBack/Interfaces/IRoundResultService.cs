using MonopolyBack.Models;

namespace MonopolyBack.Interfaces
{
    public interface IRoundResultService
    {
        //記錄每回合金額
        public void WriteRoundResult(RoundData data);

    }
}
