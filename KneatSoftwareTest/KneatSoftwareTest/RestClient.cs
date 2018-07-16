using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace KneatSoftwareTest
{
    class RestClient
    {
        public string EndPoint { get; set; }

        public RestClient()
        {
            EndPoint = "";
        }

        // retrieve data from the API
        public string makeRequest()
        {
            string strResponseValue = string.Empty;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(EndPoint);

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                // check if the response is okay
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new ApplicationException("Error code: " + response.StatusCode.ToString());
                }

                // proccess the response stream
                using (Stream responseStream = response.GetResponseStream())
                {
                    if(responseStream != null)
                    {
                        using (StreamReader reader = new StreamReader(responseStream))
                        {
                            strResponseValue = reader.ReadToEnd();
                        }
                    }
                }
                            
            }

            return strResponseValue;
        }
    }
}
