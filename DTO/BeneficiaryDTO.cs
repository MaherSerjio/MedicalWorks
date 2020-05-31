using Assignment2.Models;
using System;

namespace Assignment2.DTO
{
    public class BeneficiaryDTO
    {


        public string Name { get; set; }


        public int Age { get; set; }

        public DateTime Date_Of_Birth { get; set; }


        public Gender Gender { get; set; }

        public int GenderId { get; set; }


        public Relationship Relationship { get; set; }

        public int RelationshipId { get; set; }
    }
}
