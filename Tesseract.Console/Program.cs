using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesseract;

namespace Tesseract_Full_Framework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var pathImage = @"C:\Projetos\tesseract-fea\images\Etiqueta-1.jpg";
            try
            {
                var pathEngine = @"C:\Projetos\tesseract-fea\Tesseract.Console\tessdata";

                using (var engine = new TesseractEngine(pathEngine, "eng", EngineMode.Default))
                {
                    using (var img = Pix.LoadFromFile(pathImage))
                    {
                        using (var page = engine.Process(img))
                        {
                            var text = page.GetText();
                            Console.WriteLine("Text: \n{0}", text);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Trace.TraceError(e.ToString());
                Console.WriteLine("Unexpected Error: " + e.Message);
                Console.WriteLine("Details: ");
                Console.WriteLine(e.ToString());
            }

            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}
