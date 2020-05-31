using Assignment2.Models;
using System.Collections.Generic;

namespace Assignment2.DTO
{
    public class FilterdClaimsDTO
    {
        public List<Claim> FilterdClaims { get; set; }

        public int NumberOfClaimsReturned { get; set; }
    }
}
