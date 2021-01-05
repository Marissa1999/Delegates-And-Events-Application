using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndEvents
{
    class Counter
    {

        private int counter = 0;

        //An EventHandler is a delegate.
        public event EventHandler ThresholdReached;


        protected virtual void OnThresholdReached(EventArgs e)
        {
            EventHandler handler = ThresholdReached;
            handler?.Invoke(this, e);
        }


        public void Add(int x)
        {
            counter++;

            if (counter < 3)
            {
                Console.WriteLine("Below Threshold");
            }
            else
            {
                OnThresholdReached(new ThresholdReachedEventArgs(counter, DateTime.Now));
            }
        }
    }


    public class ThresholdReachedEventArgs : EventArgs
    {
        public ThresholdReachedEventArgs(int t, DateTime d)
        {
            Threshold = t;
            TimeReached = d;
        }

        public int Threshold { get; set; }
        public DateTime TimeReached { get; set; }
    }


}


