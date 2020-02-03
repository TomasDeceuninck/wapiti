using System;
using System.Collections.Generic;
using Wapiti.Domain.Infrastructure;

namespace Wapiti.Domain.Entities
{
    public class CollectionCard
    {
        public string CardName { get; set; }
        public Card Card { get; set; }
        public Guid CollectionId { get; set; }
        public Collection Collection { get; set; }
    }
}
