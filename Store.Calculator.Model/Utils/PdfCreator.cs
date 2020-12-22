﻿using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;

namespace Store.Calculator.Model.Utils
{
    public class PdfCreator
    {
        public void CriaArquivo(string fileName)
        {
            Document document = new Document();
            Page page = new Page(PageSize.Letter, PageOrientation.Portrait, 54.0f);
            document.Pages.Add(page);

            string labelText = " Hello World...\nHellow again \n Hi everyone";
            Label label = new Label(labelText, 0, 0, 504, 100, Font.Helvetica, 18, TextAlign.Center);
            page.Elements.Add(label);
            document.Draw(fileName);
        }
    }
}
