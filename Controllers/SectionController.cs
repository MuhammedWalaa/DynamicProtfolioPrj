using DynamicProtfolioPrj.Models.Section;
using DynamicProtfolioPrj.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace DynamicProtfolioPrj.Controllers
{
    public class SectionController : BaseController
    {
        private readonly ISectionService _sectionService;

        public SectionController(ISectionService sectionService, IPageService pageService) : base(pageService)
        {
            _sectionService = sectionService;
        }
        public IActionResult Index()
        {
            return View("Section");
        }
        [HttpPost]
        public JsonResult Add(SectionAddVM sectionAddVM)
        {
            var result = _sectionService.Add(sectionAddVM);
            return Json(result);
        }
        [HttpGet("GetById")]
        public JsonResult GetById(int id)
        {
            return Json(_sectionService.GetById(id));
        }
    }
}
