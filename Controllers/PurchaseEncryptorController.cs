using System;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TaxComputationAPI.Manager;
using TaxComputationSoftware.Interfaces;

namespace TaxComputationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseEncryptorController :ControllerBase
    {
        private readonly IEmailService _emailService;
        private readonly ILogger<PurchaseEncryptorController> _logger;

        public PurchaseEncryptorController(IEmailService emailService, ILogger<PurchaseEncryptorController> logger)
        {
            _emailService = emailService;
            _logger = logger;
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

                _logger.LogError(ex.Message);
                await _emailService.ExceptionEmail(MethodBase.GetCurrentMethod().DeclaringType.Name, ex.Message);

                return BadRequest("Could not encrypt with the payload provided");
            }
              
          

        }
    }
}
