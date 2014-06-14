namespace Poker
{
    using System;
    using System.Collections.Generic;

    public class PokerHandsChecker : IPokerHandsChecker
    {
        public bool IsValidHand(IHand hand)
        {
            List<ICard> sortedCards = (List<ICard>)hand.Cards;

            sortedCards.Sort(
                delegate(ICard p1, ICard p2)
                {
                    return p1.ToString().CompareTo(p2.ToString());
                });

            for (int i = 0; i < hand.Cards.Count - 1; i++)
            {
                if (hand.Cards[i].ToString() == hand.Cards[i + 1].ToString())
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsStraightFlush(IHand hand)
        {
            if (IsStraight(hand) && IsFlush(hand))
            {
                return true;
            }

            return false;
        }

        public bool IsFourOfAKind(IHand hand)
        {
            List<ICard> sortedCards = (List<ICard>)hand.Cards;

            sortedCards.Sort(
                delegate(ICard p1, ICard p2)
                {
                    return p1.Face.CompareTo(p2.Face);
                });

            int counter = 1;
            int maxCounter = 1;

            for (int i = 0; i < hand.Cards.Count - 1; i++)
            {
                if (hand.Cards[i].Face == hand.Cards[i + 1].Face)
                {
                    counter++;
                    if (maxCounter < counter)
                    {
                        maxCounter = counter;
                    }

                    if (counter > 4)
                    {
                        return false;
                    }
                }
                else
                {
                    counter = 1;
                }
            }

            if (maxCounter == 4)
            {
                return true;
            }

            return false;
        }

        public bool IsFullHouse(IHand hand)
        {
            if (IsThreeOfAKind(hand) && IsOnePair(hand))
            {
                return true;
            }

            return false;
        }

        public bool IsFlush(IHand hand)
        {
            int counter = 1;

            for (int i = 0; i < hand.Cards.Count - 1; i++)
            {
                if (hand.Cards[i].Suit == hand.Cards[i + 1].Suit)
                {
                    counter++;
                }
            }

            if (counter == 5)
            {
                return true;
            }

            return false;
        }

        public bool IsStraight(IHand hand)
        {
            List<ICard> sortedCards = (List<ICard>)hand.Cards;

            sortedCards.Sort(
                delegate(ICard p1, ICard p2)
                {
                    return p1.Face.CompareTo(p2.Face);
                });

            int firstValue = (int)hand.Cards[0].Face;
            int counter = 1;

            for (int i = 0; i < hand.Cards.Count - 1; i++)
            {
                if ((int)hand.Cards[i].Face == firstValue++)
                {
                    counter++;
                }
            }

            if (counter == 5)
            {
                return true;
            }

            return false;
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            List<ICard> sortedCards = (List<ICard>)hand.Cards;

            sortedCards.Sort(
                delegate(ICard p1, ICard p2)
                {
                    return p1.Face.CompareTo(p2.Face);
                });

            int counter = 1;
            int maxCounter = 1;

            for (int i = 0; i < hand.Cards.Count - 1; i++)
            {
                if (hand.Cards[i].Face == hand.Cards[i + 1].Face)
                {
                    counter++;
                    if (maxCounter < counter)
                    {
                        maxCounter = counter;
                    }

                    if (counter > 3)
                    {
                        return false;
                    }
                }
                else
                {
                    counter = 1;
                }
            }

            if (maxCounter == 3)
            {
                return true;
            }

            return false;
        }

        public bool IsTwoPair(IHand hand)
        {
            int[] curerntCardFaceCounter = FindCardFaceCounter(hand);
            int counter = 0;

            for (int i = 0; i < hand.Cards.Count; i++)
            {
                if (curerntCardFaceCounter[(int)hand.Cards[i].Face - 2] == 2)
                {
                    counter++;
                }
            }

            if (counter == 4)
            {
                return true;
            }

            return false;
        }

        public bool IsOnePair(IHand hand)
        {
            int[] curerntCardFaceCounter = FindCardFaceCounter(hand);
            int counter = 0;

            for (int i = 0; i < hand.Cards.Count; i++)
            {
                if (curerntCardFaceCounter[(int)hand.Cards[i].Face - 2] == 2)
                {
                    counter++;
                }
            }

            if (counter == 2)
            {
                return true;
            }

            return false;
        }

        public bool IsHighCard(IHand hand)
        {
            if (IsStraightFlush(hand) || IsFourOfAKind(hand) || IsFullHouse(hand) || IsFlush(hand) || IsStraight(hand) || IsThreeOfAKind(hand) || IsTwoPair(hand) || IsOnePair(hand))
            {
                return false;
            }

            return true;
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            int firstHandPower = 0;
            int secondHandPower = 0;

            if (IsStraightFlush(firstHand))
            {
                firstHandPower = 9;
            }
            else if (IsFourOfAKind(firstHand))
            {
                firstHandPower = 8;
            }
            else if (IsFullHouse(firstHand))
            {
                firstHandPower = 7;
            }
            else if (IsFlush(firstHand))
            {
                firstHandPower = 6;
            }
            else if (IsStraight(firstHand))
            {
                firstHandPower = 5;
            }
            else if (IsThreeOfAKind(firstHand))
            {
                firstHandPower = 4;
            }
            else if (IsTwoPair(firstHand))
            {
                firstHandPower = 3;
            }
            else if (IsOnePair(firstHand))
            {
                firstHandPower = 2;
            }

            if (IsStraightFlush(secondHand))
            {
                secondHandPower = 9;
            }
            else if (IsFourOfAKind(secondHand))
            {
                secondHandPower = 8;
            }
            else if (IsFullHouse(secondHand))
            {
                secondHandPower = 7;
            }
            else if (IsFlush(secondHand))
            {
                secondHandPower = 6;
            }
            else if (IsStraight(secondHand))
            {
                secondHandPower = 5;
            }
            else if (IsThreeOfAKind(secondHand))
            {
                secondHandPower = 4;
            }
            else if (IsTwoPair(secondHand))
            {
                secondHandPower = 3;
            }
            else if (IsOnePair(secondHand))
            {
                secondHandPower = 2;
            }

            if (firstHandPower == 0 && secondHandPower == 0)
            {
                List<ICard> sortedFirstHandCards = (List<ICard>)firstHand.Cards;
                List<ICard> sortedSecondHandCards = (List<ICard>)secondHand.Cards;

                sortedFirstHandCards.Sort(
                    delegate(ICard p1, ICard p2)
                    {
                        return p1.Face.CompareTo(p2.Face);
                    });              

                sortedSecondHandCards.Sort(
                    delegate(ICard p1, ICard p2)
                    {
                        return p1.Face.CompareTo(p2.Face);
                    });

                for (int i = firstHand.Cards.Count - 1; i > -1 ; i--)
                {
                    if ((int)firstHand.Cards[i].Face > (int)secondHand.Cards[i].Face)
                    {
                        return 1;
                    }
                    else if ((int)firstHand.Cards[i].Face < (int)secondHand.Cards[i].Face)
                    {
                        return -1;
                    }
                    else
                    {
                        continue;
                    }
                }
            }

            return firstHandPower > secondHandPower ? 1 : firstHandPower < secondHandPower ? -1 : 0;
        }

        private int[] FindCardFaceCounter(IHand hand)
        {
            int[] cardFaceCounter = new int[13];

            for (int count = 0; count < hand.Cards.Count; count++)
            {
                int currentCardFace = (int)hand.Cards[count].Face;
                cardFaceCounter[currentCardFace - 2]++;
            }

            return cardFaceCounter;
        }
    }
}
