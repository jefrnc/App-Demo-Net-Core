using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyAppWeb.Pages
{
    public class wgetModel : PageModel
    {
        public void OnGet()
        {
        }

        public void OnPost()
        {
            var s = "";
            //var emailAddress = Request.Form["emailaddress"];
            // do something with emailAddress

            ViewData["console"] = Wget(Request.Form["domain"]);
        }

        public static string Wget(string nameOrAddress)
        {
            System.Text.StringBuilder st = new System.Text.StringBuilder();
            try
            {
                WebRequest request = WebRequest.Create(nameOrAddress);
                // If required by the server, set the credentials.
                request.Credentials = CredentialCache.DefaultCredentials;

                // Get the response.
                WebResponse response = request.GetResponse();
                // Display the status.
                Console.WriteLine(((HttpWebResponse)response).StatusDescription);

                // Get the stream containing content returned by the server.
                // The using block ensures the stream is automatically closed.
                using (Stream dataStream = response.GetResponseStream())
                {
                    // Open the stream using a StreamReader for easy access.
                    StreamReader reader = new StreamReader(dataStream);
                    // Read the content.
                    string responseFromServer = reader.ReadToEnd();

                    st.Append(responseFromServer);
                    st.Append("<br/>");
                }
                // Close the response.
                response.Close();

                st.Append("-------------------------------");
                st.Append("<br/>");
            }
            catch (Exception ex)
            {
                st.Append(ex.Message);
                st.Append("<br/>");
            }
            return st.ToString(); ;
        }
    }
}
