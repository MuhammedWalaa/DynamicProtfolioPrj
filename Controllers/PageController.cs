using DynamicProtfolioPrj.Models.Page;
using DynamicProtfolioPrj.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace DynamicProtfolioPrj.Controllers
{
    public class PageController : BaseController
    {
        private readonly ISectionService _sectionService;
        private readonly IPageService _pageService;
        
        public PageController(ISectionService sectionService, IPageService pageService): base(pageService)
        {
            _sectionService = sectionService;
            _pageService = pageService;
        }
        public IActionResult Index()
        {
            ViewBag.Sections = _sectionService.GetSelectList();
            return View();
        }
        [HttpPost]
        public IActionResult Add(PageAddVM pageAddVM)
        {
            var result = _pageService.Add(pageAddVM);
            if (result.Success)
            {
                return RedirectToAction("GetById", "Page", new { id = int.Parse(result.Data) });
            }
            return Json(result);
        }
        [HttpGet]
        public IActionResult GetById(int id)
        {
            return View("View", _pageService.GetById(id));
        }
    }
}
