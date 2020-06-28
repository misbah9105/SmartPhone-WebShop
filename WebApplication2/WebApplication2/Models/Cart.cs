using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Cart
    {
        public string Image { get; set; }
        public int IDPro { get; set; }
        public string Name { get; set; }
        public int? Price { get; set; }
        public int Size { get; set; }
        public int? Quan { get; set; }
        public int Total
        { get { return (int)(Quan * Price); } }
    }
}