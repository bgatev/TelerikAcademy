namespace Poker
{
    using System;

    public class Card : ICard
    {
        //private CardFace face;
        //private CardSuit suit;

        public Card(CardFace face, CardSuit suit)
        {
            this.Face = face;
            this.Suit = suit;
        }

        public CardFace Face { get; private set; }

        public CardSuit Suit { get; private set; }
        /*public CardFace Face 
        { 
            get
            {
                return this.face;
            }

            private set
            {
                if (Enum.IsDefined(typeof(CardFace), value))
                {
                    this.face = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Invalid Card Face");
                }
            }
        }

        public CardSuit Suit 
        {
            get
            {
                return this.suit;
            }

            private set
            {
                if (Enum.IsDefined(typeof(CardSuit), value))
                {
                    this.suit = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Invalid Card Suit");
                }
            }
        }*/

        public override string ToString()
        {
            return string.Format("{0} {1}", this.Face, this.Suit);
        }
    }
}
