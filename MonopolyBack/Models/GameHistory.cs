using System.ComponentModel.DataAnnotations;

namespace MonopolyBack.Models
{
    public class GameHistory
    {
        //Id
        [Key]
        public int Id { get; set; }

        //遊戲token
        [Required]
        public Guid GameToken { get; set; }

        //建立時間
        [Required]
        public DateTime CreateTime { get; set; }

        //遊戲人數
        [Required]
        public int PlayersCount { get; set; }

        //是否刪除遊戲
        [Required]
        public bool IsDelete { get; set; }

        //一場遊戲可有多個玩家參與
        public IList<Players> players { get; set; }
    }
}
