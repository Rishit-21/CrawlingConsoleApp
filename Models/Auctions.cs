using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CrawlingConsoleApp.Models
{
    public partial class Auctions
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string Link { get; set; }
        public string LotCount { get; set; }
        public string StartDate { get; set; }
        public string StartMonth { get; set; }
        public string StartYear { get; set; }
        public string StartTime { get; set; }
        public string EndDate { get; set; }
        public string EndMonth { get; set; }
        public string EndYear { get; set; }
        public string EndTime { get; set; }
    }
}
