using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var lastStatus = DataAccess.GetServerData().IsStatusActive;
            var newStatus = true;

            if (newStatus == true)
                Console.WriteLine("its true");

            DataAccess.SaveServerData(newStatus);

            Console.ReadKey();

        }
    }
}
