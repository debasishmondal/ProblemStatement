using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using System.Collections;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace ProblemStatement2
{
    public partial class OrderProcessing : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TestDBConnectionString"].ConnectionString);
        string s = "";
        Payment payment = new Payment();
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
        protected void gdvOrderProcess_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(gdvOrderProcess.DataKeys[e.RowIndex].Value.ToString());
            GridViewRow row = (GridViewRow)gdvOrderProcess.Rows[e.RowIndex]; 
            CheckBox chkActive = (CheckBox)row.Cells[2].Controls[0];
            Label lblPaymentFor = (Label)row.FindControl("lblPaymentFor");
            gdvOrderProcess.EditIndex = -1;          
            SqlDataSource1.UpdateCommand = "update OrderProcess set IsActive = '" + chkActive.Checked + "' where OrderProcessId = '" + id + "'";
            payment.PaymentFor = lblPaymentFor.Text;
            payment.Id = id;
            Page_Load(sender, e);
            OrderProcess();
        }
       public void OrderProcess()
        {
            PaymentForProcess paymentForProcess = new PaymentForProcess();
           
            
            if(paymentForProcess.PaymentForOne==payment.PaymentFor)
            {
                payment.PaymentFor = "";
                //Packing slip will be generated from redirected page
                // Response.Redirect("PackingSlip.aspx");
            }
            else if (paymentForProcess.PaymentForTwo == payment.PaymentFor)
            {
                payment.PaymentFor = "";
                //Upgrade membership will be from redirected page
                // Response.Redirect("UpgradeMembership.aspx");
            }
            else if (paymentForProcess.PaymentForThree == payment.PaymentFor)
            {//Membership activation
                SqlDataSource1.UpdateCommand = "update OrderProcess set IsActiveMembership = '" + true + "' where OrderProcessId = '" + payment.Id + "'";
            }
            else if (paymentForProcess.PaymentForFour == payment.PaymentFor)
            {
                payment.PaymentFor = "";
                // Application Upgrade will be from redirected page
               // Response.Redirect("ApplyUpgrade.aspx");
            }
            else if (paymentForProcess.PaymentForFive == payment.PaymentFor)
            {// Mail sent
                payment.PaymentFor = "";
                SendMail();
                lblMail.Text = "Mail send successfully.";
            }
        }
        public void SendMail()
        {
            CustomerDetail customerDetail = new CustomerDetail();
            SqlDataSource1.SelectCommand = "Select CustomerId from OrderProcess where OrderProcessId = '" + payment.Id + "'";
            payment.CustomerId = SqlDataSource1.SelectCommand.FirstOrDefault();
            SqlDataSource2.SelectCommand = "Select CustomerEmail from CustomerDetail where CustomerId = '" + payment.CustomerId + "'";
            customerDetail.CustomerEmail= SqlDataSource2.SelectCommand.FirstOrDefault().ToString();
            string to = customerDetail.CustomerEmail;//"deb_ml6@yahoo.co.in"; //To address    
            string from = "dev.mondal@gmail.com"; //From address    
            MailMessage message = new MailMessage(from, to);

            string mailbody = "In this article you will learn how to send a email using Asp.Net & C#";
            message.Subject = "Sending Email Using Asp.Net & C#";
            message.Body = mailbody;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
            System.Net.NetworkCredential basicCredential1 = new
            System.Net.NetworkCredential("your mailid", "password");
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = basicCredential1;
            try
            {
                client.Send(message);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
       
       
    }
}