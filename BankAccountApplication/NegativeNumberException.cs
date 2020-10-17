using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountApplication
{
    class NegativeNumberException: ApplicationException
    {
        private string details = String.Empty;

        public string errorCause { get; set; }

        public NegativeNumberException() { }

        public NegativeNumberException(string message) : base(message) { }

        public NegativeNumberException(string message, System.Exception inner) : base(message, inner) { }

        public NegativeNumberException(string message, string cause)
        {
            details = message;
            errorCause = cause;
        }

        public override string Message
        {
            get
            {
                return string.Format("{0}|{1}: {2}", details, errorCause);
            }

        }
    }
}
