using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnThread
{

    public delegate void ResultCallbackDelegate(int result);
    public class NumberHelper
    {
        private readonly int _number;
        private readonly ResultCallbackDelegate _resultCallback;

        public NumberHelper(int number, ResultCallbackDelegate resultCallback)
        {
            _number = number;
            _resultCallback = resultCallback;
        }

        public void CalculateNumber ()
        {
            int sum = 0;
            for (int i =1 ; i <= _number; i++)
            {
                sum += i;
            }

            if (_resultCallback != null)
            {
                _resultCallback(sum);
            }
        }

    }
}
