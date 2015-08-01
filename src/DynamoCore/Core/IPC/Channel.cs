using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Dynamo.Core.IPC
{
    public class Channel
    {
        private Process process;

        internal string Name { get; private set; }

        internal Channel(Process process, string name)
        {
            this.process = process;
            this.Name = name;
        }

        internal void Close()
        {
            // TODO: Close out the communication channel and 
            // shutdown the corresponding execution instance.
        }
    }
}
