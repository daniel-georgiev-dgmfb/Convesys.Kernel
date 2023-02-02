
namespace Platform.Kernel.Data.Temporal.Tests.L0
{
    public class PermPayment
    {
        public PayElement PayElement { get; set; }

        public decimal Amount { get; set; }
        public PayElement PaymentType { get; internal set; }

        public PermPayment(PayElement payElement, decimal amount) 
        {
            this.PayElement = payElement;
            this.PaymentType = payElement;
            this.Amount = amount;
        }
    }
}
