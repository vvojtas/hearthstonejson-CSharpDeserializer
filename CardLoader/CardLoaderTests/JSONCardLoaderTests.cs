using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using CardLoader;

namespace CardLoaderTests
{
    [TestFixture]
    public class JSONCardLoaderTests
    {
        [Test]
        [TestCase(false)]
        [TestCase(true)]
        public void ShouldDeserializeLeroy(bool strict)
        {
            var loader = new JSONCardLoader(@"TestFiles\Leeroy.json", strict);
            var result = loader.LoadCards();

            Assert.NotNull(result);
            Assert.AreEqual(1, result.Count);

            var card = result.First();

            Assert.AreEqual("Leeroy Jenkins", card.Name);
            Assert.AreEqual(5, card.Cost);
            Assert.AreEqual("Minion", card.Type);
            Assert.AreEqual("Legendary", card.Rarity);
            Assert.AreEqual("Alliance", card.Faction);
            Assert.AreEqual("<b>Charge</b>. <b>Battlecry:</b> Summon two 1/1 Whelps for your opponent.", card.Text);

            Assert.That(new string[] { "Battlecry", "Charge"}, Is.EquivalentTo(card.Mechanics));

            Assert.AreEqual("At least he has Angry Chicken.", card.Flavor);
            Assert.AreEqual("Gabe from Penny Arcade", card.Artist);
            Assert.AreEqual(6, card.Attack);
            Assert.AreEqual(2, card.Health);
            Assert.AreEqual(true, card.Collectible);
            Assert.AreEqual("EX1_116", card.Id);
            Assert.AreEqual(true, card.Elite);

            Assert.AreEqual("Classic", card.Set);
        }

        [Test]
        public void StrictShouldThrowOnDecoratedLeroy()
        {
            var loader = new JSONCardLoader(@"TestFiles\DecoratedLeeroy.json", true);

            Assert.Throws(Is.InstanceOf<Exception>(),() => loader.LoadCards());
        }

        [Test]
        public void UnstrictShouldNotThrowOnDecoratedLeroy()
        {
            var loader = new JSONCardLoader(@"TestFiles\DecoratedLeeroy.json", false);

            Assert.DoesNotThrow(() => loader.LoadCards());
        }

        [Test]
        [TestCase(false)]
        [TestCase(true)]
        public void ShouldDeserializeAllSets(bool strict)
        {
            var loader = new JSONCardLoader(@"TestFiles\AllSets.json", strict);
            var result = loader.LoadCards();
            Assert.NotNull(result);
            Assert.Greater(result.Count, 1000);
        }

    }
}
