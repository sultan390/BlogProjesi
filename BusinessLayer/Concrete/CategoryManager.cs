using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {

        ICategoryDal _categoryDal;


        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public Category TGetById(int id)
        {
            return _categoryDal.GetById(id);
        }

        public List<Category> GetList()
        {
            return _categoryDal.GetListAll();
        }

        public void TAdd(Category t)
        {
            _categoryDal.Insert(t);
        }

        public void TDelete(Category t)
        {
            _categoryDal.Delete(t);
        }

        public void TUpdate(Category t)
        {
            _categoryDal.Update(t);
        }







        // EfCategoryRepository efCategoryRepository; // bu sınıf nese üretmedik () gerek yok. 
        //  GenericRepository<Category> repo = new GenericRepository<Category>();   

        /*   public void CategoryAdd(Category category)
        {
            
          /*   if(category.CategoryName!="" && category.CategoryDescription!="" && 
                category.CategoryName.Length>5 && category.CategoryStatus == true ) 
            {
                categoryRepository.AddCategory(category);

            }
            else
            {
                // hata mesajı 
            }*/


        // void CategoryAdd(Category category); //  dışardan gelen parametreye göre ekleme işlemi gerçekleşek
        // ama bu olmaması gereken bir işlem    






    }

}
