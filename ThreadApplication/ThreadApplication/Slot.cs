using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ThreadApplication
{
    class Slot
    {

        static Random rng = new Random();
        
        public string getDataInDataSlot(string DSname){

            LocalDataStoreSlot slot = Thread.GetNamedDataSlot(DSname);
            string test =  Thread.GetData(slot).ToString();
            return test; 
        }

        public void slotTest()
        {
            this.setDataInDataSlot("Random");
            Console.WriteLine("Starting thread.");

        }


        public void runSlotTest(int num)
        {
            Thread[] threads = new Thread[5];

            for (int i = 0; i < num; i++)
            {
                //ThreadStart ts = new ThreadStart(this.slotTest);
                
                threads[i] = new Thread(() => this.slotTest());
                threads[i].Start(); 
                printThreadIDandSlotData();
            }

        }

        public void setDataInDataSlot(string DSname)
        {
            int data = generateRandomNumber();
            LocalDataStoreSlot slot = Thread.GetNamedDataSlot(DSname);
            Thread.SetData(slot, data);
        }

        public int generateRandomNumber()
        {
            return rng.Next(1, 1000);
        }

        public int getThreadId()
        {
            Thread trd = Thread.CurrentThread;
            int tid = trd.ManagedThreadId;
            return tid; 
        }

        public void printThreadIDandSlotData()
        {
            int tid = getThreadId();
            string data = getDataInDataSlot("Random");
            Console.WriteLine("The current thread ID is: " + tid + " and the data in slot Random is:" + data);
        }
    }

    
}
