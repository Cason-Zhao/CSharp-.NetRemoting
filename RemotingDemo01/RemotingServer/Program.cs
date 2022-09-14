using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Remoting.Channels.Ipc;

using RemotingModel;

namespace RemotingServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Step1&2: Create Channel & Register Channel
            TestForChannel(new TcpChannel(9001));
            TestForChannel(new HttpChannel(9002));
            TestForChannel(new IpcChannel("IpcTest"));

            // Step3: Register Object
            // Register TestRemotingObject into .Net Remoting Runtime
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(TestRemotingObject), nameof(TestRemotingObject), WellKnownObjectMode.Singleton);
            Console.WriteLine("Press any key to exit");

            Console.ReadKey();
        }

        private static void TestForChannel(IChannel channel)
        {
            Console.WriteLine($"Channel Object Type: {channel.GetType()}");

            // Register Channel
            ChannelServices.RegisterChannel(channel, false);

            // Print Channel Info
            Console.WriteLine($"The name of the channel is {channel.ChannelName}");
            Console.WriteLine($"The priority of the channel is {channel.ChannelPriority}");

        }
    }
}
