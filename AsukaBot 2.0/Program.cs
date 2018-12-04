using AsukaBot_2._0.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsukaBot_2._0
{
    class Program
    {
        static void Main(string[] args) => new MyBot().Start().GetAwaiter().GetResult();
    }
}
