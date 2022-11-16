using BLL.DTOs;
using DAL.EF;
using DAL.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class NewsService
    {
        public static List<NewsDTO> Get()
        {
            var news = new List<NewsDTO>();
            var newsRepo = new NewsRepo().Get();
            foreach (var item in newsRepo)
            {
                news.Add(new NewsDTO()
                {
                    ID = item.ID,
                    Title=item.Title,
                    CategoryID=item.CategoryID,
                    Date=item.Date
                });
            }
            return news;
        }

        public static void Create(NewsDTO news )
        {

            var newss = new NewsRepo();
            newss.Add(new News()
            {
                ID = news.ID,
                Title=news.Title,
                CategoryID=news.CategoryID,
                Date=DateTime.Now

            });



        }


        public static NewsDTO Details(int id)
        {
            var newss = new NewsRepo();
            var data = newss.Get(id);

            var newssDto = new NewsDTO();
            newssDto.ID = data.ID;
            newssDto.Title = data.Title;
            newssDto.CategoryID = data.CategoryID;
            newssDto.Date = data.Date;

            return newssDto;

        }


        public static void Delete(int id)
        {
            var cat = new NewsRepo();
            cat.Delete(id);

        }

        public static void Edit(NewsDTO news, int id)
        {

            var cat = new NewsRepo();
            var data = cat.Get(id);
            data.ID = id;
            data.Title = news.Title;
            data.CategoryID = news.CategoryID;
            data.Date = DateTime.Now;
            cat.Update(data, id);



        }
    }
}
