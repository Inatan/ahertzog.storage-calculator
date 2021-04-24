using GemBox.Document;

namespace Store.Calculator.Domain.Utils
{
    public class PdfCreator
    {
        public void CriaArquivo(string fileName, string valor)
        {
            ComponentInfo.SetLicense("FREE-LIMITED-KEY");

            var document = new DocumentModel();

            var largeFont = new CharacterStyle("Large Font") { CharacterFormat = { Size = 24 } };
            document.Styles.Add(largeFont);


            var section = new GemBox.Document.Section(document);
            document.Sections.Add(section);

            var paragraph = new GemBox.Document.Paragraph(document,
                new SpecialCharacter(document, SpecialCharacterType.LineBreak),
                new SpecialCharacter(document, SpecialCharacterType.LineBreak),
                new SpecialCharacter(document, SpecialCharacterType.LineBreak),
                new SpecialCharacter(document, SpecialCharacterType.LineBreak),
                new SpecialCharacter(document, SpecialCharacterType.LineBreak),
                new SpecialCharacter(document, SpecialCharacterType.LineBreak),
                new SpecialCharacter(document, SpecialCharacterType.LineBreak),
                new SpecialCharacter(document, SpecialCharacterType.LineBreak),
                new SpecialCharacter(document, SpecialCharacterType.LineBreak),
                new SpecialCharacter(document, SpecialCharacterType.LineBreak),
                new SpecialCharacter(document, SpecialCharacterType.LineBreak),
                new GemBox.Document.Run(document, "Valor do Orçamento:")
                {
                    CharacterFormat = { Style = largeFont }
                },
                new SpecialCharacter(document, SpecialCharacterType.LineBreak),
                new GemBox.Document.Run(document, valor)
                {
                    CharacterFormat = { Style = largeFont }
                },
                new SpecialCharacter(document, SpecialCharacterType.LineBreak),
                new SpecialCharacter(document, SpecialCharacterType.LineBreak),
                new SpecialCharacter(document, SpecialCharacterType.LineBreak),
                new SpecialCharacter(document, SpecialCharacterType.LineBreak),
                new SpecialCharacter(document, SpecialCharacterType.LineBreak),
                new GemBox.Document.Run(document, "Observações: ")
                {
                    CharacterFormat = { Style = largeFont, Size = 14 }
                }
            );
            paragraph.ParagraphFormat.Alignment = GemBox.Document.HorizontalAlignment.Center;


            section.Blocks.Add(paragraph);

            Picture picture = new Picture(document, "./res/images/logopdf.png", 200, 211, LengthUnit.Pixel);
            FloatingLayout layout = new FloatingLayout(
                new HorizontalPosition(HorizontalPositionType.Center, HorizontalPositionAnchor.Page),
                new VerticalPosition(1.25, LengthUnit.Centimeter, VerticalPositionAnchor.Page),
                picture.Layout.Size);
            layout.WrappingStyle = TextWrappingStyle.TopAndBottom;

            picture.Layout = layout;
            paragraph.Inlines.Add(picture);

            document.Save(fileName);
        }
    }
}
