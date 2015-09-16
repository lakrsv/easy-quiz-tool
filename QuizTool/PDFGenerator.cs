using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System.IO;

namespace QuizTool
{
    public class PDFGenerator
    {
        private static List<QuizQuestion> Questions = new List<QuizQuestion>();
        public static void GenerateReport(string Title, string StudentName, List<String> StudentAnswers, int studentScore, decimal percentage)
        {
            Questions = GetQuizFile.TheQuestions;

            //Create Document and Give it a Title.
            PdfDocument document = new PdfDocument();
            document.Info.Title = StudentName + " " + Title;

            //Create an empty PDF page.
            PdfPage page1 = document.AddPage();
            PdfPage page = page1;
            //Get an XGraphics object for drawing
            XGraphics gfx1 = XGraphics.FromPdfPage(page);
            XGraphics gfx = gfx1;

            //Create a font
            XFont titleFont = new XFont("Verdana", 20, XFontStyle.Bold);
            XFont subtitleFont = new XFont("Verdana", 15, XFontStyle.Bold);
            XFont questionFont = new XFont("Verdana", 10, XFontStyle.Bold);
            XFont answerFont = new XFont("Verdana", 10, XFontStyle.Regular);

            //Draw the text
            gfx.DrawString(string.Format("Quiz: {0}", Title), titleFont, XBrushes.Black, new XRect(0, 0, page.Width, page.Height), XStringFormats.TopCenter);
            gfx.DrawString(string.Format("Student Name: {0}", StudentName), subtitleFont, XBrushes.Black, new XRect(0, 30, page.Width, page.Height), XStringFormats.TopCenter);

            //Draw questions
            int increment = 20;
            int incrementtwo = 0;
            const int pageHeight = 842;
            int modifier = 0;
            int lastipage = 0;
            for(int i = 0; i < Questions.Count; i++)
            {
                string correct;
                if(StudentAnswers[i] == Questions[i].Answer)
                {
                    correct = "Correct!";
                }
                else
                {
                    correct = "Incorrect!";
                }
                if((70 + modifier + incrementtwo + i * increment + modifier) > pageHeight)
                {
                    //Make a new page.
                    PdfPage page2 = new PdfPage();
                    page2 = document.AddPage();
                    page = page2;
                    gfx = XGraphics.FromPdfPage(page);
                    //gfx = gfx2;
                    modifier -=(60 + incrementtwo + (i -lastipage) * increment);
                    lastipage = i;

                }
                gfx.DrawString(string.Format("Question: {0}", Questions[i].Question), questionFont, XBrushes.Black, new XRect(0, 60 + modifier +incrementtwo + i * increment, page.Width, page.Height), XStringFormats.TopCenter);
                gfx.DrawString(string.Format("Student Answer: {0} - {1}", StudentAnswers[i], correct), answerFont, XBrushes.Black, new XRect(0, 70 + modifier +incrementtwo + i * increment, page.Width, page.Height), XStringFormats.TopCenter);

                incrementtwo += 10;
            }
            if ((70 + modifier + incrementtwo + Questions.Count * increment) > pageHeight)
            {
                //Make a new page.
                PdfPage page3 = new PdfPage();
                page3 = document.AddPage();
                page = page3;
                gfx = XGraphics.FromPdfPage(page);
                //gfx = gfx3;
                modifier -= (60 + incrementtwo + (Questions.Count - lastipage) * increment);

            }
            //Draw Sum of Scores
            gfx.DrawString(string.Format("Sum: {0}/{1}. Percentage: {2}%", studentScore, Questions.Count, percentage), titleFont, XBrushes.Black, new XRect(0, 70 + modifier + incrementtwo + Questions.Count * increment, page.Width, page.Height), XStringFormats.TopCenter);

            //Set filename equal to Title - StudentName
            string tempfilename = string.Format("{0} - {1}.pdf", Title, StudentName);

            //Remove any illegal characters from filename
            var illegalChars = Path.GetInvalidFileNameChars();
            string filename = new string(tempfilename.Where(x => !illegalChars.Contains(x)).ToArray());

            document.Save(filename);
            System.Diagnostics.Process.Start(filename);
        }
    }
}
