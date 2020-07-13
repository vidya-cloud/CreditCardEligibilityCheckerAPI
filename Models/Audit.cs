using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CreditCardEligibilityCheckerAPI.Models
{
    /// <summary>
    /// Audit table holds the data for each customer who tries to find an eligible card suitable for him/her.
    /// </summary>
    public class Audit
    {
        [Key]
        [Column(TypeName = "int")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AuditId { get; set; }
        [Required]
        [Column(TypeName = "varchar(16)")]
        public string FirstName { get; set; }
        [Required]
        [Column(TypeName = "varchar(16)")]
        public string LastName { get; set; }
        [Required]
        [Column(TypeName = "varchar(10)")]
        public string DOB { get; set; }
        [Required]
        [Column(TypeName = "int")]
        public int AnnualIncome { get; set; }
        

        [ForeignKey("CardId")]
        public CreditCardType CardType { get; set; }
        public string CardId { get; set; }

        [Column(TypeName = "Datetime2")]
        public DateTime CreatedDateTime { get; set; }
    }
}
