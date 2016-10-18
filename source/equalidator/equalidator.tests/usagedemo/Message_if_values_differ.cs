using NUnit.Framework;

namespace equalidator.tests.usagedemo
{
    [TestFixture]
    public class Message_if_values_differ
    {
        [Test]
        public void Two_different_ints() {
            Assert.That(() => Equalidator.AreEqual(2, 3),
                Throws.Exception.Message.EqualTo("\nThe following values are different:\n  Expected: 2\n  But was:  3"));
        }

        [Test]
        public void Two_different_structures() {
            var a = new { x = 1, y = "2" };
            var b = new { x = 3, y = "2" };
            Assert.That(() => Equalidator.AreEqual(a, b),
                Throws.Exception.Message.EqualTo("\nThe following values are different:\n  Expected: 1\n  But was:  3"));
        }

        [Test]
        public void Two_differnet_arrays() {
            var a = new[] { 1, 2, 3 };
            var b = new[] { 1, 2, 4 };
            Assert.That(() => Equalidator.AreEqual(a, b),
                Throws.Exception.Message.EqualTo("\nThe following values are different:\n  Expected: 3\n  But was:  4"));
        }
    }
}