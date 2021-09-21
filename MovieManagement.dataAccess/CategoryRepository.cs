using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.dataAccess
{
    public class CategoryRepository : BaseRepository
    {
        public List<Category> SearchCategories()
        {
            return DBContext.Categories.ToList();
        }

        public Category GetCategory(Guid categoryId)
        {
          
                var category = DBContext.Categories.FirstOrDefault(a => a.id == categoryId);
                return category;
            
        }
        public Category GetCategoryByName(String name)
        {

            var lowerCaseName = name.ToLower();
            var category = DBContext.Categories.FirstOrDefault(a => a.Name.ToLower().Contains(lowerCaseName));
            return category;
        }
        public void AddCategory(Category NewCategory)
        {

            DBContext.Categories.Add(NewCategory);
            DBContext.SaveChanges();

        }

        public void DeleteCategory(Guid categoryId)
        {

            var category = DBContext.Categories.FirstOrDefault(a => a.id == categoryId);
            if (category != null)
            {
                DBContext.Categories.Remove(category);
                DBContext.SaveChanges();
            }


        }
        public void UpdateCategory(Category updatedCategory)
        {

            var existingCategory = DBContext.Categories.FirstOrDefault(a => a.id == updatedCategory.id);
            if (existingCategory != null)
            {
                existingCategory.Name = updatedCategory.Name;
                DBContext.SaveChanges();
            }
        }
    }
}
