using System;
using System.Collections.Generic;

namespace Bankcard.Models
{
    public partial class CardType
    {
        public CardType()
        {
            Cards = new HashSet<Card>();
        }

        public int CardTypeId { get; set; }
        public string CardTypeName { get; set; }

        public virtual ICollection<Card> Cards { get; set; }
    }
}
