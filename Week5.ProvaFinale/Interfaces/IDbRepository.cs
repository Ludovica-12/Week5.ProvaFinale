using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week5.ProvaFinale.Entites;

namespace Week5.ProvaFinale.Interfaces
{
    interface IDbRepository
    {
        public List<Impegno> Fetch();
        public void Insert(Impegno imp);
        public void Delete(Impegno imp);
        public void Update(Impegno imp);
        public List<Impegno> GetByFinish();
        public List<Impegno> GetByImportanza(_Importanza imp);
        public List<Impegno> GetByScadenza(DateTime dt);
    }
}
