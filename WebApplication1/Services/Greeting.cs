using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace WebApplication1.Services
{
    public interface IGreeting
    {
        string GetGreeting();
    }
    
    public class Greeting : IGreeting
    {
        private readonly IConfiguration _conf;

        public Greeting(IConfiguration conf)
        {
            _conf = conf;
        }
        public string GetGreeting()
        {
            return _conf["greeting"];
        }
    }
}
