using NUnit.Framework;

namespace equalidator.tests.usagedemo
{
    [TestFixture]
    public class Message_if_structures_differ
    {
        [Test]
        public void Two_differnet_array_lengths() {
            var a = new[] { 1, 2, 3 };
            var b = new[] { 1, 2, 3, 4 };
            Assert.That(() => Equalidator.AreEqual(a, b),
                Throws.Exception.Message.EqualTo("\nThe length of the structures (including private properties etc.) are different:\n  Expected: 5\n  But was:  6"));
        }
    }
}