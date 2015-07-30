using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dynamo.Core.IPC
{
    public abstract class Listener
    {
        /// <summary>
        /// Called when a message is received.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public abstract bool OnMessageReceived(Message message);
    }
}
