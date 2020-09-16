using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Payment
    {   public int Id { get; set; }
        public string paymentFor;
        public string PaymentFor
        {
            get { return paymentFor; }
            set { paymentFor = value.Trim(); }
        }
        public bool Active { get; set; }
        public int CustomerId { get; set; }
    }
    public class PaymentForProcess
    {
        public string PaymentForOne = "Payment is for a physical product.";
        public string PaymentForTwo = "Payment is for a book.";
        public string PaymentForThree = "Payment for a membership.";
        public string PaymentForFour = "Payment is upgrade to a membership.";
        public string PaymentForFive = "Payment is for a membership or upgrade.";
        public string PaymentForSix = "Payment for the video Learning to Ski.";
        public string PaymentForSeven = "Payment is for a physical product or book.";
    }
    public class CustomerDetail
    {
        public int CustomerId { get; set; }
        public string customerName;
        public string CustomerName
        {
            get { return customerName; }
            set { customerName = value.Trim(); }
        }
        public string customerAddress;
        public string CustomerAddress
        {
            get { return customerAddress; }
            set { customerAddress = value.Trim(); }
        }
        public string customerEmail;
        public string CustomerEmail
        {
            get { return customerEmail; }
            set { customerEmail = value.Trim(); }
        }
    }
}
