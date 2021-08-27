using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week5.ProvaFinale.Entites
{
    class Impegno
    {
        public string Titolo { get; set; }
        public string Descrizione { get; set; }
        public DateTime Scadenza { get; set; }
        public _Importanza Importanza { get; set; }
        public bool Flag { get; set; }
        public int? Id { get; set; }

        public Impegno()
        {

        }
        public Impegno(string titolo, string descrizione, DateTime scadenza, _Importanza importanza, bool flag, int? id)
        {
            Titolo = titolo;
            Descrizione = descrizione;
            Scadenza = scadenza;
            Importanza = importanza;
            Flag = flag;
            Id = id;
        }

        public void Print()
        {
            var flag = Flag ? "Portato a Termine" : "Non ancora portato a termine";
            Console.WriteLine($"Titlo: {Titolo} Descrizione: {Descrizione} Data di scadenza: {Scadenza} Importanza: {Importanza} Flag: {flag}");
        }

    }

    public enum _Importanza
    {
        Alta = 1,
        Media = 2,
        Bassa = 3,

    }
}
