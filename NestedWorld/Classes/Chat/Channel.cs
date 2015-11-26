using NestedWorld.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NestedWorld.Classes.Chat
{
    public class Channel
    {
        private List<Message> _messageList;
        private string _chatName;
        
        public bool canEdit { get; private set; }

        public string chatName
        {
            get { return _chatName; }
            set
            {
                if (canEdit)
                    _chatName = value;
            }
        }

        public List<Message> messageList
        {
            get
            {
                return _messageList;
            }
            set
            {
                _messageList = value;
            }
        }

        public Channel(string chatName, bool canEdit = true)
        {
            messageList = new List<Message>();
            _chatName = chatName;
            this.canEdit = canEdit;
        }

        public void Add(Message message)
        {
            messageList.Add(message);

        }

        public override string ToString()
        {
            if (messageList.Count != 0)
                return messageList.Last().content;
            return "Start Convesation";
        }
    }
}
