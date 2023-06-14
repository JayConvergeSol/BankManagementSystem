using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankManagementSystem.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Required")]
        public string AccountType { get; set; }
        [Required(ErrorMessage = "Required")]
        public double Balance { get; set; }
        [Required(ErrorMessage = "Required")]
        public DateTime AccountOpenDate { get; set; }

        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }

    }
}
