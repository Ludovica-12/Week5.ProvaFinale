using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week5.ProvaFinale.Entites;
using Week5.ProvaFinale.LisAdoRepositories;
using Week5.ProvaFinale.ListRepositories;

namespace Week5.ProvaFinale
{
    class CalendarManager
    {
        public static ImpegnoListRepository impegnoRepository = new ImpegnoListRepository();
        //public static ImpegnoAdoRepository impegnoRepository = new ImpegnoAdoRepository();

        internal static void ShowCommitments()
        {
            List<Impegno> impegni = impegnoRepository.Fetch();
            foreach (var imp in impegni)
            {
                imp.Print();
            }
        }

        internal static void UpdateCommitments()
        {
            List<Impegno> impegni = impegnoRepository.Fetch();
            int i = 1;
            foreach (var u in impegni)
            {
                Console.WriteLine($"Premi {i} per modificare l'impegno");
                u.Print();
                i++;
            }
            bool isInt;
            int impegnoScelto;
            do
            {
                Console.WriteLine("Quale impegno?");

                isInt = int.TryParse(Console.ReadLine(), out impegnoScelto);

            } while (!isInt || impegnoScelto <= 0 || impegnoScelto > impegni.Count);

            Console.WriteLine("Hai scelto di modificare");
            Impegno imp = impegni.ElementAt(impegnoScelto - 1);
            if (imp.Id == null)
            {
                impegnoRepository.Delete(imp);
            }

            bool continuare = true;
            string risposta;
            do
            {
                Console.WriteLine("Vuoi modificare il titolo?");
                risposta = Console.ReadLine();
                if (risposta == "si" || risposta == "no")
                    continuare = false;
            } while (continuare);
            if (risposta == "si")
            {
                imp.Titolo = InsertTitolo();
            }

            do
            {
                Console.WriteLine("Vuoi modificare la descrizione?");
                risposta = Console.ReadLine();
                if (risposta == "si" || risposta == "no")
                    continuare = false;
            } while (continuare);
            if (risposta == "si")
            {
                imp.Descrizione = InsertDescrizione();
            }

            //do
            //{
            //    Console.WriteLine("Vuoi modificare la data di scadenza?");
            //    risposta = Console.ReadLine();
            //    if (risposta == "si" || risposta == "no")
            //        continuare = false;
            //} while (continuare);
            //if (risposta == "si")
            //{
            //    imp.Scadenza = InsertScadenza();
            //}

            do
            {
                Console.WriteLine("Vuoi modificare l'importanza?");
                risposta = Console.ReadLine();
                if (risposta == "si" || risposta == "no")
                    continuare = false;
            } while (continuare);
            if (risposta == "si")
            {
                imp.Importanza = InsertImportanza();
            }

            do
            {
                Console.WriteLine("Vuoi modificare se è o no stato portato a termine?");
                risposta = Console.ReadLine();
                if (risposta == "si" || risposta == "no")
                    continuare = false;
            } while (continuare);
            if (risposta == "si")
            {
                imp.Flag = InsertFlag();
            }

            impegnoRepository.Update(imp);
        }

        internal static void ShowDate()
        {
            DateTime dt = InsertScadenza();
            List<Impegno> scad = impegnoRepository.GetByScadenza(dt);
            foreach (var s in scad)
                s.Print();
        }

        internal static void ShowFinish()
        {
            List<Impegno> impegni = impegnoRepository.GetByFinish();
            foreach (var imp in impegni)
                imp.Print();
        }

        internal static void ShowImportant()
        {
            _Importanza imp = InsertImportanza();
            List<Impegno> important = impegnoRepository.GetByImportanza(imp);
            foreach (var i in important)
                i.Print();
        }

        internal static void DeleteCommitments()
        {
            Console.WriteLine("Scegli quale impegno vuoi eliminare");
            Impegno impegno = ScegliImpegno();
            impegnoRepository.Delete(impegno);
        }

        private static Impegno ScegliImpegno()
        {
            List<Impegno> impegni = impegnoRepository.Fetch();
            Impegno impegno1 = new Impegno();

            int i = 1;
            foreach (var imp in impegni)
            {
                Console.WriteLine($"\nPremi {i} per selezionare il seguente impegno: ");
                imp.Print();

                i++;
            }

            int scelta;
            do
            {
                Console.WriteLine("\nQuale impegno vuoi scegliere?");

            } while (!int.TryParse(Console.ReadLine(), out scelta) || scelta < 0 || scelta > impegni.Count);
            
            return impegni.ElementAt(scelta - 1);
        }

        internal static void InsertCommitments()
        {
            Impegno imp = new Impegno();

            imp.Titolo = InsertTitolo();
            imp.Descrizione = InsertDescrizione();
            imp.Scadenza = InsertScadenza();
            imp.Importanza = InsertImportanza();
            imp.Flag = InsertFlag();

            impegnoRepository.Insert(imp);
        }

        private static bool InsertFlag()
        {
            bool continuare = true;
            string IsFlag;
            do
            {
                Console.WriteLine("L'impegno è stato portato a termine? Scrivi si o no");
                IsFlag = Console.ReadLine();
                if (IsFlag == "si" || IsFlag == "no")
                    continuare = false;
            } while (continuare);

            return IsFlag == "si" ? true : false;
        }

        private static _Importanza InsertImportanza()
        {
            bool isInt;
            int choose;
            do
            {
                Console.WriteLine($"Premi {(int)_Importanza.Alta} per scegliere il livello di importanza Alto");
                Console.WriteLine($"Premi {(int)_Importanza.Media} per scegliere il livello di importanza Medio");
                Console.WriteLine($"Premi {(int)_Importanza.Bassa} per scegliere il livello di importanza Basso");

                isInt = int.TryParse(Console.ReadLine(), out choose);
            } while (!isInt || choose < 0 || choose > 3);

            return (_Importanza)choose;
        }

        private static DateTime InsertScadenza()
        {
            Console.WriteLine("Inserisci una data di scadenza futura (mm - gg - yyyy)");
            DateTime date;
            while(!DateTime.TryParse(Console.ReadLine(), out date) || date < DateTime.Today)
            {
                Console.WriteLine("Riprova! Data non valida");
            }
            return date;
        }

        private static string InsertDescrizione()
        {
            string desc = String.Empty;
            do
            {
                Console.WriteLine("Inserisci Descrizione");
                desc = Console.ReadLine();

            } while (String.IsNullOrEmpty(desc));
            return desc;
        }

        private static string InsertTitolo()
        {
            string titolo = String.Empty;
            do
            {
                Console.WriteLine("Inserisci il Titolo");
                titolo = Console.ReadLine();

            } while (String.IsNullOrEmpty(titolo));
            return titolo;
        }
    }
}
