using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dynamo.Core.IPC
{
    public abstract class Sender
    {
        /// <summary>
        /// Send a message
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public abstract bool SendMessage(Message message);
    }
}
