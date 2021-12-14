using System.Collections.Generic;

namespace WebSales.Shared.Response
{
    public sealed class ErrorResult
    {
        public ErrorResult(ICollection<string> messages)
        {
            Messages = messages;
        }
        public ICollection<string> Messages { get; set; }
    }
}
