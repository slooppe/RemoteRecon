﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Ipc;
using System.Threading;
using RemoteReconKS;

namespace server
{
    public class server
    {
        public server()
        {

        }

        public static void Run(string nothing)
        {
            MessageBox.Show("Running the server!");
            IpcChannel ipc = new IpcChannel("localhost:52341");
            ChannelServices.RegisterChannel(ipc, false);
            RemoteRecon recon = new RemoteRecon();

            ObjRef recRef = RemotingServices.Marshal(recon);

            //keep the server alive????
            Console.ReadLine();

            RemotingServices.Unmarshal(recRef);
            RemotingServices.Disconnect(recon);
            ChannelServices.UnregisterChannel(ipc);
        }
    }
}
