using System;
using System.Collections.Generic;

namespace Bankcard.Models
{
    public partial class Card
    {
        public int CardId { get; set; }
        public string CardImage { get; set; }
        public string CardBussinessCategory { get; set; }
        public string CardNumber { get; set; }
        public string CardType { get; set; }
        public string CardExpirationDate { get; set; }
        public int? CardTypeId { get; set; }

        public virtual CardType CardTypeNavigation { get; set; }
    }
}
