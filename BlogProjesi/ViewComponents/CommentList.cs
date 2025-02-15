using BlogProjesi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogProjesi.ViewComponents
{
    public class CommentList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var commentValues = new List<UserComment>
            {
                new UserComment
                {
                    ID= 1,
                    UserName="murat"
                },
                new UserComment
                {
                    ID=2,
                    UserName="mesut"
                },


                new UserComment
                {
                    ID=3,
                    UserName="melisa"
                }
            };

            return View(commentValues);
        }


    }
}
