using System;

namespace Assignment2.Models
{
    public class ClaimsFilter
    {

        public string Police_No { get; set; }

        public int? Claimed_Amount_From { get; set; }

        public int? Claimed_Amount_To { get; set; }

        public DateTime? Incured_Date_From { get; set; }

        public DateTime? Incured_Date_To { get; set; }

        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 10;


    }
}
