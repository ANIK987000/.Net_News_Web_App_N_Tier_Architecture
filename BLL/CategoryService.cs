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
    public class CategoryService
    {
        public static List<CategoryDTO> Get()
        {
            var category = new List<CategoryDTO>();
            var catRepo = new CategoryRepo().Get();
            foreach(var item in catRepo)
            {
                category.Add(new CategoryDTO() {
                        ID=item.ID,
                        Name=item.Name
                });
            }
            return category;
        }

        public static void Create(CategoryDTO category)
        {

            var cat = new CategoryRepo();
            cat.Add(new Category()
            {
                ID = category.ID,
                Name = category.Name,

            });



        }


        public static CategoryDTO Details(int id)
        {
            var cat = new CategoryRepo();
            var data=cat.Get(id);

            var categoryDto = new CategoryDTO();
            categoryDto.ID = data.ID;
            categoryDto.Name = data.Name;
            return categoryDto; 
            
        }


        public static void Delete(int id)
        {
            var cat = new CategoryRepo();
            cat.Delete(id);
          
        }

        public static void Edit(CategoryDTO category,int id)
        {

            var cat = new CategoryRepo();
            var data=cat.Get(id);
            data.ID = id;
            data.Name = category.Name;
            cat.Update(data,id);



        }


    }
}
