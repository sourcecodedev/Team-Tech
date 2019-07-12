using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTech.Models
{
    public class Services
    {
    
        public int ServicesId { get; set; } 
        public string Name_Services { get; set; } 
        public decimal PriceTotal { get; set; } 
        public TypeServices TypeServices { get; set; }
    }
}