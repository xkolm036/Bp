using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace data.Model
{
    public class Clanek
    {
        public int id { get; set; }
        [Required(ErrorMessage="Zadejte název")]
        public string nazev { get; set; }
        public string autor { get; set; }
        public string datumVytvoreni { get; set; }
        [AllowHtml]
        [Required(ErrorMessage = "Obsah nesmí být prázdný")]
        public string text { get; set; }

        /// <summary>
        /// Prida článek do databáze
        /// </summary>
        public static void pridejDoDB(Clanek cl)
        {

            Clanky1 entita = new Clanky1();
            entita.Autor = "tst";//cl.autor;
            entita.Datum = DateTime.Now.ToString("dd.MM.yyyy");//cl.datumVytvoreni;
            entita.Nazev = cl.nazev;
            entita.Text = cl.text;
            // entita.id = cl.id;

            using (clankyEntities context = new clankyEntities())
            {
                context.Clanky1.Add(entita);
                context.SaveChanges();
            }

        }
        /// <summary>
        /// Vybere z db článek s určitým id
        /// </summary>
        public static Clanek vyberZDb(int id)
        {
            Clanek cl = new Clanek();
            using (clankyEntities context = new clankyEntities())
            {
                try
                {
                    Clanky1 clZdb = new Clanky1();
                    clZdb = context.Clanky1.FirstOrDefault(c => c.Id == id);

                    cl.id = clZdb.Id;
                    cl.autor = clZdb.Autor;
                    cl.datumVytvoreni = clZdb.Datum;
                    cl.nazev = clZdb.Nazev;
                    cl.text = clZdb.Text;
                }
                catch
                {
                    return null;
                }
            }
            return cl;
        }
        /// <summary>
        /// Počet článků v db
        /// </summary>
        public static int pocetVDB()
        {
            int pocet = 0;
            using (clankyEntities context = new clankyEntities())
            {
                pocet = context.Clanky1.Count();
            }
            return pocet;
        }
        /// <summary>
        /// Odebere z db clanek s danám id
        /// </summary>
        public static void odeberZDB(int id)
        {

            using (clankyEntities context = new clankyEntities())
            {
                Clanky1 clZdb = new Clanky1();
                clZdb = context.Clanky1.FirstOrDefault(c => c.Id == id);
                context.Clanky1.Remove(clZdb);
                context.SaveChanges();
            }

        }
        /// <summary>
        /// Vratí všechny články z db
        /// </summary>
        public static List<Clanek> VseZDB()
        {
            List<Clanek> database = new List<Clanek>();
            Clanek cl = new Clanek();
            using (clankyEntities context = new clankyEntities())
            {


                int i = 1, pocetnalzeu = 0;
                int pocetDB = context.Clanky1.Count();

                Clanky1 clZdb = new Clanky1();
                while (pocetnalzeu != pocetDB)
                {

                    clZdb = context.Clanky1.FirstOrDefault(c => c.Id == i);
                    if (clZdb != null)
                    {
                        pocetnalzeu++;
                        database.Add(new Clanek
                        {
                            id = clZdb.Id,
                            autor = clZdb.Autor,
                            datumVytvoreni = clZdb.Datum,
                            nazev = clZdb.Nazev,
                            text = clZdb.Text
                        }
                        );
                    }
                    i++;
                }

            }
            return database;
        }

        /// <summary>
        /// úprava hodnot článku 
        /// </summary>
        public static void update(Clanek cl)
        {
            using (clankyEntities context = new clankyEntities())
            {
                Clanky1 clZdb = new Clanky1();
                clZdb = context.Clanky1.FirstOrDefault(c => c.Id == cl.id);
                clZdb.Nazev = cl.nazev;
                clZdb.Text = cl.text;
                context.SaveChanges();
            }

        }
    }




}
