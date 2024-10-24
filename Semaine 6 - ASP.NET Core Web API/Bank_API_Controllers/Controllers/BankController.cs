using Microsoft.AspNetCore.Mvc;

namespace Bank_API_Controllers.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class BankController : ControllerBase
    {

        // GET /api/Bank/tva
        [HttpGet("tva")]
        public double TVA(int price, string country)
        {
            if (country == "BE") return price * 1.21;
            if (country == "FR") return price * 1.20;
            return 0;
        }
    }

}

