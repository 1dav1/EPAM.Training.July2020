﻿using StateClassLibrary;
using System;
using System.Net;
using System.Xml;

namespace ServerClassLibrary
{
    public class XmlLister
    {
        public void Handle(AsyncListener listener, string file)
        {
            listener.MessageReceived += delegate (object sender, MessageReceivedEventArgs args)
            {
                XmlDocument document = new XmlDocument();
                string ip = IPAddress.Parse(((IPEndPoint)args.EndPoint).Address.ToString()).ToString();
                try
                {
                    document.Load(file);
                    XmlElement childElement = document.CreateElement("message");
                    childElement.InnerText = args.Message;
                    XmlElement root = document.DocumentElement;
                    XmlNode node = document.DocumentElement
                                           .SelectSingleNode("//clients/client[@ip='" + ip
                                            + "']");
                    if (node != null)
                    {
                        node.AppendChild(childElement);
                    }
                    else
                    {
                        XmlElement newNode = document.CreateElement("client");
                        newNode.SetAttribute("ip", ((IPEndPoint)args.EndPoint).Address.ToString());
                        newNode.AppendChild(childElement);
                        root.AppendChild(newNode);
                    }
                    document.Save(file);
                }
                catch (Exception)
                {
                    document.LoadXml("<?xml version=\"1.0\"?> \n" +
                                     "<clients> \n" +
                                     "</clients>");
                    XmlElement root = document.DocumentElement;
                    XmlElement newNode = document.CreateElement("client");
                    newNode.SetAttribute("ip", ip);
                    XmlElement childElement = document.CreateElement("message");
                    childElement.InnerText = args.Message;
                    newNode.AppendChild(childElement);
                    root.AppendChild(newNode);
                    document.Save(file);
                }
            };
        }
    }
}
