using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MonopolyBack.Models
{
    public class RoundResult
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PlayerId { get; set; }

        [Required]
        public string OptionMethod { get; set; }

        [Required]
        public string OriginMoney { get; set; }

        [Required]
        public int Money { get; set; }

        [DefaultValue(false)]
        public bool isDelete { get; set; }

        //一位玩家會有多筆紀錄
        public IList<Players> players { get; set; }
    }
}
