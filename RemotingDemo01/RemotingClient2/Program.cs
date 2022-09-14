using RemotingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace RemotingClient2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RemotingConfiguration.Configure("RemotingClient2.exe.config", false);
            
            var proxy = new TestRemotingObject();
            if(proxy == null)
            {
                Console.WriteLine("Connecting to the server failed!");
                return;
            }

            var channelType = new Uri(ChannelServices.GetUrlsForObject(proxy).First()).Scheme;
            Console.WriteLine($"This call object by {channelType} Channel, {proxy.TestForChannel(channelType)}");
            Console.WriteLine("Press Any Key To Exit!");
            Console.ReadKey();
        }
    }
}
