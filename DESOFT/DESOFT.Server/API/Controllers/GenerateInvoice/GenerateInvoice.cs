using DESOFT.Server.API.Application.Interfaces.Repositories.Common;
using DESOFT.Server.API.Application.Interfaces.Services;
using DESOFT.Server.API.Shared.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using static DESOFT.Server.API.Shared.Infrastructure.Result;

namespace DESOFT.Server.API.Controllers.GenerateInvoice
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenerateInvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;

        public GenerateInvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpPost(nameof(GenerateInvoiceDocument) + "/{orderId}")]
        public async Task<ServiceResult> GenerateInvoiceDocument(int orderId)
        {
            var result = new ServiceResult();
            try
            {
                var resultFromCall = await _invoiceService.generateInvoiceDocument(orderId);
                if (resultFromCall.Success)
                {
                    result.Messages.Add(new KeyVal { Key = "Invoice was generated for order " + orderId + "." });
                }
                else
                {
                    result.Errors.Add(new KeyVal { Key = "Order not found." });
                }
            }
            catch (Exception ex)
            {
                result.Errors.Add(new KeyVal { Key = "Error processing the request. Exception" + ex.Message });
            }
            return result;
        }
    }
}