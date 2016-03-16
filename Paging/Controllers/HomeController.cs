using System.Linq;
using System.Web.Mvc;
using Paging.Models;

namespace Paging.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        // در صورتی که بر روی اکشن متد نوع درخواست مشخص نباشد می‌توان در حالت
        // مختلف به صورت 
        // Get و Post
        // استفاده نمود. در این مثال با پست بک شدن درخواست به صورت 
        // Get 
        // به سرور ارسال خواهد شد و در غیر اینصورت درخواستی 
        // Ajax
        // روبرو خواهیم بود
        public ActionResult Index(int skip = 0, int take = 30)
        {
            using (var db = new ApplicationDbContext())
            {
                // مدل
                var model = db.Persons.OrderBy(z=>z.Id).Skip(skip * take).Take(take).ToList();
                // برسی می‌شود درخواست به صورت 
                // Ajax
                // ارسال شده است.
                if (Request.IsAjaxRequest()) return PartialView("Partial/_Persons", model);
                // در صورتی که درخواست به صورت 
                // Ajax
                // ارسال نشده باشد شرط برسی نمی‌شود و کد زیر فراخوانی خواهد شد
                return View(model);
            }
        }
    }
}