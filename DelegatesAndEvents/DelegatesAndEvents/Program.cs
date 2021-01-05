using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndEvents
{
    public class SamplesDelegate
    {

        //Declares a delegate for a method that takes in an integer and returns a String.
        public delegate String myMethodDelegate(int myInt);

        //Defines some methods to which the delegate can point.
        public class mySampleClass
        {

            //Defines an instance method.
            public String myStringMethod(int myInt)
            {
                if (myInt > 0)
                {
                    return ("positive");
                }

                if (myInt < 0)
                {
                    return ("negative");
                }

                return ("zero");
            }


            public static String mySignMethod(int myInt)
            {
                if (myInt > 0)
                {
                    return ("+");
                }

                if (myInt < 0)
                {
                    return ("-");
                }

                return ("");
            }

        }



        static void Main(string[] args)
        {

            /*
              Creates one delegate for each method. For the instance method, an
              instance (mySC) must be supplied. For the static method, use the
              class name.
            */
            mySampleClass mySC = new mySampleClass();
            myMethodDelegate myD1 = new myMethodDelegate(mySC.myStringMethod);
            myMethodDelegate myD2 = new myMethodDelegate(mySampleClass.mySignMethod);

            //Invokes the delegates.
            Console.WriteLine("{0} is {1}; use the sign \"{2}\".", 5, myD1(5), myD2(5));
            Console.WriteLine("{0} is {1}; use the sign \"{2}\".", -3, myD1(-3), myD2(-3));
            Console.WriteLine("{0} is {1}; use the sign \"{2}\".", 0, myD1(0), myD2(0));


            Counter counter = new Counter();

            /*
            Add the custom handler method as the event handler
            similarly to pointing a delegate to a method. We use
            the += since delegates are multicast, we can add many
            handlers for the same event.
            */

            counter.ThresholdReached += ThresholdReachedHandler;
            counter.ThresholdReached += ThresholdWeekDayHandler;

            counter.Add(1);
            counter.Add(1);

            //Will cause the event to be invoked.
            counter.Add(1);
        }

        static void ThresholdReachedHandler(object sender, EventArgs e)
        {
            Console.WriteLine(sender);
            Console.WriteLine(((ThresholdReachedEventArgs)e).Threshold);
            Console.WriteLine(((ThresholdReachedEventArgs)e).TimeReached);
            Console.WriteLine("The threshold was reached.");
        }

        static void ThresholdWeekDayHandler(object sender, EventArgs e)
        {
            Console.WriteLine(sender);
            Console.WriteLine(((ThresholdReachedEventArgs)e).Threshold);
            Console.WriteLine(((ThresholdReachedEventArgs)e).TimeReached.DayOfWeek);
            Console.WriteLine("The week-day of the reached threshold.");
        }

    }

    /*
       This code produces the following output:
               5 is positive; use the sign "+".
              -3 is negative; use the sign "-".
               0 is zero; use the sign "".
    */
}