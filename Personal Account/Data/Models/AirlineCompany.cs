using System;
using System.Collections.Generic;

namespace Personal_Account
{
    public partial class AirlineCompany
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string NameEn { get; set; } = null!;
        public string IcaoCode { get; set; } = null!;
        public string IataCode { get; set; } = null!;
        public string RfCode { get; set; } = null!;
        public string Country { get; set; } = null!;
    }
}
