using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountApplication
{
    class NotNumberException: ApplicationException
    {
        private string details = String.Empty;

        public string errorCause { get; set; }

        public NotNumberException() { }

        public NotNumberException(string message) : base(message) { }

        public NotNumberException(string message, System.Exception inner) : base(message, inner) { }

        public NotNumberException(string message, string cause)
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
