namespace MonopolyBack.Models
{
    public class RoundData
    {
        public Guid token { get; set; }
        public string Order { get; set; }
        public string optionMethod { get; set; }
        public int money { get; set; }
    }
}
