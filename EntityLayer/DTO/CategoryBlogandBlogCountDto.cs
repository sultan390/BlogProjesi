using CoreLayer.Entities;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DTO
{
    public class CategoryBlogandBlogCountDto : Category, IDTO
    {

        public int NumberofBloginCategory { get; set; }
        public bool BlogStatus { get; set; }


    }
}
