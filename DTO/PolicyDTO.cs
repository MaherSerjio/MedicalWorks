using System;

namespace Assignment2.DTO
{
    public class PolicyDTO
    {


        public DateTime Effective { get; set; }


        public DateTime Expiry { get; set; }


        public decimal Premium { get; set; }


        public string Police_No { get; set; }

        public int NumberOfSubmittedClaims { get; set; }


    }
}
