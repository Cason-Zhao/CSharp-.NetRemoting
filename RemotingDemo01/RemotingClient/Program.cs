using RemotingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemotingClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TestChannel();

            Console.WriteLine("Press Any Key To Exit!");
            Console.ReadKey();
        }

        private static void TestChannel()
        {
            TestChannel("tcp://localhost:9001/TestRemotingObject");
            TestChannel("http://localhost:9002/TestRemotingObject");
            TestChannel("ipc://IpcTest/TestRemotingObject");
        }

        private static void TestChannel(string url)
        {
            var uri = new Uri(url);
            // Use Channel to get remote object
            var proxyObj = Activator.GetObject(typeof(TestRemotingObject), url) as TestRemotingObject;
            if(proxyObj == null)
            {
                Console.WriteLine($"Connect {uri.Scheme} server fail");
            }

            // Use proxy to call methods & output
            Console.WriteLine($"This call object by {uri.Scheme}：{proxyObj.TestForChannel(uri.Scheme)}");
        }
    }
}
