using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPublishing
{

    interface IReader
    {
        void ReadNews(string article);
    }

    class Reader : IReader
    {
        int number;

        public Reader(int n)
        {
            number = n;
        }

        public void ReadNews(string article)
        {
            Console.WriteLine("Reader-" + number + " has read the news: " + article);
            Console.WriteLine();
        }
    }

    public class ThresholdReachedEventArgs : EventArgs
    {
        public ThresholdReachedEventArgs(string article, DateTime time)
        {
            Article = article;
            TimeReached = time;
        }

        public string Article { get; set; }
        public DateTime TimeReached { get; set; }
    }

}
