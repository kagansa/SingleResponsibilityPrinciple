using Microsoft.AspNetCore.Mvc;
using SingleResponsibility.Business;
using SingleResponsibility.Models;

namespace SingleResponsibility.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        [HttpPost]
        public IActionResult Add(Customer customer)
        {
            CustomerManager customerManager = new CustomerManager();
            //Post ile gelen müşteriyi ekle ve dönen cevabı resulta aktar
            var result = customerManager.Add(customer);
            //eğer false dönerse cevap olarak HttpKodu BadRequest, Mesaj olarakta customerManager dönen mesajı gönder
            if (!result.Success) BadRequest(result.Message);
            //True ise customerManager dönen mesajı gönder
            return Ok(result.Message);
        }
    }
}