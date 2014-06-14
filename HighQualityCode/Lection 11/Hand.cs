namespace Poker
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Hand : IHand
    {
        private IList<ICard> cards;
        
        public Hand(IList<ICard> cards)
        {
            this.Cards = cards;
        }

        public IList<ICard> Cards
        {
            get
            {
                return this.cards;
            }

            private set
            {
                if (value.Count == 5)
                {
                    this.cards = value;
                }
                else if (value == null)
                {
                    throw new NullReferenceException("Hand must not be empty");
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Hand must be 5 Cards");
                }
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var card in Cards)
            {
                sb.AppendLine(card.ToString());   
            }

            return sb.ToString();
        }
    }
}
