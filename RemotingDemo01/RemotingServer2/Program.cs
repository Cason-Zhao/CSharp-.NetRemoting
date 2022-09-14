using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace RemotingServer2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RemotingConfiguration.Configure("RemotingServer2.exe.config", false);
            foreach(var channel in ChannelServices.RegisteredChannels)
            {
                Console.WriteLine($"The name of the channel is {channel.ChannelName}");
                Console.WriteLine($"The priority of the channel is {channel.ChannelPriority}");
            }
            Console.WriteLine("Press Any Key To Exit!");
            Console.ReadKey();
        }
    }
}
