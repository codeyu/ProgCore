using EfCore.Application;
using Microsoft.AspNetCore.Mvc;

namespace EfCore.Controllers
{
    public class RecordController : Controller
    {
        private readonly RecordService _service;
        public RecordController(RecordService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult New()
        {
            var model = _service.GetNewRecordViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult New(string firstname, string lastname)
        {
            _service.SaveRecord(firstname, lastname);
            return RedirectToAction("index", "home");
        }
    }
}