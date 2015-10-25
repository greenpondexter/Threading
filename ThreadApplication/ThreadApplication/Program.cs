using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading; 

namespace ThreadApplication
{
    class Program
    {
        static void Main(string[] args){

            //    ThreadingExample te = new ThreadingExample();

            //// construct two threads for our demonstration;
            //      Thread thread1 = new Thread(new ThreadStart(te.DisplayThread1));
            //      Thread thread2 = new Thread(new ThreadStart(te.DisplayThread2));

            //      // start them
            //      thread1.Start();
            //      thread2.Start();
            
            
            //ReaderWriter write = new ReaderWriter();
            //write.writeToFile();


            ////Slot slt = new Slot();
            //string test = slt.slotTest();

            //Thread t = Thread.CurrentThread;
            //int tid = t.ManagedThreadId;


            //slt.runSlotTest(10);
            //Thread[] tds = new Thread[5];
            //for (int i = 0; i < 5; i++)
            //{

                //tds[i] = new Thread(new ThreadStart(StaticSlot.SlotTest));
                //tds[i].Start();


                //StaticSlot.SlotTest();

                Console.WriteLine();
                BlockingCollection<int> b = new BlockingCollection<int>();

                var consumer1 = Task.Factory.StartNew(() => 
                {    
                    foreach(int data in b.GetConsumingEnumerable())
                    {
                        Console.WriteLine("c1 = " +data +", ");
                    }
                    
                });

                var consumer2 = Task.Factory.StartNew(() => 
                {    
                    foreach(int data in b.GetConsumingEnumerable())
                    {
                        Console.WriteLine("c2 = " +data +", ");
                    }
                    
                });

                
                var producer = Task.Factory.StartNew(() =>
                {
                    for(int i = 0; i < 100; i++){
                        b.Add(i);
                    }
                    b.CompleteAdding(); 

                });


                producer.Wait();

                Task.WaitAll(consumer1, consumer2);

                Console.WriteLine();
                Console.Read();




            }

            //Console.WriteLine(tid);
            //Console.WriteLine(test);
            //Console.Read();


        }
    }

    public class ThreadingExample
    {
         // shared memory variable between the two threads
            // used to indicate which thread we are in
            private string _threadOutput = "";
            private bool _stopThreads = false; 
            /// <summary>
            /// Thread 1: Loop continuously,
            /// Thread 1: Displays that we are in thread 1
            /// </summary>
            public void DisplayThread1()
            {
                  while (_stopThreads == false)
                  {
                      lock (this)
                      {
                          Console.WriteLine("Display Thread 1");

                          // Assign the shared memory to a message about thread #1
                          _threadOutput = "Hello Thread1";


                          Thread.Sleep(1000);  // simulate a lot of processing 

                          // tell the user what thread we are in thread #1, and display shared memory
                          Console.WriteLine("Thread 1 Output --> {0}", _threadOutput);
                      }

                  }
            }

 

            /// <summary>
            /// Thread 2: Loop continuously,
            /// Thread 2: Displays that we are in thread 2
            /// </summary>
            public void DisplayThread2()
            {
                  while (_stopThreads == false)
                  {

                      lock (this)
                      {
                          Console.WriteLine("Display Thread 2");

                          // Assign the shared memory to a message about thread #2
                          _threadOutput = "Hello Thread2";


                          Thread.Sleep(1000);  // simulate a lot of processing

                          // tell the user we are in thread #2
                          Console.WriteLine("Thread 2 Output --> {0}", _threadOutput);
                      }
                  }
            }

 

                  
            
    }



