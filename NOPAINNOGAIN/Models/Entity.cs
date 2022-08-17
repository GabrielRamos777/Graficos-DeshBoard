using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NOPAINNOGAIN.Models
{
    public abstract class Entity
    {
        protected Entity()
        {
            ID = Guid.NewGuid();
        }
        public Guid ID { get; set; }
    }
}
