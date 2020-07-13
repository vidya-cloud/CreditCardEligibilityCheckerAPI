using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CreditCardEligibilityCheckerAPI.Models
{
    /// <summary>
    /// Creditcardtype Enitity
    /// Holds different Card Types for which the customers can check thier eligibilty against
    /// </summary>
    public class CreditCardType
    {
        [Key]
        [Column(TypeName = "varchar(3)")]
        public string CardId { get; set; }
        [Required]
        [Column(TypeName = "varchar(16)")]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "decimal(4,2)")]
        public float APR { get; set; }
        [Required]
        [Column(TypeName = "varchar(800)")]
        public string PromotionalMessage { get; set; }
    }
}
