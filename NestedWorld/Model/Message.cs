using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NestedWorld.Model
{

    public enum eWho
    {
        ME,
        YOU,
    }
    public class Message
    {
        public string content { get; private set; }
        public DateTime time { get; private set; }
        public eWho who { get; private set; }

        public Message(string c, DateTime t, eWho w)
        {
            content = c;
            time = t;
            who = w;
        }
    }
}
