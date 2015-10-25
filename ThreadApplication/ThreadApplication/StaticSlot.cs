using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading; 

namespace ThreadApplication
{
    class StaticSlot
    {
        static Random rg = new Random();

        public static void SlotTest()
        {
            Thread.SetData(
                Thread.GetNamedDataSlot("Random"),
                rg.Next(1, 200));

            int threadId = Thread.CurrentThread.ManagedThreadId;
            LocalDataStoreSlot data = Thread.GetNamedDataSlot("Random");
            Object data1 = Thread.GetData(data);

            Console.WriteLine("The threadID is {0} and the data in it's Random Data Slot is {1}",
                threadId,
                data1);
            Console.Read();


        }
    }
}
