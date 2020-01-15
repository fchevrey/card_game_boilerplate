using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class T_Card
    {
        [Test]
        public void AtestCardStaticFunctions()
        {
            List<eCardId> allIds = new List<eCardId>((eCardId[])System.Enum.GetValues(typeof(eCardId)));
            allIds.Remove(eCardId.none);
            int i = 0;
            foreach (eCardId id in allIds)
            {
                ++i;
                eCardValue value = Card.GetValueOf(id);
                eCardFaction faction = Card.GetFactionOf(id);
                eCardId testId = Card.GetIdOf(value, faction);
                eCardColor color = Card.GetColorOf(id);
                Assert.That(id, Is.EqualTo(testId), "wanted id doesn't match faction and value");
                if (faction == eCardFaction.club || faction == eCardFaction.spade) //pique ou trèfle
                { Assert.That(color, Is.EqualTo(eCardColor.black), "club or spade should be black"); }
                else if (faction == eCardFaction.diamond || faction == eCardFaction.heart)
                { Assert.That(color, Is.EqualTo(eCardColor.red), "diamond or heart should be red"); }
                else if (faction == eCardFaction.none)
                { Assert.That(color, Is.EqualTo(eCardColor.none), "\"none\" faction should be color \"none\""); }
            }
            Debug.Log(i + " cards tested");
            Assert.That(i, Is.EqualTo(53), "wrong size of cardId");
        }
        [Test]
        public void TestCreateJoker()
        {
            Card card = new Card(eCardId.joker);
            Assert.That(card.cardValue, Is.EqualTo(eCardValue.joker));
            Assert.That(card.color, Is.EqualTo(eCardColor.all));
            Assert.That(card.faction, Is.EqualTo(eCardFaction.all));
        }
        private void TestCard(Card card, eCardId wantedId, string msg)
        {
            eCardValue value = Card.GetValueOf(wantedId);
            eCardColor color = Card.GetColorOf(wantedId);
            eCardFaction faction = Card.GetFactionOf(wantedId);
            Assert.That(card.cardId, Is.EqualTo(wantedId), msg);
            Assert.That(card.cardValue, Is.EqualTo(value), msg);
            Assert.That(card.color, Is.EqualTo(color), msg);
            Assert.That(card.faction, Is.EqualTo(faction), msg);
        }
        private void TestCard(Card card,  eCardValue wantedValue, eCardFaction wantedfaction, string msg)
        {
            eCardId wantedId = Card.GetIdOf(wantedValue, wantedfaction);
            eCardColor color = Card.GetColorOf(wantedfaction);
            Assert.That(card.cardId, Is.EqualTo(wantedId), msg);
            Assert.That(card.cardValue, Is.EqualTo(wantedValue), msg);
            Assert.That(card.color, Is.EqualTo(color), msg);
            Assert.That(card.faction, Is.EqualTo(wantedfaction), msg);
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator T_CardWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }
    }
}
