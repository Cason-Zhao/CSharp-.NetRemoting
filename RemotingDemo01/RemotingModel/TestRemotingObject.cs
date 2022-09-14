using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemotingModel
{
    // Step 1st：Create Remote Object
    // Define 3 methods，in order to test the effect in 3 types of channels
    public class TestRemotingObject:MarshalByRefObject
    {
        // Test for TcpChannel
        public int AddForTcpTest(int a, int b)
        {
            return a + b;
        }

        // Test for HttpChannel
        public int MinusForHttpTest(int a, int b)
        {
            return a - b;
        }

        // Test for IpcChannel
        public int MultipleForIPCTest(int a, int b)
        {
            return a * b;
        }

        public string TestForChannel(string channelName)
        {
            return $"Hello {channelName}";
        }
    }
}
