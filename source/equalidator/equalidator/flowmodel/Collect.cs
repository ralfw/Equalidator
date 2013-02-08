using System;
using System.Collections.Generic;
using equalidator.datamodel;

namespace equalidator.flowmodel
{
    public class Collect
    {
        private int _levelCounter;
        private readonly List<object> _fragments = new List<object>();


        public void Process(object fragment)
        {
            _fragments.Add(fragment);

            if (fragment is OpeningFragment) _levelCounter++;
            if (fragment is ClosingFragment) _levelCounter--;

            if (_levelCounter == 0) this.Result(_fragments);
        }

        public event Action<IEnumerable<object>> Result;
    }
}