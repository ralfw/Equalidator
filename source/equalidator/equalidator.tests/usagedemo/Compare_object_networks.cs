using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace equalidator.tests.usagedemo
{
    [TestFixture]
    public class Compare_object_networks
    {
        [Test]
        public void Hierarchy()
        {
            var c1 = new Node {value = 11};
            var c2 = new Node { value = 12 };
            var p = new Node { value = 1, left=c1, right=c2 };

            var c1Tick = new Node { value = 11 };
            var c2Tick = new Node { value = 12 };
            var pTick = new Node { value = 1, left = c1Tick, right = c2Tick };

            Equalidator.AreEqual(p, pTick);
        }


        [Test]
        public void Hierarchy_with_multiple_refs_to_same_object()
        {
            var c1 = new Node { value = 11 };
            var c2 = new Node { value = 12, left=c1 };
            var p = new Node { value = 1, left = c1, right = c2 };

            var c1Tick = new Node { value = 11 };
            var c2Tick = new Node { value = 12, left=c1Tick };
            var pTick = new Node { value = 1, left = c1Tick, right = c2Tick };

            Equalidator.AreEqual(p, pTick);
        }

        
        [Test]
        public void Network_with_circular_reference()
        {
            var c1 = new Node { value = 11 };
            var c2 = new Node { value = 12 };
            var p = new Node { value = 1, left = c1, right = c2 };
            c2.left = p;

            var c1Tick = new Node { value = 11 };
            var c2Tick = new Node { value = 12 };
            var pTick = new Node { value = 1, left = c1Tick, right = c2Tick };
            c2Tick.left = pTick;

            Equalidator.AreEqual(p, pTick);
        }
    }

    class Node
    {
        public int value;
        public Node left, right;
    }
}