using BloodBank.Core.Models;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BloodBank.Infrastructure.Reports
{
    public class StockReportDocument : IDocument
    {
        private readonly List<StockReportModel> _data;

        public StockReportDocument(List<StockReportModel> data)
        {
            _data = data;
        }

        public DocumentMetadata GetMetadata() => DocumentMetadata.Default;

        public void Compose(IDocumentContainer container)
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(2, Unit.Centimetre);
                page.PageColor(Colors.White);
                page.DefaultTextStyle(x => x.FontSize(14)); 

                page.Header()
                    .Text("Blood Stock")
                    .SemiBold().FontSize(24).FontColor(Colors.Black)
                    .AlignCenter();

                page.Content()
                    .PaddingVertical(1, Unit.Centimetre)
                    .Column(x =>
                    {
                        x.Spacing(10);

                        x.Item().Table(t =>
                        {
                            t.ColumnsDefinition(c =>
                            {
                                c.RelativeColumn(2); 
                                c.RelativeColumn(2);
                                c.RelativeColumn(3);
                                c.RelativeColumn(3);
                            });

                            t.Cell().Row(1).Column(1).Element(Block).Text("Blood Type").SemiBold();
                            t.Cell().Row(1).Column(2).Element(Block).AlignLeft().PaddingLeft(6).Text("RH Factor").SemiBold();
                            t.Cell().Row(1).Column(3).Element(Block).Text("Quantity (ML)").SemiBold();
                            t.Cell().Row(1).Column(4).Element(Block).Text("Total donations").SemiBold();

                            uint rowIndex = 2;

                            foreach (var item in _data)
                            {
                                t.Cell().Row(rowIndex).Column(1).Element(Entry).Text(item.BloodType.ToString());
                                t.Cell().Row(rowIndex).Column(2).Element(Entry).Text(item.RHFactor.ToString());
                                t.Cell().Row(rowIndex).Column(3).Element(Entry).Text(item.QuantityMl.ToString());
                                t.Cell().Row(rowIndex).Column(4).Element(Entry).Text(item.QtdDoacoes.ToString());

                                rowIndex++;
                            }
                        });
                    });

                page.Footer()
                    .AlignRight()
                    .Text(x =>
                    {
                        x.Span($"{DateTime.Now} - Página ").FontSize(11);
                        x.CurrentPageNumber();
                    });
            });
        }

        static IContainer Block(IContainer container)
        {
            return container
                   .Border(1)
                   .Background(Colors.Grey.Lighten3)
                   .ShowOnce()
                   .MinWidth(50)
                   .MinHeight(20)
                   .AlignCenter()
                   .AlignMiddle();
        }

        static IContainer Entry(IContainer container)
        {
            return container
                   .Border(1)
                   .PaddingVertical(1)
                   .PaddingHorizontal(6)
                   .ShowOnce()               
                   .AlignCenter()
                   .AlignMiddle();
        }
    }
}
