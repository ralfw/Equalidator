using equalidator.exceptions;
using NUnit.Framework;

namespace equalidator.tests.integration
{
    [TestFixture]
    public class test_Equalidator
    {
        [Test]
        public void Single_objects()
        {
            Assert.Throws<NotEqualDueToDifferentValues>(() => Equalidator.AreEqual(1, 2));
        }
    }
}
