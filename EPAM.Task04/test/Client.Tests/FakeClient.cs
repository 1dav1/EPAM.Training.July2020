using StateClassLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace Client.Tests
{
    public class FakeClient
    {
        public EventHandler<MessageReceivedEventArgs> MessageReceived;
        public void ReceiveCallback(string message)
        {
            try
            {
                if (message.Length > 1 && message.IndexOf("<EOF>") > -1)
                {
                    MessageReceivedEventArgs args = new MessageReceivedEventArgs
                    {
                        Message = new StringBuilder(message).Replace("<EOF>", string.Empty).ToString(),
                    };
                    OnMessageReceived(args);
                }
            }
            catch(Exception)
            { }
        }

        protected virtual void OnMessageReceived(MessageReceivedEventArgs e)
        {
            EventHandler<MessageReceivedEventArgs> handler = MessageReceived;
            handler?.Invoke(this, e);
        }
    }
}
