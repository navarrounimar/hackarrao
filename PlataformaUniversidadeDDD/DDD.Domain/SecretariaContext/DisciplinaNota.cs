using System.ComponentModel.DataAnnotations.Schema;

namespace DDD.Domain.SecretariaContext
{
    public class DisciplinaNota
    {
        public int IdDisciplina { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public Decimal Nota { get; set; }
    }
}
