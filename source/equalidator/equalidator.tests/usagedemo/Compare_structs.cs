using NUnit.Framework;

namespace equalidator.tests.usagedemo
{
    [TestFixture]
    public class Compare_structs
    {
        [Test]
        public void Compare_simple_structs()
        {
            Equalidator.AreEqual(new SimpleStruct {i = 1, s = "a"}, 
                                 new SimpleStruct {i = 1, s = "a"});
        }

        [Test]
        public void Compare_nested_structs()
        {
            Equalidator.AreEqual(new ParentStruct {b = true, simple = new SimpleStruct {i = 1, s = "a"}},
                                 new ParentStruct {b = true, simple = new SimpleStruct {i = 1, s = "a"}});
        }
    }


    public struct SimpleStruct
    {
        public int i;
        public string s;
    }

    public struct ParentStruct
    {
        public bool b;
        public SimpleStruct simple;
    }
}