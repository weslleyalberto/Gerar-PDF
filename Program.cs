using Gerar_PDF.Services;
using iText.IO.Image;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout;
using iText.Layout.Element;

class Program
{
    static void Main(string[] args)
    {
        PdfWriter write = new PdfWriter("C:\\Temp\\demo.pdf");
        PdfDocument pdf = new PdfDocument(write);
        Document document = new Document(pdf);
        Image img = new(ImageDataFactory.Create(@"C:\\Users\\wesll\\source\\repos\\Gerar-PDF\\Resources\\Img\\logo2-3.png"));
            
        Paragraph header = new Paragraph("Consulta Endereço Por CEP")
            .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
            .SetFontSize(20);
        var endereco = ServiceAPI.GetEnderecoAsync("74603110").Result;

        Paragraph paragraphCidade = new(endereco.Cidade);
        Paragraph paragraphEstado = new(endereco.Estado);
        Paragraph paragraphLogradouro = new(endereco.Logradouro == "" ? "Cidade com CEP Universal" : endereco.Logradouro);
        LineSeparator ls = new(new SolidLine());
      /*  Table table = new(2, false);
        Cell cell11 = new Cell(1, 1)
           .SetBackgroundColor(ColorConstants.GRAY)
           .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
           .Add(new Paragraph("State"));
        Cell cell12 = new Cell(1, 1)
           .SetBackgroundColor(ColorConstants.GRAY)
           .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
           .Add(new Paragraph("Capital"));

        Cell cell21 = new Cell(1, 1)
           .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
           .Add(new Paragraph("New York"));
        Cell cell22 = new Cell(1, 1)
           .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
           .Add(new Paragraph("Albany"));

        Cell cell31 = new Cell(1, 1)
           .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
           .Add(new Paragraph("New Jersey"));
        Cell cell32 = new Cell(1, 1)
           .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
           .Add(new Paragraph("Trenton"));

        Cell cell41 = new Cell(1, 1)
           .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
           .Add(new Paragraph("California"));
        Cell cell42 = new Cell(1, 1)
           .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
           .Add(new Paragraph("Sacramento"));
        table.AddCell(cell11);
        table.AddCell(cell12);
        table.AddCell(cell21);
        table.AddCell(cell22);
        table.AddCell(cell31);
        table.AddCell(cell32);
        table.AddCell(cell41);
        table.AddCell(cell42);*/
        document.Add(img);  
        document.Add(header);
        document.Add(ls);
        document.Add(paragraphCidade);
        document.Add(paragraphEstado);
        document.Add(paragraphLogradouro);
       // document.Add(table);    
        document.Close();

    }
}