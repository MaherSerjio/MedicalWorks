using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment2.Models
{
    [Table("Beneficiaries")]
    public class Beneficiary
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public DateTime Date_Of_Birth { get; set; }


        public Gender Gender { get; set; }

        [Required]
        public int GenderId { get; set; }


        public Relationship Relationship { get; set; }

        [Required]
        public int RelationshipId { get; set; }



    }
}
