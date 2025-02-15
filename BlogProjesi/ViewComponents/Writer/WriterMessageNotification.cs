using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogProjesi.ViewComponents.Writer
{
    public class WriterMessageNotification : ViewComponent
    {
        Message2Manager mm = new Message2Manager(new EfMessage2Repository());
        Context c = new Context();

        public async Task<IViewComponentResult> InvokeAsync() // burda yaptığımız ınvoke mutlaka olmalı laoutta  yaptığın ınvoken karşılık bulması için 
        {
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();


            int id = 2;

            var values = mm.GetInboxListByWriter(id);

            return View(values);



        }

    }
}
