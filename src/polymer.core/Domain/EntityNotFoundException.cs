using System;

namespace polymer.core.Domain
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(string id) : base(string.Format("an entity with the id {0} could not be found", id))
        {
            
        }
    }
}