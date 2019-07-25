using Linktrix.API.Domain.Models;

namespace Linktrix.API.Domain.Service.Communication
{
    public class TransactionResponse : BaseResponse
    {
        public Transaction Transaction { get; private set; }

        public TransactionResponse(bool success, string message, Transaction transaction) : base(success, message)
        {
            Transaction = transaction;
        }

        public TransactionResponse(Transaction transaction) : this(true, string.Empty, transaction) { }

        public TransactionResponse(string message) : this(false, message, null) { }
    }
}
