using DynamicProtfolioPrj.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DynamicProtfolioPrj.Controllers
{
    public abstract class BaseController : Controller
    {
        private readonly IPageService _pageService;

        public BaseController(IPageService pageService)
        {
            _pageService = pageService;
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ViewBag.pages = _pageService.GetSelectList();
            base.OnActionExecuting(filterContext);
        }
    }
}
