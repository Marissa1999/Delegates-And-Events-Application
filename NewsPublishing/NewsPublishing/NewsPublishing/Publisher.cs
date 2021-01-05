using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPublishing
{
    interface IPublisher
    {
        void SetNewsArticle(string s);
        void NotifyReaders();
        void Register(Reader reader);
        void Unregister(Reader reader);
    }

    class Publisher : IPublisher
    {
        List<Reader> readers = new List<Reader>();
        public event EventHandler ThresholdReached;
        string article;

        protected virtual void OnThresholdReached(EventArgs e)
        {
            EventHandler handler = ThresholdReached;
            handler?.Invoke(this, e);
        }

        public void SetNewsArticle(string s)
        {
            article = s;
            NotifyReaders();
        }

        public void NotifyReaders()
        {
            foreach (Reader r in readers)
            {
                OnThresholdReached(new ThresholdReachedEventArgs(article, DateTime.Now));
                r.ReadNews(article);
            }
        }

        public void Register(Reader r)
        {
            // We could check if the reader already exists
            // so that we do not add it again!
            readers.Add(r);
        }

        public void Unregister(Reader r)
        {
            readers.Remove(r);
        }

    }
}
