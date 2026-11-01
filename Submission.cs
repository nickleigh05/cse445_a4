using System;
using System.Xml.Schema;
using System.Xml;
using Newtonsoft.Json;
using System.IO;



/**
 * This template file is created for ASU CSE445 Distributed SW Dev Assignment 4.
 * Please do not modify or delete any existing class/variable/method names. However, you can add more variables and functions.
 * Uploading this file directly will not pass the autograder's compilation check, resulting in a grade of 0.
 * **/


namespace ConsoleApp1
{


    public class Submission
    {
        public static string xmlURL = "https://raw.githubusercontent.com/nickleigh05/cse445_a4/main/NationalParks.xml";
        public static string xmlErrorURL = "https://raw.githubusercontent.com/nickleigh05/cse445_a4/main/NationalParksErrors.xml";
        public static string xsdURL = "https://raw.githubusercontent.com/nickleigh05/cse445_a4/main/NationalParks.xsd";

        public static void Main(string[] args)
        {
            string result = Verification(xmlURL, xsdURL);
            Console.WriteLine(result);


            result = Verification(xmlErrorURL, xsdURL);
            Console.WriteLine(result);


            result = Xml2Json(xmlURL);
            Console.WriteLine(result);
        }

        // Q2.1
        public static string Verification(string xmlUrl, string xsdUrl)
        {
            //return "No Error" if XML is valid. Otherwise, return the desired exception message.

            string error = "";

            try{

                XmlDocument document = new XmlDocument();
                document.Schemas.Add(null, xsdUrl);
                document.LoadXml(DownloadContent(xmlUrl));
                document.Validate((sender, error) => error += error.Message + "\n");

            }

            catch (Exception exception){
        
                error += exception.Message + "\n";
            }

            return error == "" ? "No Error" : error;

        }

        public static string Xml2Json(string xmlUrl)
        {
            // The returned jsonText needs to be de-serializable by Newtonsoft.Json package. (JsonConvert.DeserializeXmlNode(jsonText))
        
            XmlDocument document = new XmlDocument();
            document.LoadXml(DownloadContent(xmlUrl));
            return JsonConvert.SerializeXmlNode(document);
            
        }

        // Helper method to download content from URL
        private static string DownloadContent(string url)
        {
            using (System.Net.WebClient client = new System.Net.WebClient())
            {
                return client.DownloadString(url);
            }
        }
    }

}
