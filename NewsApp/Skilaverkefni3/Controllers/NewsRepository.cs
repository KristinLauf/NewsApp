using Skilaverkefni3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Skilaverkefni3.Controllers
{
    class NewsRepository
    {
        internal object GetAllNews()
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            var results = (from newsItem in db.News
                           select newsItem).ToList();
            return results;
        }

        internal News GetNewsById(int id)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            var result = (from newsItem in db.News
                          where newsItem.Id == id
                          select newsItem).SingleOrDefault();
            return result;
        }

        internal void UpdateNews(News n)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();

            var editNews = (from newsItem in db.News
                            where newsItem.Id == n.Id
                            select newsItem).First(); ;


            if (n.heading == null) return;
            if (n.body == null) return;
            if (n.date == null) return;

            editNews.body = n.body;
            editNews.heading = n.heading;
            editNews.date = n.date;

            db.SubmitChanges();

        }

        internal void AddNews(News n)
        {
            if (n.heading == null) return;
            if (n.body == null) return;
            if (n.date == null) return;

            DataClasses1DataContext db = new DataClasses1DataContext();
            n.date = DateTime.Now;
            n.Id = db.News.Max(i => i.Id) + 1;
            db.News.InsertOnSubmit(n);
            db.SubmitChanges();
            
        }

    }
}
