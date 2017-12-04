using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Entities
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string name { get; set; }

        public CusineType CusineType { get; set; }

        public string Url { get; set; }
    }

    public enum CusineType
    {
        None,
        Fast,
        Italian 
    }
}
