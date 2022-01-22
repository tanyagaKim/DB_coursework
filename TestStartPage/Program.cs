using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestStartPage
{
    class Program
    {
        static void Main(string[] args)
        {
            TestAuthorization test = new TestAuthorization();
            test.TestMockLoginDB();
        }
    }
}
