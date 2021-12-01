using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyAppWeb.Pages
{
    public class PingoutModel : PageModel
    {
        public void OnGet()
        {
        }

        public void OnPost()
        {
            var s = "";
            //var emailAddress = Request.Form["emailaddress"];
            // do something with emailAddress
            
            ViewData["console"] = PingHost(Request.Form["domain"]);
        }

        public static string PingHost(string nameOrAddress)
        {
            bool pingable = false;
            System.Net.NetworkInformation.Ping pinger = null;
            System.Text.StringBuilder st = new System.Text.StringBuilder();

            for (var i = 1; i <= 3; i++)
            {
                st.Append("Ping - Retry #" + i.ToString());
                st.Append("<br/>");

                try
                {
                    pinger = new System.Net.NetworkInformation.Ping();
                    System.Net.NetworkInformation.PingReply reply = pinger.Send(nameOrAddress);
                    pingable = reply.Status == System.Net.NetworkInformation.IPStatus.Success;

                    st.Append("Address: " + reply.Address.ToString());
                    st.Append("<br/>");
                    st.Append("Status: " + reply.Status.ToString());


                    st.Append("<br/>");
                }
                catch (System.Net.NetworkInformation.PingException ex)
                {
                    // Discard PingExceptions and return false;
                    st.Append(ex.Message);
                    st.Append("<br/>");
                }
                finally
                {
                    if (pinger != null)
                    {
                        pinger.Dispose();
                    }
                }

                st.Append("-------------------------------");
                st.Append("<br/>");
            }

            return st.ToString(); ;
        }
    }
}
