using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadApplication
{
    class Queue
    {
        const int MAX_SIZE = 10;
        const int BOTTOM = 0;
        int position;
        ArrayList q; 
        public void Queue()
        {
            this.q = new ArrayList();
            this.position = 0;
        }

        Boolean isEmpty()
        {
            if (this.position == BOTTOM)
            {
                return true;
            }

            return false;
        }

        Boolean isFull()
        {
            if (this.position == MAX_SIZE)
            {
                return true;
            }

            return false; 
        }

        void enQueue(int ele)
        {
            this.q.Add(ele);
            this.position++; 
        }

        string deQueue()
        {
            string returnVal = this.q[this.position].ToString();
            this.q.RemoveAt(BOTTOM);
            this.position --; 
            
            return returnVal;
        }


        


    }
}
