using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogProjesi.ViewComponents.Writer
{
    public class WriterNotification : ViewComponent
    {

        NotificationManager nm = new NotificationManager(new EfNotificationRepository());

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = nm.GetList();
            return View(values);
        }
    }
}
