using System;

namespace EfCore.Backend.Persistence.Model
{
    public class EntityBase
    {
        public EntityBase()
        {
            Enabled = true;
            Modified = DateTime.UtcNow;
        }

        public bool Enabled { get; set; }
        public DateTime? Modified { get; set; }
    }
}