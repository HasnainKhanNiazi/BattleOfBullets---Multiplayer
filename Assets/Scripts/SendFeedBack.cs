using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

public class SendFeedBack : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.L)) {
			Send_Feed_Back ();
		}
	}

	void Send_Feed_Back(){
		MailMessage mail = new MailMessage ();
		mail.From = new MailAddress ("hasikhan144@gmail.com");
		mail.To.Add ("hasikhan144@gmail.com");
		mail.Subject = "Subject Is Here";
		mail.Body = "Body Is Here";
		SmtpClient smtp_client = new SmtpClient ("smtp.gmail.com");
		smtp_client.Port = 587;
		smtp_client.Credentials = new System.Net.NetworkCredential ("hasikhan144@gmail.com","hasi1111") as ICredentialsByHost;
		smtp_client.EnableSsl = true;
		ServicePointManager.ServerCertificateValidationCallback = 
			delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) 
		{ return true; };
		smtp_client.Send(mail);
		Debug.Log("success");
	}
}