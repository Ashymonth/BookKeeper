using System.Collections.Generic;

namespace BookKeeper.Data.Models.HtmlImport
{
    public class PaymentDocumentImport
    {
        public PaymentDocumentImport()
        {
            PaymentDetailsImports = new List<PaymentDetailsImport>();
        }
        public string District { get; set; }

        public string DocumentData { get; set; }

        public string Address { get; set; }

        public List<PaymentDetailsImport> PaymentDetailsImports { get; }
    }
}