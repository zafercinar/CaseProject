using CaseProject.Business.Services.Abstract;
using CaseProject.DataAccess.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CaseProject.WebUI.Controllers
{
    public class WordController : Controller
    {
        private readonly IWordService _wordService;

        public WordController(IWordService wordService)
        {
            _wordService = wordService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetWordList()
        {
            var orderbyDirection = Request.Form["order[0][dir]"].FirstOrDefault();
            var arananDeger = Request.Form["search[value]"].FirstOrDefault();
            int limit = Convert.ToInt32(Request.Form["length"].FirstOrDefault() ?? "0");
            int page = Convert.ToInt32(Request.Form["start"].FirstOrDefault() ?? "0");
            var draw = Request.Form["draw"].FirstOrDefault();

            var data = _wordService.GetRandomTextListAsync().GetAwaiter().GetResult().Data;

            //toplam kayıt sayısını tutan property
            int recordsTotal = data.Count();

            //kriterlere uygun kaydı seçen kısım
            var dataResult = _wordService.GetRandomTextListWithPaginationAsync(
                filter: string.IsNullOrEmpty(arananDeger) ? null : d => d.Text.ToLower().Contains(arananDeger.ToLower()),
                orderBy: orderbyDirection,
                page: page == 0 ? 1 : page,
                limit: limit == 0 ? 1 : limit
                ).GetAwaiter().GetResult().Data;

            // kriterlere uygun bulunan kayıt sayısını tutan property
            int recordsFiltered = dataResult.Count();

            var jsonResult = new { draw = draw, recordsTotal = recordsTotal, recordsFiltered = recordsFiltered, data = dataResult };

            return Json(jsonResult);
        }
    }
}

