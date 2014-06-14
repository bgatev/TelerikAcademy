namespace TestPoker
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Poker;

    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void CanPrintCard()
        {
            ICard card = new Card(CardFace.Ace, CardSuit.Clubs);
            Assert.AreEqual("Ace Clubs", card.ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), "Hand must not be empty")]
        public void CanCreateHand()
        {
            IHand hand = new Hand(null);
        }

        [TestMethod]
        public void CanCreateProperHand()
        {
            ICard card1 = new Card(CardFace.Ace, CardSuit.Clubs);
            ICard card2 = new Card(CardFace.King, CardSuit.Spades);
            ICard card3 = new Card(CardFace.Seven, CardSuit.Diamonds);
            ICard card4 = new Card(CardFace.Ace, CardSuit.Diamonds);
            ICard card5 = new Card(CardFace.Four, CardSuit.Diamonds);

            IHand hand = new Hand(new List<ICard>() 
            { 
                card1, card2, card3, card4, card5
            });

            Assert.AreEqual(5, hand.Cards.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Hand must be 5 Cards")]
        public void CanCreateSmallerHand()
        {
            ICard card1 = new Card(CardFace.Ace, CardSuit.Clubs);
            ICard card2 = new Card(CardFace.King, CardSuit.Spades);
            ICard card3 = new Card(CardFace.Seven, CardSuit.Diamonds);
            ICard card4 = new Card(CardFace.Ace, CardSuit.Diamonds);

            IHand hand = new Hand(new List<ICard>() 
            { 
                card1, card2, card3, card4
            });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Hand must be 5 Cards")]
        public void CanCreateBiggerHand()
        {
            ICard card1 = new Card(CardFace.Ace, CardSuit.Clubs);
            ICard card2 = new Card(CardFace.King, CardSuit.Spades);
            ICard card3 = new Card(CardFace.Seven, CardSuit.Diamonds);
            ICard card4 = new Card(CardFace.Ace, CardSuit.Diamonds);
            ICard card5 = new Card(CardFace.Four, CardSuit.Diamonds);
            ICard card6 = new Card(CardFace.Eight, CardSuit.Diamonds);

            IHand hand = new Hand(new List<ICard>() 
            { 
                card1, card2, card3, card4, card5, card6
            });
        }

        [TestMethod]
        public void CanPrintHand()
        {
            StringBuilder sb = new StringBuilder();

            ICard card1 = new Card(CardFace.Ace, CardSuit.Clubs);
            ICard card2 = new Card(CardFace.King, CardSuit.Spades);
            ICard card3 = new Card(CardFace.Seven, CardSuit.Diamonds);
            ICard card4 = new Card(CardFace.Ace, CardSuit.Diamonds);
            ICard card5 = new Card(CardFace.King, CardSuit.Hearts);

            IHand hand = new Hand(new List<ICard>() 
            { 
                card1, card2, card3, card4, card5
            });

            sb.AppendLine(card1.ToString());
            sb.AppendLine(card2.ToString());
            sb.AppendLine(card3.ToString());
            sb.AppendLine(card4.ToString());
            sb.AppendLine(card5.ToString());

            Assert.AreEqual(sb.ToString(), hand.ToString());
        }

        [TestMethod]
        public void CheckForValidHand()
        {
            ICard card1 = new Card(CardFace.Ace, CardSuit.Clubs);
            ICard card2 = new Card(CardFace.King, CardSuit.Spades);
            ICard card3 = new Card(CardFace.Seven, CardSuit.Diamonds);
            ICard card4 = new Card(CardFace.Ace, CardSuit.Diamonds);
            ICard card5 = new Card(CardFace.King, CardSuit.Hearts);

            IHand hand = new Hand(new List<ICard>() 
            { 
                card1, card2, card3, card4, card5
            });

            IPokerHandsChecker checker = new PokerHandsChecker();

            Assert.AreEqual(true, checker.IsValidHand(hand));
        }

        [TestMethod]
        public void CheckForInValidHand()
        {
            ICard card1 = new Card(CardFace.Ace, CardSuit.Clubs);
            ICard card2 = new Card(CardFace.King, CardSuit.Spades);
            ICard card3 = new Card(CardFace.Seven, CardSuit.Diamonds);
            ICard card4 = new Card(CardFace.Ace, CardSuit.Diamonds);
            ICard card5 = new Card(CardFace.Ace, CardSuit.Clubs);

            IHand hand = new Hand(new List<ICard>() 
            { 
                card1, card2, card3, card4, card5
            });

            IPokerHandsChecker checker = new PokerHandsChecker();

            Assert.AreEqual(false, checker.IsValidHand(hand));
        }

        [TestMethod]
        public void StraightFlushHand()
        {
            ICard card1 = new Card(CardFace.Nine, CardSuit.Clubs);
            ICard card2 = new Card(CardFace.King, CardSuit.Clubs);
            ICard card3 = new Card(CardFace.Queen, CardSuit.Clubs);
            ICard card4 = new Card(CardFace.Jack, CardSuit.Clubs);
            ICard card5 = new Card(CardFace.Ten, CardSuit.Clubs);

            IHand hand = new Hand(new List<ICard>() 
            { 
                card1, card2, card3, card4, card5
            });

            IPokerHandsChecker checker = new PokerHandsChecker();

            Assert.AreEqual(true, checker.IsStraightFlush(hand));
        }

        [TestMethod]
        public void StraightFlushHand2()
        {
            ICard card1 = new Card(CardFace.Nine, CardSuit.Clubs);
            ICard card2 = new Card(CardFace.King, CardSuit.Hearts);
            ICard card3 = new Card(CardFace.Queen, CardSuit.Diamonds);
            ICard card4 = new Card(CardFace.Jack, CardSuit.Clubs);
            ICard card5 = new Card(CardFace.Ten, CardSuit.Spades);

            IHand hand = new Hand(new List<ICard>() 
            { 
                card1, card2, card3, card4, card5
            });

            IPokerHandsChecker checker = new PokerHandsChecker();

            Assert.AreEqual(false, checker.IsStraightFlush(hand));
        }

        [TestMethod]
        public void StraightFlushHand3()
        {
            ICard card1 = new Card(CardFace.Nine, CardSuit.Hearts);
            ICard card2 = new Card(CardFace.King, CardSuit.Hearts);
            ICard card3 = new Card(CardFace.Queen, CardSuit.Hearts);
            ICard card4 = new Card(CardFace.Jack, CardSuit.Hearts);
            ICard card5 = new Card(CardFace.Five, CardSuit.Hearts);

            IHand hand = new Hand(new List<ICard>() 
            { 
                card1, card2, card3, card4, card5
            });

            IPokerHandsChecker checker = new PokerHandsChecker();

            Assert.AreEqual(false, checker.IsStraightFlush(hand));
        }

        [TestMethod]
        public void FourOfAKindHand()
        {
            ICard card1 = new Card(CardFace.Ace, CardSuit.Clubs);
            ICard card2 = new Card(CardFace.King, CardSuit.Spades);
            ICard card3 = new Card(CardFace.Ace, CardSuit.Spades);
            ICard card4 = new Card(CardFace.Ace, CardSuit.Diamonds);
            ICard card5 = new Card(CardFace.Ace, CardSuit.Hearts);

            IHand hand = new Hand(new List<ICard>() 
            { 
                card1, card2, card3, card4, card5
            });

            IPokerHandsChecker checker = new PokerHandsChecker();

            Assert.AreEqual(true, checker.IsFourOfAKind(hand));
        }

        [TestMethod]
        public void FourOfAKindHand2()
        {
            ICard card1 = new Card(CardFace.Ace, CardSuit.Clubs);
            ICard card2 = new Card(CardFace.Ace, CardSuit.Spades);
            ICard card3 = new Card(CardFace.Ace, CardSuit.Spades);
            ICard card4 = new Card(CardFace.Ace, CardSuit.Diamonds);
            ICard card5 = new Card(CardFace.Ace, CardSuit.Hearts);

            IHand hand = new Hand(new List<ICard>() 
            { 
                card1, card2, card3, card4, card5
            });

            IPokerHandsChecker checker = new PokerHandsChecker();

            Assert.AreEqual(false, checker.IsFourOfAKind(hand));
        }

        [TestMethod]
        public void FourOfAKindHand3()
        {
            ICard card1 = new Card(CardFace.Ace, CardSuit.Clubs);
            ICard card2 = new Card(CardFace.King, CardSuit.Spades);
            ICard card3 = new Card(CardFace.Ace, CardSuit.Spades);
            ICard card4 = new Card(CardFace.Ace, CardSuit.Diamonds);
            ICard card5 = new Card(CardFace.King, CardSuit.Hearts);

            IHand hand = new Hand(new List<ICard>() 
            { 
                card1, card2, card3, card4, card5
            });

            IPokerHandsChecker checker = new PokerHandsChecker();

            Assert.AreEqual(false, checker.IsFourOfAKind(hand));
        }

        [TestMethod]
        public void FullHouseHand()
        {
            ICard card1 = new Card(CardFace.Ace, CardSuit.Clubs);
            ICard card2 = new Card(CardFace.King, CardSuit.Spades);
            ICard card3 = new Card(CardFace.Ace, CardSuit.Spades);
            ICard card4 = new Card(CardFace.Ace, CardSuit.Diamonds);
            ICard card5 = new Card(CardFace.King, CardSuit.Hearts);

            IHand hand = new Hand(new List<ICard>() 
            { 
                card1, card2, card3, card4, card5
            });

            IPokerHandsChecker checker = new PokerHandsChecker();

            Assert.AreEqual(true, checker.IsFullHouse(hand));
        }

        [TestMethod]
        public void FullHouseHand2()
        {
            ICard card1 = new Card(CardFace.Ace, CardSuit.Clubs);
            ICard card2 = new Card(CardFace.Ten, CardSuit.Spades);
            ICard card3 = new Card(CardFace.Ace, CardSuit.Spades);
            ICard card4 = new Card(CardFace.Ace, CardSuit.Diamonds);
            ICard card5 = new Card(CardFace.King, CardSuit.Hearts);

            IHand hand = new Hand(new List<ICard>() 
            { 
                card1, card2, card3, card4, card5
            });

            IPokerHandsChecker checker = new PokerHandsChecker();

            Assert.AreEqual(false, checker.IsFullHouse(hand));
        }

        [TestMethod]
        public void FullHouseHand3()
        {
            ICard card1 = new Card(CardFace.Ace, CardSuit.Clubs);
            ICard card2 = new Card(CardFace.Ten, CardSuit.Spades);
            ICard card3 = new Card(CardFace.Ace, CardSuit.Spades);
            ICard card4 = new Card(CardFace.King, CardSuit.Diamonds);
            ICard card5 = new Card(CardFace.King, CardSuit.Hearts);

            IHand hand = new Hand(new List<ICard>() 
            { 
                card1, card2, card3, card4, card5
            });

            IPokerHandsChecker checker = new PokerHandsChecker();

            Assert.AreEqual(false, checker.IsFullHouse(hand));
        }

        [TestMethod]
        public void FlushHand()
        {
            ICard card1 = new Card(CardFace.Ace, CardSuit.Clubs);
            ICard card2 = new Card(CardFace.King, CardSuit.Clubs);
            ICard card3 = new Card(CardFace.Five, CardSuit.Clubs);
            ICard card4 = new Card(CardFace.Jack, CardSuit.Clubs);
            ICard card5 = new Card(CardFace.Four, CardSuit.Clubs);

            IHand hand = new Hand(new List<ICard>()
            { 
                card1, card2, card3, card4, card5
            });

            IPokerHandsChecker checker = new PokerHandsChecker();

            Assert.AreEqual(true, checker.IsFlush(hand));
        }

        [TestMethod]
        public void FlushHand2()
        {
            ICard card1 = new Card(CardFace.Ace, CardSuit.Clubs);
            ICard card2 = new Card(CardFace.King, CardSuit.Hearts);
            ICard card3 = new Card(CardFace.Five, CardSuit.Clubs);
            ICard card4 = new Card(CardFace.Jack, CardSuit.Clubs);
            ICard card5 = new Card(CardFace.Four, CardSuit.Clubs);

            IHand hand = new Hand(new List<ICard>() 
            { 
                card1, card2, card3, card4, card5
            });

            IPokerHandsChecker checker = new PokerHandsChecker();

            Assert.AreEqual(false, checker.IsFlush(hand));
        }

        [TestMethod]
        public void StraightHand()
        {
            ICard card1 = new Card(CardFace.Nine, CardSuit.Clubs);
            ICard card2 = new Card(CardFace.King, CardSuit.Hearts);
            ICard card3 = new Card(CardFace.Queen, CardSuit.Diamonds);
            ICard card4 = new Card(CardFace.Jack, CardSuit.Clubs);
            ICard card5 = new Card(CardFace.Ten, CardSuit.Spades);

            IHand hand = new Hand(new List<ICard>() 
            { 
                card1, card2, card3, card4, card5
            });

            IPokerHandsChecker checker = new PokerHandsChecker();

            Assert.AreEqual(true, checker.IsStraight(hand));
        }

        [TestMethod]
        public void StraightHand2()
        {
            ICard card1 = new Card(CardFace.Five, CardSuit.Clubs);
            ICard card2 = new Card(CardFace.King, CardSuit.Hearts);
            ICard card3 = new Card(CardFace.Queen, CardSuit.Diamonds);
            ICard card4 = new Card(CardFace.Jack, CardSuit.Clubs);
            ICard card5 = new Card(CardFace.Ten, CardSuit.Spades);

            IHand hand = new Hand(new List<ICard>()
            { 
                card1, card2, card3, card4, card5
            });

            IPokerHandsChecker checker = new PokerHandsChecker();

            Assert.AreEqual(false, checker.IsStraight(hand));
        }

        [TestMethod]
        public void ThreeOfAKindHand()
        {
            ICard card1 = new Card(CardFace.Ace, CardSuit.Clubs);
            ICard card2 = new Card(CardFace.King, CardSuit.Spades);
            ICard card3 = new Card(CardFace.Four, CardSuit.Spades);
            ICard card4 = new Card(CardFace.Ace, CardSuit.Diamonds);
            ICard card5 = new Card(CardFace.Ace, CardSuit.Hearts);

            IHand hand = new Hand(new List<ICard>()
            { 
                card1, card2, card3, card4, card5
            });

            IPokerHandsChecker checker = new PokerHandsChecker();

            Assert.AreEqual(true, checker.IsThreeOfAKind(hand));
        }

        [TestMethod]
        public void ThreeOfAKindHand2()
        {
            ICard card1 = new Card(CardFace.Ace, CardSuit.Clubs);
            ICard card2 = new Card(CardFace.Ace, CardSuit.Spades);
            ICard card3 = new Card(CardFace.Ace, CardSuit.Spades);
            ICard card4 = new Card(CardFace.Ace, CardSuit.Diamonds);
            ICard card5 = new Card(CardFace.Ace, CardSuit.Hearts);

            IHand hand = new Hand(new List<ICard>()
            { 
                card1, card2, card3, card4, card5
            });

            IPokerHandsChecker checker = new PokerHandsChecker();

            Assert.AreEqual(false, checker.IsThreeOfAKind(hand));
        }

        [TestMethod]
        public void ThreeOfAKindHand3()
        {
            ICard card1 = new Card(CardFace.Ace, CardSuit.Clubs);
            ICard card2 = new Card(CardFace.King, CardSuit.Spades);
            ICard card3 = new Card(CardFace.Ace, CardSuit.Spades);
            ICard card4 = new Card(CardFace.Jack, CardSuit.Diamonds);
            ICard card5 = new Card(CardFace.Four, CardSuit.Hearts);

            IHand hand = new Hand(new List<ICard>() 
            { 
                card1, card2, card3, card4, card5
            });

            IPokerHandsChecker checker = new PokerHandsChecker();

            Assert.AreEqual(false, checker.IsThreeOfAKind(hand));
        }

        [TestMethod]
        public void TwoPairsHand()
        {
            ICard card1 = new Card(CardFace.Five, CardSuit.Clubs);
            ICard card2 = new Card(CardFace.King, CardSuit.Hearts);
            ICard card3 = new Card(CardFace.Five, CardSuit.Diamonds);
            ICard card4 = new Card(CardFace.Jack, CardSuit.Clubs);
            ICard card5 = new Card(CardFace.King, CardSuit.Spades);

            IHand hand = new Hand(new List<ICard>() 
            { 
                card1, card2, card3, card4, card5
            });

            IPokerHandsChecker checker = new PokerHandsChecker();

            Assert.AreEqual(true, checker.IsTwoPair(hand));
        }

        [TestMethod]
        public void TwoPairsHand2()
        {
            ICard card1 = new Card(CardFace.Five, CardSuit.Clubs);
            ICard card2 = new Card(CardFace.King, CardSuit.Hearts);
            ICard card3 = new Card(CardFace.Five, CardSuit.Diamonds);
            ICard card4 = new Card(CardFace.Five, CardSuit.Spades);
            ICard card5 = new Card(CardFace.King, CardSuit.Spades);

            IHand hand = new Hand(new List<ICard>() 
            { 
                card1, card2, card3, card4, card5
            });

            IPokerHandsChecker checker = new PokerHandsChecker();

            Assert.AreEqual(false, checker.IsTwoPair(hand));
        }

        [TestMethod]
        public void TwoPairsHand3()
        {
            ICard card1 = new Card(CardFace.Five, CardSuit.Clubs);
            ICard card2 = new Card(CardFace.King, CardSuit.Hearts);
            ICard card3 = new Card(CardFace.Five, CardSuit.Diamonds);
            ICard card4 = new Card(CardFace.Seven, CardSuit.Spades);
            ICard card5 = new Card(CardFace.Ten, CardSuit.Spades);

            IHand hand = new Hand(new List<ICard>() 
            { 
                card1, card2, card3, card4, card5
            });

            IPokerHandsChecker checker = new PokerHandsChecker();

            Assert.AreEqual(false, checker.IsTwoPair(hand));
        }

        [TestMethod]
        public void OnePairHand()
        {
            ICard card1 = new Card(CardFace.Five, CardSuit.Clubs);
            ICard card2 = new Card(CardFace.King, CardSuit.Hearts);
            ICard card3 = new Card(CardFace.Five, CardSuit.Diamonds);
            ICard card4 = new Card(CardFace.Seven, CardSuit.Spades);
            ICard card5 = new Card(CardFace.Ten, CardSuit.Spades);

            IHand hand = new Hand(new List<ICard>()
            { 
                card1, card2, card3, card4, card5
            });

            IPokerHandsChecker checker = new PokerHandsChecker();

            Assert.AreEqual(true, checker.IsOnePair(hand));
        }

        [TestMethod]
        public void HighCard()
        {
            ICard card1 = new Card(CardFace.Five, CardSuit.Clubs);
            ICard card2 = new Card(CardFace.King, CardSuit.Hearts);
            ICard card3 = new Card(CardFace.Seven, CardSuit.Diamonds);
            ICard card4 = new Card(CardFace.Ace, CardSuit.Spades);
            ICard card5 = new Card(CardFace.Ten, CardSuit.Spades);

            IHand hand = new Hand(new List<ICard>()
            { 
                card1, card2, card3, card4, card5
            });

            IPokerHandsChecker checker = new PokerHandsChecker();

            Assert.AreEqual(true, checker.IsHighCard(hand));
        }

        [TestMethod]
        public void HighCard2()
        {
            ICard card1 = new Card(CardFace.Five, CardSuit.Clubs);
            ICard card2 = new Card(CardFace.Five, CardSuit.Hearts);
            ICard card3 = new Card(CardFace.Seven, CardSuit.Diamonds);
            ICard card4 = new Card(CardFace.Ace, CardSuit.Spades);
            ICard card5 = new Card(CardFace.Ten, CardSuit.Spades);

            IHand hand = new Hand(new List<ICard>()
            { 
                card1, card2, card3, card4, card5
            });

            IPokerHandsChecker checker = new PokerHandsChecker();

            Assert.AreEqual(false, checker.IsHighCard(hand));
        }

        [TestMethod]
        public void OnePairHand2()
        {
            ICard card1 = new Card(CardFace.Five, CardSuit.Clubs);
            ICard card2 = new Card(CardFace.King, CardSuit.Hearts);
            ICard card3 = new Card(CardFace.Five, CardSuit.Diamonds);
            ICard card4 = new Card(CardFace.King, CardSuit.Spades);
            ICard card5 = new Card(CardFace.Ten, CardSuit.Spades);

            IHand hand = new Hand(new List<ICard>() 
            { 
                card1, card2, card3, card4, card5
            });

            IPokerHandsChecker checker = new PokerHandsChecker();

            Assert.AreEqual(false, checker.IsOnePair(hand));
        }

        [TestMethod]
        public void CompareHand0()
        {
            ICard card1 = new Card(CardFace.Five, CardSuit.Clubs);
            ICard card2 = new Card(CardFace.King, CardSuit.Hearts);
            ICard card3 = new Card(CardFace.Five, CardSuit.Diamonds);
            ICard card4 = new Card(CardFace.King, CardSuit.Spades);
            ICard card5 = new Card(CardFace.King, CardSuit.Diamonds);

            IHand hand1 = new Hand(new List<ICard>()
            { 
                card1, card2, card3, card4, card5
            });

            IHand hand2 = new Hand(new List<ICard>() 
            { 
                card1, card2, card3, card4, card5
            });

            IPokerHandsChecker checker = new PokerHandsChecker();

            Assert.AreEqual(0, checker.CompareHands(hand1, hand2));
        }

        [TestMethod]
        public void CompareHand1()
        {
            ICard card1 = new Card(CardFace.Five, CardSuit.Clubs);
            ICard card2 = new Card(CardFace.King, CardSuit.Hearts);
            ICard card3 = new Card(CardFace.Five, CardSuit.Diamonds);
            ICard card4 = new Card(CardFace.King, CardSuit.Spades);
            ICard card5 = new Card(CardFace.King, CardSuit.Diamonds);
            ICard card6 = new Card(CardFace.Ten, CardSuit.Spades);

            IHand hand1 = new Hand(new List<ICard>() 
            { 
                card1, card2, card3, card4, card5
            });

            IHand hand2 = new Hand(new List<ICard>()
            { 
                card1, card2, card3, card4, card6
            });

            IPokerHandsChecker checker = new PokerHandsChecker();

            Assert.AreEqual(1, checker.CompareHands(hand1, hand2));
        }

        [TestMethod]
        public void CompareHand2()
        {
            ICard card1 = new Card(CardFace.Five, CardSuit.Clubs);
            ICard card2 = new Card(CardFace.King, CardSuit.Hearts);
            ICard card3 = new Card(CardFace.Five, CardSuit.Diamonds);
            ICard card4 = new Card(CardFace.King, CardSuit.Spades);
            ICard card5 = new Card(CardFace.King, CardSuit.Diamonds);
            ICard card6 = new Card(CardFace.Ten, CardSuit.Spades);

            IHand hand1 = new Hand(new List<ICard>()
            { 
                card1, card2, card3, card4, card6
            });

            IHand hand2 = new Hand(new List<ICard>()
            { 
                card1, card2, card3, card4, card5
            });

            IPokerHandsChecker checker = new PokerHandsChecker();

            Assert.AreEqual(-1, checker.CompareHands(hand1, hand2));
        }

        [TestMethod]
        public void CompareHand3()
        {
            ICard card1 = new Card(CardFace.Five, CardSuit.Clubs);
            ICard card2 = new Card(CardFace.King, CardSuit.Hearts);
            ICard card3 = new Card(CardFace.Six, CardSuit.Diamonds);
            ICard card4 = new Card(CardFace.Ace, CardSuit.Spades);
            ICard card5 = new Card(CardFace.Queen, CardSuit.Diamonds);
            ICard card6 = new Card(CardFace.Ten, CardSuit.Spades);

            IHand hand1 = new Hand(new List<ICard>()
            { 
                card1, card2, card3, card4, card5
            });

            IHand hand2 = new Hand(new List<ICard>()
            { 
                card1, card2, card3, card4, card6
            });

            IPokerHandsChecker checker = new PokerHandsChecker();

            Assert.AreEqual(1, checker.CompareHands(hand1, hand2));
        }

        [TestMethod]
        public void CompareHand4()
        {
            ICard card1 = new Card(CardFace.Five, CardSuit.Clubs);
            ICard card2 = new Card(CardFace.King, CardSuit.Hearts);
            ICard card3 = new Card(CardFace.Six, CardSuit.Diamonds);
            ICard card4 = new Card(CardFace.Ace, CardSuit.Spades);
            ICard card5 = new Card(CardFace.Two, CardSuit.Diamonds);
            ICard card6 = new Card(CardFace.Ten, CardSuit.Spades);

            IHand hand1 = new Hand(new List<ICard>()
            { 
                card1, card2, card3, card4, card5
            });

            IHand hand2 = new Hand(new List<ICard>()
            { 
                card1, card2, card3, card4, card6
            });

            IPokerHandsChecker checker = new PokerHandsChecker();

            Assert.AreEqual(-1, checker.CompareHands(hand1, hand2));
        }

        [TestMethod]
        public void CompareHand5()
        {
            ICard card1 = new Card(CardFace.Five, CardSuit.Clubs);
            ICard card2 = new Card(CardFace.King, CardSuit.Hearts);
            ICard card3 = new Card(CardFace.Six, CardSuit.Diamonds);
            ICard card4 = new Card(CardFace.Ace, CardSuit.Spades);
            ICard card5 = new Card(CardFace.Two, CardSuit.Diamonds);
            ICard card6 = new Card(CardFace.Two, CardSuit.Spades);

            IHand hand1 = new Hand(new List<ICard>()
            { 
                card1, card2, card3, card4, card5
            });

            IHand hand2 = new Hand(new List<ICard>()
            { 
                card1, card2, card3, card4, card6
            });

            IPokerHandsChecker checker = new PokerHandsChecker();

            Assert.AreEqual(0, checker.CompareHands(hand1, hand2));
        }
    }
}
