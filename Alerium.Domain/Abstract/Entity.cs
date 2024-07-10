using System.ComponentModel.DataAnnotations.Schema;

namespace Alerium.Domain.Abstract
{
    [NotMapped]
    public abstract class Entity
    {
        public Guid Id { get; set; }
    }
}
