using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Category
    {
        // değişken türü isim {get;set;} prop tab tab 
        [Key]
        public int CategoryID { get; set; }

        public string CategoryName { get; set; }

        public String CategoryDescription { get; set; }

        public bool CategoryStatus { get; set; }

        // ilişki oluşturmak için yapıyoruz. 

        public List<Blog> Blogs { get; set; }
        public List<Category> Categories { get; set; }






        //public virtual ICollection<Blog> Blogs { get; set; }
    }
}
