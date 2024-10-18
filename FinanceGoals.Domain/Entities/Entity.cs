using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceGoals.Domain.Entities
{
    public class Entity
    {
        public Guid Guid { get; private set; }
        public Entity()
        {
            Guid = Guid.NewGuid();
        }
    }
}
