using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaxComputationAPI.Manager;

namespace TaxComputationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseEncryptorController :ControllerBase
    {
        public PurchaseEncryptorController()
        {
        }


       
        [HttpGet("{transactionId}/{amount}/{rootKey}")]
        public async Task<IActionResult> Encryptor(string transactionId,string amount, string rootKey)
        {

            try
            {
                PurchaseEncryptor purchaseEncryptor = new PurchaseEncryptor();
                var amountValue = double.Parse(amount);
                var value = purchaseEncryptor.GeneratePurchaseString(transactionId, amountValue, rootKey);

                return Ok(new { value = value });
            }
            catch (Exception ex){
                return BadRequest("Could not encrypt with the payload provided");
            }
              
          

        }
    }
}
