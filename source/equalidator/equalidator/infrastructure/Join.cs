using System;

namespace equalidator.infrastructure
{
    public class Join<TInput1, TInput2> : Join<TInput1, TInput2, Tuple<TInput1, TInput2>>
    { }

    public class Join<TInput1, TInput2, TOutput>
    {
        private TInput1 message1;
        private bool message1Present;
        private TInput2 message2;
        private bool message2Present;
        private readonly Func<TInput1, TInput2, TOutput> outputCtor;

        public Join() {
            var ctor = typeof(TOutput).GetConstructor(new[] {typeof(TInput1), typeof(TInput2)});
            if (ctor == null) {
                throw new InvalidOperationException(string.Format(
                    "Type {0} needs to have a constructor with two parameters of type {1} and {2} respectively.", 
                    typeof(TOutput), typeof(TInput1), typeof(TInput2)));
            }
            outputCtor = (x, y) => (TOutput)ctor.Invoke(new object[] {x, y});
        }

        public event Action<TOutput> Output;

        public void Input1(TInput1 message) {
            message1 = message;
            message1Present = true;
            if (message2Present) {
                OutputResult();
            }
        }

        public void Input2(TInput2 message) {
            message2 = message;
            message2Present = true;
            if (message1Present) {
                OutputResult();
            }
        }

        private void OutputResult() {
            var result = outputCtor(message1, message2);
            Output(result);
        }
    }
}