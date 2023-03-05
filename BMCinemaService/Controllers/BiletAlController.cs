using BMCinemaService.Models;
using Microsoft.AspNetCore.Mvc;

namespace BMCinemaService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BiletAlController : Controller
    {
        [HttpPost]
        public IActionResult addNew(BiletAlParam vm)
        {
            BiletAl m = new BiletAl();
            m.Ad = vm.Ad;
            m.Soyad = vm.Soyad;
            m.Gsm = vm.Gsm;
            m.Mail = vm.Mail;
            m.FilmId = vm.Film;
            m.SeansId = vm.Seans;

            BmcinemaContext ctx = new BmcinemaContext();
            ctx.BiletAls.Add(m);
            ctx.SaveChanges();
            return Ok("Kayıt başarılıdır");

        }
    }
}
