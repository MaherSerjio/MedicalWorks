using Assignment2.CustomValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment2.Models
{
    [Table("Policies")]
    public class Policy
    {

        public int Id { get; set; }



        [Required]
        public DateTime Effective { get; set; }

        [Required]
        [DateGreaterThan("Effective")]
        public DateTime Expiry { get; set; }


        [Column(TypeName = "decimal(18,4)")]
        public decimal Premium { get; set; }


        public bool IsValid { get; set; }


        [StringLength(255)]
        public string Police_No { get; set; }

        [Required]
        public IEnumerable<Beneficiary> Beneficiaries { get; set; }


        public IEnumerable<Claim> Claims { get; set; }




    }
}
