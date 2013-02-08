using System;
using System.Collections.Generic;
using equalidator.infrastructure;

namespace equalidator.flowmodel
{
    internal class EqualidatorFlow
    {
        public EqualidatorFlow(bool treatAllIEnumerablesAlike)
        {
            // Build
            var flattenA = new Flatten(treatAllIEnumerablesAlike);
            var flattenB = new Flatten(treatAllIEnumerablesAlike);
            var join = new Join<IEnumerable<object>, IEnumerable<object>>();
            var check = new Check_equality();

            // Bind
            _process += t => flattenA.Process(t.Item1);
            _process += t => flattenB.Process(t.Item2);

            flattenA.Result += join.Input1;
            flattenB.Result += join.Input2;

            join.Output += check.Process;
        }


        private readonly Action<Tuple<object, object>> _process;
        public void Process(Tuple<object, object> tuple)
        {
            _process(tuple);
        }
    }
}