using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.IO.Ports;

namespace SerialLogTest
{
    class Program
    {
        static void Main(string[] args)
        {
            SerialPort com6 = new SerialPort("COM5", 115200);
            com6.Open();

            Thread.Sleep(1000);
            com6.Write("+++");
            Thread.Sleep(1000);

            string res = com6.ReadTo("\r");
            Console.WriteLine(res.Length);

            com6.Write("ATDNWUSATCUBE\r");
            res = com6.ReadTo("\r");
            Console.WriteLine(res.Length);

            FileStream fstr = new FileStream("log.txt", FileMode.Create, FileAccess.Write);

            while (true)
            {
                while (com6.BytesToRead > 0)
                {
                    fstr.WriteByte((byte)com6.ReadByte());
                }
                fstr.Flush();
            }
        }
    }
}
