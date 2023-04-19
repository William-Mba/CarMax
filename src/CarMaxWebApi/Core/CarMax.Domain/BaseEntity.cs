using System;

namespace CarMax.Domain
{
    public abstract class BaseEntity
    {
        protected BaseEntity()
        {
            id = Guid.NewGuid().ToString();
        }
        public string id { get; set; }
    }
}
