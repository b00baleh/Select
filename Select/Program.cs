using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Select
{
    class Program
    {
        static void Main(string[] args)
        {
            var l = new List<string>();
            l.Add("abc");
            l.Add("def");
            l.Add("ghi");

            var z = l.MySelect(x => x[0]).Take(2);
            /*
            var myclass = new MyIenumClass<int>(l);

            foreach (var i in myclass)
            {

            }
            */
        }
    }
}
