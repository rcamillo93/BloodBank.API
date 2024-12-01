using BloodBank.Core.Entity;
using BloodBank.Core.Helpers;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace BloodBank.Infrastructure.Reports
{
    public class DonationsReportDocument : IDocument
    {
        private readonly List<Donation> _data;
        private readonly DateTime _startDate;
        private readonly DateTime _endDate;

        public DonationsReportDocument(List<Donation> data, DateTime startDate, DateTime endDate)
        {
            _data = data;
            _startDate = startDate;
            _endDate = endDate;
        }

        public DocumentMetadata GetMetadata() => DocumentMetadata.Default;

        public void Compose(IDocumentContainer container)
        {            
            var groupedDonations = _data
                .GroupBy(d => new { d.Donor.BloodType, d.Donor.RhFactor })
                .OrderBy(g => g.Key.BloodType)
                .ThenBy(g => g.Key.RhFactor);

            container.Page(page =>
            {
            page.Size(PageSizes.A4);
            page.Margin(1, Unit.Centimetre);
            page.PageColor(Colors.White);
            page.DefaultTextStyle(x => x.FontSize(12));

            page.Header()
                .AlignCenter()
                .Column(column =>
                {
                    // Título
                    column.Item().Text(t =>
                    {
                        t.Span("Donations by Blood Type in the period")
                            .SemiBold().FontSize(18);
                    });

                    // Datas em uma nova linha
                    column.Item().AlignRight().Text(t =>
                    {
                        t.Span($"{_startDate.ToShortDateString()} - {_endDate.ToShortDateString()}")
                            .SemiBold().FontSize(10).LineHeight(1);
                    });
                });

                page.Content()
                  .PaddingVertical(2, Unit.Centimetre)
                  .Column(column =>
                  {

                      foreach (var group in groupedDonations)
                      {
                          var bloodType = group.Key.BloodType.ToString();
                          var rhFactor = group.Key.RhFactor.ToString();


                          column.Item().Text($"{bloodType} {rhFactor}")
                              .FontSize(16)                              
                              .Bold()
                              .AlignCenter();

                          column.Spacing(10);

                          column.Item().Table(t =>
                          {
                              t.ColumnsDefinition(c =>
                              {
                                  c.RelativeColumn(3);
                                  c.RelativeColumn(2);
                                  c.RelativeColumn(2);
                                  c.RelativeColumn(3);
                                  c.RelativeColumn(3);
                              });

                              t.Cell().Row(1).Column(1).Element(Block).Text("Name").SemiBold();
                              t.Cell().Row(1).Column(2).Element(Block).Text("Gender").SemiBold();
                              t.Cell().Row(1).Column(3).Element(Block).Text("Age").SemiBold();
                              t.Cell().Row(1).Column(4).Element(Block).Text("Donation Date").SemiBold();
                              t.Cell().Row(1).Column(5).Element(Block).Text("Quantity (ml)").SemiBold();

                              uint rowIndex = 2;
                              decimal total = 0;

                              foreach (var donation in group)
                              {
                                  var donor = donation.Donor;
                                  var donationDate = donation.DonationDate.ToShortDateString().ToString();
                                  var age = donor.DateBirth.GetCurrentAge().ToString();

                                  total += donation.QuantityMl;

                                  t.Cell().Row(rowIndex).Column(1).Element(Entry).Text(donor.FullName);
                                  t.Cell().Row(rowIndex).Column(2).Element(Entry).Text(donor.Gender.ToString());
                                  t.Cell().Row(rowIndex).Column(3).Element(Entry).Text(age);
                                  t.Cell().Row(rowIndex).Column(4).Element(Entry).Text(donationDate);
                                  t.Cell().Row(rowIndex).Column(5).Element(Entry).Text(donation.QuantityMl.ToString());

                                  rowIndex++;
                              }

                              t.Cell().Row(rowIndex).Column(1).PaddingTop(5).Text("Total").FontSize(14).Bold().AlignCenter();
                              t.Cell().Row(rowIndex).Column(5).PaddingTop(5).Text(total.ToString()).FontSize(14).Bold().AlignCenter();

                          });

                          //column.Item().Height(10); 
                          column.Item().PaddingVertical(20);
                      }

                  });

                page.Footer()
                    .AlignRight()
                    .Text(x =>
                    {
                        x.Span($"Generated: {DateTime.Now:dd/MM/yyyy} - Page ");
                        x.CurrentPageNumber();
                    });
            });
        }

        static IContainer Entry(IContainer container)
        {
            return container
                   .BorderBottom(1)
                   .PaddingVertical(1)
                   .PaddingHorizontal(6)
                   .ShowOnce()
                   .AlignCenter()
                   .AlignMiddle();
        }

        static IContainer Block(IContainer container)
        {
            return container
                   .BorderBottom(1)
                   .Background(Colors.Grey.Lighten3)
                   .ShowOnce()
                   .MinWidth(50)
                   .MinHeight(20)
                   .AlignCenter()
                   .AlignMiddle();
        }

    }
}

