using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dynamo.Core.IPC
{
    public enum MessageType
    {
        Hello,
        ShutDown
    }

    public class Message
    {
        public UInt32 PayloadSize { get; set; }
        public UInt32 MessageID { get; set; }
        public UInt32 Flags { get; set; }
    }
}
