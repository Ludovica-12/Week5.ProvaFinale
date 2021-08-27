using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week5.ProvaFinale.Entites;
using Week5.ProvaFinale.Interfaces;

namespace Week5.ProvaFinale.ListRepositories
{
    class ImpegnoListRepository : IDbRepository
    {

        public static List<Impegno> calendario = new List<Impegno>
        {
            new Impegno("Riunione1", "Di lavoro", new DateTime(2021, 10, 8), _Importanza.Alta, false, null),
            new Impegno("Riunione2", "Di lavoro", new DateTime(2021, 10, 8), _Importanza.Media, false, null),
            new Impegno("Riunione3", "Di lavoro", new DateTime(2021, 10, 8), _Importanza.Bassa, true, null),
        };

        public void Delete(Impegno imp)
        {
            calendario.Remove(imp);
        }

        public List<Impegno> Fetch()
        {
            return calendario;
        }

        public List<Impegno> GetByFinish()
        {
            return calendario.Where(i => i.Flag == true).ToList();
        }

        public List<Impegno> GetByImportanza(_Importanza imp)
        {
            return calendario.Where(i => i.Importanza == imp).ToList();
        }

        public List<Impegno> GetByScadenza(DateTime dt)
        {
            return calendario.Where(d => d.Scadenza == dt).ToList();
        }

        public void Insert(Impegno imp)
        {
            calendario.Add(imp);
        }

        public void Update(Impegno imp)
        {
            Insert(imp);
        }
    }
}
