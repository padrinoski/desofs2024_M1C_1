using DESOFT.Server.API.Application.Interfaces.Repositories.Common;
using DESOFT.Server.API.Application.Interfaces.Services;
using DESOFT.Server.API.Authorization;
using DESOFT.Server.API.Shared.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using static DESOFT.Server.API.Shared.Infrastructure.Result;

namespace DESOFT.Server.API.Controllers.GenerateInvoice
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableRateLimiting("fixed")]
    public class GenerateInvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;

        public GenerateInvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpGet(nameof(GenerateInvoiceDocument) + "/{orderId}")]
        [TypeFilter(typeof(PodeAcederBackOfficeFilter))]
        public async Task<ServiceResult<byte[]>> GenerateInvoiceDocument(int orderId)
        {
            var result = new ServiceResult<byte[]>();
            try
            {
                var resultFromCall = await _invoiceService.generateInvoiceDocument(orderId);
                if (resultFromCall.Success)
                {
                    result.Data = resultFromCall.Data;
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