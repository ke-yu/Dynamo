using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace Dynamo.Core.IPC
{
    /// <summary>
    /// Communicator is an object owned by DynamoModel that is responsible in 
    /// handling all communications with execution instances. It also manages 
    /// the life-cycle of each execution instance.
    /// </summary>
    class Communicator
    {
        private Dictionary<Guid, Channel> channels;

        internal Communicator()
        {
            channels = new Dictionary<Guid, Channel>();
        }

        internal bool EstablishChannel(Guid workspaceGuid)
        {
            // Channel objects are not exposed beyond Communicator.
            return LaunchExecutionInstance(workspaceGuid) != null;
        }

        internal void CloseChannel(Guid workspaceGuid)
        {
            if (!channels.ContainsKey(workspaceGuid))
                throw new ArgumentException("workspaceGuid");

            var channel = channels[workspaceGuid];
            channel.Close();
            channels.Remove(workspaceGuid);
        }

        /// <summary>
        /// Call this method to launch a new execution instance for the 
        /// targeted home workspace.
        /// </summary>
        /// <param name="workspaceGuid">The identifier of the workspace this new 
        /// execution instance is meant for.</param>
        /// <returns>Returns a communication channel if a new execution instance 
        /// can be created, or null otherwise.</returns>
        /// 
        private Channel LaunchExecutionInstance(Guid workspaceGuid)
        {
            var channelName = workspaceGuid.ToString().Replace("-", "").ToLower();
            var argument = string.Format("/t 1 /a dynamo.{0}", channelName);

            var process = new Process();
            process.StartInfo.FileName = Process.GetCurrentProcess().MainModule.FileName;
            process.StartInfo.Arguments = argument;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.WorkingDirectory = Directory.GetCurrentDirectory();
            process.StartInfo.CreateNoWindow = true;

            try
            {
                var returnValue = process.Start();
                var channel = new Channel(process, channelName);
                channels.Add(workspaceGuid, channel);

                return channel;
            }
            catch (Exception e)
            {
                // TODO: Log error message here...
                return null;
            }
        }
    }
}
