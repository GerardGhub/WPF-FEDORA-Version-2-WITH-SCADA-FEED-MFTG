﻿using System;
using System.Net;
using System.Xml;


namespace SharpUpdate
{
    internal class SharpUpdateXml
 
    {
        private Version version;
        private Uri uri;
        private string fileName;
        private string md5;
        private string description;
        private string launchArgs;


        internal Version Version
        {
            get { return this.version; }
        }
        internal Uri Uri
        {
            get { return this.uri; }
        }
        internal string FileName
        {
            get { return this.fileName; }
        }
        internal string MD5
        {
            get { return this.md5; }
        }
        internal string Description
        {
            get { return this.description; }
        }
        internal string LaunchArgs
        {
            get { return this.launchArgs; }
        }
        internal SharpUpdateXml(Version version, Uri uri, string fileName, string md5, string description, string launchArgs)
        {
            this.version = version;
            this.uri = uri;
            this.fileName = fileName;
            this.md5 = md5;
            this.description = description;
            this.launchArgs = launchArgs;

        }
        internal bool IsNewerThan(Version version)
        {
            return this.version > version;
        }

        internal static bool ExistsOnServer(Uri location)
        {
            try
            {
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(location.AbsoluteUri);
                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
                resp.Close();

                return resp.StatusCode == HttpStatusCode.OK;


            }
            catch { return false; }
  
        }


        internal static SharpUpdateXml Parse(Uri location, string appID)
        {
       

            try
            {
                Version version = null;
                string url = "", fileName = "", md5 = "", description = "", launchArgs = "";

                XmlDocument doc = new XmlDocument();
                doc.Load(location.AbsoluteUri);

                XmlNode updateNode = doc.DocumentElement.SelectSingleNode("//update[@appId='"+ appID +"']");

                if (updateNode == null)
                    return null;


                version = Version.Parse(updateNode["version"].InnerText);
                url = updateNode["url"].InnerText;
                fileName = updateNode["fileName"].InnerText;
                md5 = updateNode["md5"].InnerText;
                description = updateNode["description"].InnerText;
                launchArgs = updateNode["launchArgs"].InnerText;


                return new SharpUpdateXml(version, new Uri(url), fileName, md5, description, launchArgs);
            }
            catch { return null; }
        }
















    }




}
