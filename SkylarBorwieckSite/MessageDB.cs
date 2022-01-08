using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using SkylarBorwieckSite.Models;

namespace SkylarBorwieckSite
{
    public static class MessageDB
    {
        private static string filename = "chatHistory.txt";
        private static bool loaded = false;
        private static List<MessageModel> message = new List<MessageModel>();


        public static List<MessageModel> Get()
        {
            if(loaded == false)
            {
                Load();
            }
            return message;
        }
        public static void Load()
        { 
            string line;
            string sender;
            string receipient;
            string subject;
            string text;
            string time;
            try
            {
                StreamReader reader = new StreamReader(filename);

                while (true)
                {

                    line = reader.ReadLine();
                    if (line == null) break;
                    List<String> parts = line.Split('|').ToList();

                    sender = WebUtility.UrlDecode(parts[0]);
                    receipient = WebUtility.UrlDecode(parts[1]);
                    time = WebUtility.UrlDecode(parts[2]);
                    subject = WebUtility.UrlDecode(parts[3]);
                    text = WebUtility.UrlDecode(parts[4]);
                    message.Add(new MessageModel { Sender = sender, Receipient = receipient, MsgTime = time, Subject = subject, Message = text }) ;
                }

                reader.Close();
            }
            catch(Exception)
            {
                throw new InvalidDataException();
            }
            loaded = true;
        }

        public static void AddMessage(MessageModel newMessage)
        {
            if (loaded == false)
                Load();
            newMessage.MsgTime = DateTime.Now.ToString();

            message.Add(newMessage);
        }
        public static void Save()
        {
            if (loaded == false)
                Load();

            StreamWriter writer = new StreamWriter(filename);

            foreach (MessageModel chat in message)
            {
                string sender = WebUtility.UrlEncode(chat.Sender);
                string receipient = WebUtility.UrlEncode(chat.Receipient);
                string time = WebUtility.UrlEncode(chat.MsgTime);
                string subject = WebUtility.UrlEncode(chat.Subject);
                string text = WebUtility.UrlEncode(chat.Message);

                string line = sender + "|" + receipient + "|"+ time + "|" + subject + "|" + text;

                writer.WriteLine(line);
            }
            writer.Close();
        }

    }
}
