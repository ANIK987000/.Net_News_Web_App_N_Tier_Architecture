using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class NewsRepo : IRepo<News, int>
    {
        public void Add(News obj)
        {
            var db = new News_DBEntities();
            var news = new News();
            news.ID = obj.ID;
            news.Title = obj.Title;
            news.CategoryID = obj.CategoryID;
            news.Date = obj.Date;

            db.News.Add(news);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var db = new News_DBEntities();
            var news = db.News.FirstOrDefault(x => x.ID.Equals(id));

            db.News.Remove(news);
            db.SaveChanges();
        }

        public List<News> Get()
        {
            var db = new News_DBEntities();
            return db.News.ToList();
        }

        public News Get(int id)
        {
            var db = new News_DBEntities();
            return db.News.FirstOrDefault(x => x.ID.Equals(id));
        }

        public void Update(News obj, int id)
        {
            var db = new News_DBEntities();
            var news = db.News.Find(id);

            news.ID = obj.ID;
            news.Title = obj.Title;
            news.CategoryID = obj.CategoryID;
            news.Date = obj.Date;

            db.SaveChanges();
        }
    }
}
