namespace SavingsTrackerAPI.Models
{
    public class SavingsPlan
    {
        public int Week { get; set; }
        public decimal Deposit { get; set; }
        public decimal Balance { get; set; }
        public bool IsChecked { get; set; }
        
    }
}