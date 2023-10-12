using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.SecretariaContext
{
    public class BoletimPersistence
    {
        public int BoletimPersistenceId { get; set; }
        public Aluno Aluno { get; set; }
        public int DisciplinaId { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public Decimal Nota { get; set; }
    }
}
