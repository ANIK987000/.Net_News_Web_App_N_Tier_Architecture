using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public  class CategoryRepo : IRepo<Category, int>
    {
        public void Add(Category obj)
        {
            var db = new News_DBEntities();
            var category = new Category();
            category.ID = obj.ID;
            category.Name = obj.Name;

            db.Categorys.Add(category);
            db.SaveChanges();

        }

        public void Delete(int id)
        {
            var db = new News_DBEntities();
            var category= db.Categorys.FirstOrDefault(x => x.ID.Equals(id));

            db.Categorys.Remove(category);
            db.SaveChanges();
        }

        public List<Category> Get()
        {
            var db = new News_DBEntities();
            return db.Categorys.ToList();
        }

        public Category Get(int id)
        {
            var db = new News_DBEntities();
            return db.Categorys.FirstOrDefault(x => x.ID.Equals(id));
        }

        public void Update(Category obj, int id)
        {
            var db = new News_DBEntities();
            var category = db.Categorys.Find(id);

            category.ID = obj.ID;
            category.Name = obj.Name;

            db.SaveChanges();

        }
    }
}
