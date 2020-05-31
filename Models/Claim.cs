using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment2.Models
{
    [Table("Claims")]
    public class Claim
    {

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Police_No { get; set; }

        [Required]
        public DateTime Incured_Date { get; set; }


        [Column(TypeName = "decimal(18,4)")]
        public decimal Claimed_Amount { get; set; }



    }
}
