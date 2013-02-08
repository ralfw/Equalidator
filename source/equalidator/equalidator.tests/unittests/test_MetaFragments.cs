using equalidator.datamodel;
using NUnit.Framework;

namespace equalidator.tests.unittests
{
    [TestFixture]
    public class test_MetaFragments
    {
        [Test]
        public void Compare_opening_fragments()
        {
            Assert.False(new OpeningFragment("a").Equals("b"));
            Assert.AreEqual(new OpeningFragment("a"), new OpeningFragment("a"));
            Assert.AreNotEqual(new OpeningFragment("a"), new OpeningFragment("b"));
        }


        [Test]
        public void Compare_closing_fragments()
        {
            Assert.AreEqual(new ClosingFragment(), new ClosingFragment());
            Assert.IsFalse(new ClosingFragment().Equals("b"));
        }

        
        [Test]
        public void Compare_null_fragments()
        {
            Assert.AreEqual(new NullFragment(), new NullFragment());
            Assert.IsFalse(new NullFragment().Equals("b"));
        }

        
        [Test]
        public void Compare_ref_fragments()
        {
            Assert.False(new ObjectReferenceFragment(1).Equals("b"));
            Assert.AreEqual(new ObjectReferenceFragment(1), new ObjectReferenceFragment(1));
            Assert.AreNotEqual(new ObjectReferenceFragment(1), new ObjectReferenceFragment(2));
        }
    }
}