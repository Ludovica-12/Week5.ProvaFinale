using System;

namespace Week5.ProvaFinale
{
    internal class Menu
    {
        internal static void Start()
        {
            bool continuare = true;

            do
            {
                Console.WriteLine("Premi 1 per visualizzare tutti gli impegni");
                Console.WriteLine("Premi 2 per modificare un impegno");
                Console.WriteLine("Premi 3 per eliminare un impegno");
                Console.WriteLine("Premi 4 per inserire un nuovo impegno");
                Console.WriteLine("Premi 5 per visualizzare gli impegni per data maggiore o uguale alla data inserita");
                Console.WriteLine("Premi 6 per visualizzare gli impegni per il livello di importanza");
                Console.WriteLine("Premi 7 per visualizzare gli impegni portati a termine");
                Console.WriteLine("Premi 0 per uscire");
                Console.WriteLine();
                string scelta = Console.ReadLine();

                switch (scelta)
                {
                    case "1":
                        //Visualizzare impegni
                        CalendarManager.ShowCommitments();
                        break;
                    case "2":
                        //Modifica impegno
                        CalendarManager.UpdateCommitments();
                        break;
                    case "3":
                        //Elimina impegno
                        CalendarManager.DeleteCommitments();
                        break;
                    case "4":
                        //Inserisci nuovo impegno
                        CalendarManager.InsertCommitments();
                        break;
                    case "5":
                        //Impegni per data
                        CalendarManager.ShowDate();
                        break;
                    case "6":
                        //Impegni per importanza
                        CalendarManager.ShowImportant();
                        break;
                    case "7":
                        //Impegni portati a termine
                        CalendarManager.ShowFinish();
                        break;
                    case "0":
                        Console.WriteLine("Ciao alla prossima");
                        continuare = false;
                        break;
                    default:
                        Console.WriteLine("Scelta sbagliata riprova");
                        break;
                }
            } while (continuare);
        }
    }
}