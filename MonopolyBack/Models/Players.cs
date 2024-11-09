using System.ComponentModel.DataAnnotations;

namespace MonopolyBack.Models
{
    public class Players
    {
        //Id
        [Key]
        public int Id { get; set; }

        //玩家順序
        [Required]
        public string Order { get; set; }

        //總金額
        [Required]
        public int money {  get; set; }


        //是否為當前玩家
        [Required]
        public bool IsTarget { get; set; }

        //遊戲Id
        [Required]
        public Guid GameId { get; set; }

        //每個玩家只一次只能隸屬一場遊戲
        //public GameHistory gamehistory { get; set; }
    }
}
