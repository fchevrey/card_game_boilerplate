using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class T_Deck
    {
        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void ATestStaticList()
        {
            List<eCardId> std52 = Deck.GetDeckList(eDeckType.std52Card);
            List<eCardId> std54 = Deck.GetDeckList(eDeckType.std54Card);
            List<eCardId> std32 = Deck.GetDeckList(eDeckType.std32Card);
            Assert.That(std52.Count, Is.EqualTo(52));
            Assert.That(std54.Count, Is.EqualTo(54));
            Assert.That(std32.Count, Is.EqualTo(32));
            Assert.That(std32.FindAll(x => x == eCardId.joker).Count, Is.EqualTo(0), "there is some jokers in 32card");
            Assert.That(std32.FindAll(x => Card.GetValueOf(x) > eCardValue.six).Count, Is.EqualTo(32), "Some crad are inferior to seven");
            Assert.That(std52.FindAll(x => x == eCardId.joker).Count, Is.EqualTo(0), "there is some jokers in 52card");
            Assert.That(std54.FindAll(x => x == eCardId.joker).Count, Is.EqualTo(2), "there are less than two jokers in 54card");
        }
        [Test]
        public void TestCreateDeck52()
        {
            List<eCardId> allIds = new List<eCardId>((eCardId[])System.Enum.GetValues(typeof(eCardId)));
            allIds.Remove(eCardId.joker);
            allIds.Remove(eCardId.none);
            /*Create a copy a allIds list*/
            List<eCardId> tmpId = new List<eCardId>(allIds);
            Assert.That(allIds.Count, Is.EqualTo(52), "wrong size of Enum List");
            Deck deck = new Deck(eDeckType.std52Card);
            Assert.That(deck.cardsRemains, Is.EqualTo(allIds.Count), "cards remain in deck don't match");
            for (int i = allIds.Count -1 ; i >= 0; --i)
            {
                Card card = deck.Draw();
                Assert.That(deck.cardsRemains, Is.EqualTo(i));
            }
        }
        [Test]
        public void TestCreateDeck54()
        {
            List<eCardId> allIds = new List<eCardId>((eCardId[])System.Enum.GetValues(typeof(eCardId)));
            allIds.Add(eCardId.joker);
            allIds.Remove(eCardId.none);
            Debug.Log("allid = " + allIds.Count);
            Assert.That(allIds.Count, Is.EqualTo(54), "wrong size of Enum List");
            Deck deck = new Deck(eDeckType.std54Card);
            Assert.That(deck.cardsRemains, Is.EqualTo(allIds.Count), "cards remain in deck don't match");
            for (int i = allIds.Count-1; i >= 0; --i)
            {
                Card card = deck.Draw();
                Assert.That(deck.cardsRemains, Is.EqualTo(i));
            }
        }
        [Test]
        public void TestCreateDeck32()
        {
            Deck deck = new Deck(eDeckType.std32Card);
            Assert.That(deck.cardsRemains, Is.EqualTo(32), "cards remain in deck don't match");
            for (int i = 31; i >= 0; --i)
            {
                Card card = deck.Draw();
                Assert.That(deck.cardsRemains, Is.EqualTo(i));
            }
        }
        [Test]
        public void TestDrawAll52()
        {
            List<eCardId> allIds = new List<eCardId>((eCardId[])System.Enum.GetValues(typeof(eCardId)));
            allIds.Remove(eCardId.joker);
            allIds.Remove(eCardId.none);
            Assert.That(allIds.Count, Is.EqualTo(52), "wrong size of Enum List");
            Deck deck = new Deck(eDeckType.std52Card);
            DrawAll(allIds, deck);
        }
        [Test]
        public void TestDrawAll54()
        {
            List<eCardId> allIds = new List<eCardId>((eCardId[])System.Enum.GetValues(typeof(eCardId)));
            allIds.Add(eCardId.joker);
            allIds.Remove(eCardId.none);
            Assert.That(allIds.Count, Is.EqualTo(54), "wrong size of Enum List");
            Deck deck = new Deck(eDeckType.std54Card);
            DrawAll(allIds, deck);
        }
        [Test]
        public void TestDrawAll32()
        {
            List<eCardId> allIds = Deck.GetDeckList(eDeckType.std32Card);
            Assert.That(allIds.Count, Is.EqualTo(32), "wrong size of Enum List");
            Deck deck = new Deck(eDeckType.std32Card);
            DrawAll(allIds, deck);
        }
        private void DrawAll(List<eCardId> allIds, Deck deck)
        {
            /*Create a copy a allIds list*/
            List<eCardId> tmpId = new List<eCardId>(allIds);
            Debug.Log("Draw All - allid = " + allIds.Count);
            Assert.That(deck.cardsRemains, Is.EqualTo(allIds.Count), "cards remain in deck don't match");
            /*  Draw all card and check that there is no double */
            for (int i = allIds.Count -1; i >= 0; --i)
            {
                Card card = deck.Draw();
                Assert.That(tmpId.Remove(card.cardId), Is.EqualTo(true), card + " shouldn't be drawn");
            }
            /*   Check that all cards are drawn   */
            Assert.That(tmpId.Count, Is.EqualTo(0), "some card arn't been drawn");
        }

    }
}
