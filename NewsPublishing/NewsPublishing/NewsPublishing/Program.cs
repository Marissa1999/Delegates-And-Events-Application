using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPublishing
{
    class Program
    {
        static void Main(string[] args)
        {
            Reader reader1 = new Reader(1);
            Reader reader2 = new Reader(2);
            Reader reader3 = new Reader(3);
            Reader reader4 = new Reader(4);
            Publisher publisher = new Publisher();

            publisher.Register(reader1);
            publisher.Register(reader2);
            publisher.SetNewsArticle("Article-1: this is a news article!");
            publisher.Unregister(reader1);
            publisher.Register(reader3);
            publisher.Register(reader4);
            Console.WriteLine();

            publisher.ThresholdReached += ThresholdReachedHandler;

            publisher.SetNewsArticle("Article-2: this is a news article!"); 
            publisher.SetNewsArticle("Article-3: this is a news article!");
            publisher.SetNewsArticle("Article-4: this is a news article!");
            publisher.SetNewsArticle("Article-5: this is a news article!");
        }


        static void ThresholdReachedHandler(object sender, EventArgs e)
        {
            Console.WriteLine($"Publisher Notification - Published {((ThresholdReachedEventArgs)e).Article} at {((ThresholdReachedEventArgs)e).TimeReached}");
        }

    }
}
