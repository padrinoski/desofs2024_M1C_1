using AutoMapper;
using DESOFT.Server.API.Application.Interfaces.Repositories.Common;
using DESOFT.Server.API.Application.Interfaces.Services;
using DESOFT.Server.API.Domain.Entities.Invoice;
using DESOFT.Server.API.Domain.Entities.Order;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using static DESOFT.Server.API.Shared.Infrastructure.Result;

namespace DESOFT.Server.API.Application.Services
{
    public class InvoiceService : IInvoiceService
    {

        //TODO: Implementar

        private readonly IOrderRepository _orderRepository;
        private readonly ILogger<InvoiceService> _logger;
        private readonly IMapper _mapper;

        public InvoiceService(IOrderRepository orderRepository, ILogger<InvoiceService> logger, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<InvoiceModel> generateInvoiceModel(Order order)
        {
            InvoiceModel invoiceModel = new InvoiceModel();

            invoiceModel.InvoiceNumber = new Random().Next(1000, 9999); //Check DB for last invoice number

            invoiceModel.IssueDate = DateTime.Now;

            invoiceModel.CustomerAddress = order.Address;

            invoiceModel.Items = [.. order.ShoppingCart.ShoppingCartItem];

            return invoiceModel;
        }

        public async Task<ServiceResult> generateInvoiceDocument(int orderId)
       {
            _logger.LogInformation("GenerateInvoiceDocument entered");

            var result = new ServiceResult();

            try
            {

                var order = await _orderRepository.GetOrder(orderId);

                order = order ?? throw new Exception("Order not found");

                var model = await generateInvoiceModel(order);
                var document = new InvoiceDocument(model);
                //byte[] generatedDocument = document.GeneratePdf();

                //Save document in DTO format
                document.GeneratePdfAndShow();
                //Create record in DB


            }
            catch (Exception ex) {
                _logger.LogError(ex.Message);
            }

            return result;

       }
       

    }

    public class InvoiceDocument : IDocument
    {
        public InvoiceModel Model { get; }

        public InvoiceDocument(InvoiceModel model)
        {
            Model = model;
        }

        public DocumentMetadata GetMetadata() => DocumentMetadata.Default;
        public DocumentSettings GetSettings() => DocumentSettings.Default;

        public void Compose(IDocumentContainer container)
        {
            container
                .Page(page =>
                {
                    page.Margin(50);
                
                    page.Header().Element(ComposeHeader);
                    page.Content().Element(ComposeContent);

                        
                    page.Footer().AlignCenter().Text(x =>
                    {
                        x.CurrentPageNumber();
                        x.Span(" / ");
                        x.TotalPages();
                    });
                });
        }

        void ComposeHeader(IContainer container)
        {
            var titleStyle = TextStyle.Default.FontSize(20).SemiBold().FontColor(Colors.Blue.Medium);
        
            container.Row(row =>
            {
                row.RelativeItem().Column(column =>
                {
                    column.Item().Text($"Invoice #{Model.InvoiceNumber}").Style(titleStyle);

                    column.Item().Text(text =>
                    {
                        text.Span("Issue date: ").SemiBold();
                        text.Span($"{Model.IssueDate:d}");
                    });
                    
                    column.Item().Text(text =>
                    {
                        text.Span("Customer address: ").SemiBold();
                        text.Span(Model.CustomerAddress);
                    });
                });

                row.ConstantItem(100).Height(50).Placeholder();
            });
        }

        void ComposeContent(IContainer container)
        {
            container.PaddingVertical(40).Column(column =>
            {
                column.Spacing(5);

                column.Item().Element(ComposeTable);

            });
        }

        void ComposeTable(IContainer container)
        {
            container.Table(table =>
            {
                // step 1
                table.ColumnsDefinition(columns =>
                {
                    columns.ConstantColumn(25);
                    columns.RelativeColumn(3);
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                });
                
                // step 2
                table.Header(header =>
                {
                    header.Cell().Element(CellStyle).Text("#");
                    header.Cell().Element(CellStyle).Text("Product");
                    header.Cell().Element(CellStyle).AlignRight().Text("Unit price");
                    header.Cell().Element(CellStyle).AlignRight().Text("Quantity");
                    header.Cell().Element(CellStyle).AlignRight().Text("Total");
                    
                    static IContainer CellStyle(IContainer container)
                    {
                        return container.DefaultTextStyle(x => x.SemiBold()).PaddingVertical(5).BorderBottom(1).BorderColor(Colors.Black);
                    }
                });
                
                // step 3
                foreach (var item in Model.Items)
                {
                    table.Cell().Element(CellStyle).Text((Model.Items.IndexOf(item) + 1).ToString());
                    table.Cell().Element(CellStyle).Text(item.ComicBook.Title);
                    table.Cell().Element(CellStyle).AlignRight().Text($"{item.ComicBook.Price}€");
                    table.Cell().Element(CellStyle).AlignRight().Text(item.Quantity.ToString());
                    table.Cell().Element(CellStyle).AlignRight().Text($"{item.ComicBook.Price * item.Quantity}€");
                    
                    static IContainer CellStyle(IContainer container)
                    {
                        return container.BorderBottom(1).BorderColor(Colors.Grey.Lighten2).PaddingVertical(5);
                    }
                }
            });
        }
    }
    
}