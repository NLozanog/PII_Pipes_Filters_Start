using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
            PictureProvider p = new PictureProvider();
            IPicture pic = p.GetPicture("beer.jpg");
            IFilter filter = new FilterGreyscale();
            IFilter filterDos = new FilterNegative();
            IPipe isnull = new PipeNull ();

            IPipe serialDos= new PipeSerial(filterDos,isnull);
            IPipe serial = new PipeSerial(filter, serialDos);
            IPipe serialTres = new PipeFork(serialDos, serial);

            IPicture pic2 = serial.Send(pic);
            IPicture pic3 = serialDos.Send(pic2);
            IPicture pic6 = serialTres.Send(pic);
            
            p.SavePicture(pic2,"..\\..\\beer1.jpg");
            p.SavePicture(pic3,"..\\..\\beer2.jpg");
            p.SavePicture(pic6,"..\\..\\beer3.jpg");

            PictureProvider p2 = new PictureProvider();
            IPicture pic4 = p.GetPicture("luke.jpg");
            IFilter filterTres = new FilterBlurConvolution();

            IPipe serialCuatro = new PipeSerial(filterTres,isnull );
            IPicture pic5 = serialCuatro.Send(pic4);
            
            p.SavePicture(pic5,"..\\..\\luke2.jpg");
        }
    }
}
