using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.Model
{
    public class database
    {
        private static List<Clanek> clanky = null;
        private static int Id = 5;

        public static List<Clanek> vratClanky()
        {
            if (clanky == null)
            {
                clanky = new List<Clanek>();
                clanky.Add(new Clanek() { autor = "Autor1", id = 1, nazev = "Nadpis1", datumVytvoreni = DateTime.Today.ToString("d.M.yyyy"), text = "Donec id elit non mi porta gravida at eget metus. Fusce dapibus, tellus ac cursus commodo, tortor mauris condimentum nibh, ut fermentum massa justo sit amet risus. Etiam porta sem malesuada magna mollis euismod. Donec sed odio dui" });
                clanky.Add(new Clanek() { autor = "Autor2", id = 2, nazev = "Nadpis2", datumVytvoreni = DateTime.Today.ToString("d.M.yyyy"), text = "Text2" });
                clanky.Add(new Clanek() { autor = "Autor3", id = 3, nazev = "Nadpis3", datumVytvoreni = DateTime.Today.ToString("d.M.yyyy"), text = "Text3" });
                clanky.Add(new Clanek() { autor = "Autor4", id = 4, nazev = "Nadpis4", datumVytvoreni = DateTime.Today.ToString("d.M.yyyy"), text = "Text4" });
                clanky.Add(new Clanek() { autor = "Autor5", id = 5, nazev = "Nadpis5", datumVytvoreni = DateTime.Today.ToString("d.M.yyyy"), text = "Text5" });
            }
            return (clanky);
        }

        public static void pridatCL(Clanek cl)
        {
          
            cl.id = ++Id;
            cl.datumVytvoreni = DateTime.Today.ToString("d.M.yyyy");
            cl.autor = "Autor" + Id;
            clanky.Add(new Clanek {autor=cl.autor,nazev=cl.nazev,id=cl.id,datumVytvoreni=cl.datumVytvoreni,text=cl.text });
        }

        public static void smazatCL(int id)
        {
            foreach(Clanek cl in clanky)
            {
                if (cl.id == id)
                {
                    clanky.Remove(cl);
                    break;
                }


            }


        }


    }
}
