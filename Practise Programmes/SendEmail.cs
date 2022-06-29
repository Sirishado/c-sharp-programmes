
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net;
namespace CasesEmailSending
{
    public static class CasesEmailSending
    {
       
        public static void GetMail()
        {
            

            
                            Email emailClass = new Email();
                            emailClass.IsHtml = true;
                            emailClass.Body = "Advanced c# Concept";
                            emailClass.ToAddress = "doppalapudiparvathi123@gmail.com";
                            emailClass.ToAddress = "dsirisha41@gmail.com";
                            emailClass.Subject = "Daily Report";
                            var isMailSend = emailClient.SendMailgun(emailClass);
                       
               
        }
    }
   
    public class emailClient
    {
        public static bool SendMailgun(Email email)
        {
            
            RestClient client = new RestClient();
            //client.UseUrlEncoder = new Uri(email.BaseUri);
            client.Authenticator = new HttpBasicAuthenticator("api", email.ApiKey);
            RestRequest request = new RestRequest();
            request.AddParameter("domain", email.Domain, ParameterType.UrlSegment);
            request.Resource = "/messages";
            request.AddParameter("from", email.FromAddress);
            request.AddParameter("to", email.ToAddress);
            email.IsHtml = true;
            if (!String.IsNullOrEmpty(email.BccAddress)) request.AddParameter("bcc", email.BccAddress);

            request.AddParameter("subject", email.Subject);

            if (email.IsHtml) request.AddParameter("html", email.Body);
            else request.AddParameter("text", email.Body);
            request.Method = Method.Post;
            var response1 = client.Execute(request);
            if (response1.StatusCode == HttpStatusCode.OK)
                email.Responce = true;
            else
                email.Responce = false;

            return email.Responce;
        }
    }
  
    public class Email
    {
        public bool IsHtml { get; set; }
        public string FromAddress { get; set; }
        public string ToAddress { get; set; }
        public string CcAddress { get; set; }
        public string BccAddress { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string ApiKey { get; set; }
        public string BaseUri { get; set; }
        public string Domain { get; set; }
        public bool Responce { get; internal set; }
        // public List<Attachment> Attachments { get; set; }
        // public string AttachmentName { get; set; }
        // public byte[] Pdfbytes { get; set; }
        // public string AttachmentData { get; set; }
        // public string AttachmentContentType { get; set; }
    }
}




