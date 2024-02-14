using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Xml.Linq;

namespace XMLToPDFCreator.Repository
{
    public class PostResult
    {
        /// <summary>
        /// Indicates whether or not the post was successful
        /// </summary>
        public bool IsPosted { get; set; }

        /// <summary>
        /// Custom or system message returned from posting 
        /// </summary>
        public string Message { get; set; }
    }

    public class BizHandler
    {
        public BizHandler()
        {
            PostResult = new PostResult { IsPosted = false, Message = string.Empty };
        }

        public PostResult PostResult { get; set; }

        public bool PostToBiz(string bizLinkEndPoint,XDocument fContent, string fileName)
        {
            string fileContent = fContent.ToString();

            string contentType = "application/xml";
            byte[] bytes = null;
            string party = "";
            string from = "SaintGobainOCR";
            string to = "FIRSTNETAI";

            string uriBiz =
                string.Format("{0}?from={1}&to={3}&filename={2}.{1}.{3}",
                    bizLinkEndPoint, from == "" ? party : from, fileName, to);

            HttpWebRequest webRequest = WebRequest.Create(new Uri(uriBiz)) as HttpWebRequest;
            webRequest.Proxy = WebRequest.DefaultWebProxy;
            webRequest.Credentials = CredentialCache.DefaultCredentials;
            webRequest.Proxy.Credentials = CredentialCache.DefaultCredentials;

            webRequest.ContentType = contentType;
            webRequest.Method = "POST";

            if (bytes == null)
            {
                bytes = Encoding.ASCII.GetBytes(fileContent);
            }
            webRequest.ContentLength = bytes.Length;

            try
            {
                Stream stream = webRequest.GetRequestStream();
                stream.Write(bytes, 0, bytes.Length);
                stream.Close();
                HttpWebResponse webResponse = webRequest.GetResponse() as HttpWebResponse;
                if (webResponse == null)
                {
                    PostResult.Message = "Web response return a null. Please try again or contact support";
                    PostResult.IsPosted = false;
                    return false;
                }

                using (var streamReader = new StreamReader(webResponse.GetResponseStream()))
                {
                    PostResult.Message = streamReader.ReadToEnd().Trim();
                    PostResult.IsPosted = true;
                    return true;
                }
            }
            catch (Exception exception)
            {
                PostResult.Message = string.Format("Exception occured sending to Biz. {0}. {1}. {2}", fileName, exception.Message, exception.InnerException);
                PostResult.IsPosted = false;

                return false;
            }
        }

    }
}
