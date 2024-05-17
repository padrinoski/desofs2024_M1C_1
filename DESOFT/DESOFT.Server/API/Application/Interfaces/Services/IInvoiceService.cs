using DESOFT.Server.API.Domain.Entities.Invoice;
using DESOFT.Server.API.Domain.Entities.Order;
using static DESOFT.Server.API.Shared.Infrastructure.Result;

namespace DESOFT.Server.API.Application.Interfaces.Services
{
    public interface IInvoiceService
    {

        Task<InvoiceModel> generateInvoiceModel(Order order);

        Task<ServiceResult> generateInvoiceDocument(int orderId);
        
    }
}