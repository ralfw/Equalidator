using NUnit.Framework;

namespace equalidator.tests.usagedemo
{
    [TestFixture]
    public class Message_if_types_differ
    {
        [Test]
        public void Different_types() {
            var a = 1;
            var b = "2";
            Assert.That(() => Equalidator.AreEqual(a, b),
                Throws.Exception.Message.EqualTo("\nThe following types are different:\n  Expected: System.Int32\n  But was:  System.String"));
        }
    }
}