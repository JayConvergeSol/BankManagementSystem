using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankManagementSystem.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Company to fill data")]
        public string TransactionType { get; set; }
        [Required(ErrorMessage = "Company to fill Amount")]
        public double Amount { get; set; }
        [Required(ErrorMessage = "Company to fill data")] 
        public DateTime TransactionDate { get; set; }
        public int AccountId { get; set; }
        [ForeignKey("AccountId")]
        public Account Account { get; set; }
    }
}
