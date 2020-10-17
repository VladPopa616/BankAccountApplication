using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountApplication
{
    class WrongMenuChoiceException : ApplicationException
    {
        private string details = String.Empty;

        public string errorCause { get; set; }

        public WrongMenuChoiceException() { }

        public WrongMenuChoiceException(string message): base(message) { }

        public WrongMenuChoiceException(string message, System.Exception inner): base(message,inner) { }

        public WrongMenuChoiceException(string message, string cause)
        {
            details = message;
            errorCause = cause;
        }

        public override string Message
        {
            get
            {
                return string.Format("{0}|{1}", details, errorCause);
            }
            
        }
    }
}
