using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace sj1948FinalProject
{
    public class Custom_Network_Discovery : NetworkDiscovery
    {
        private bool _receivedBradcast = false;

        private void Start()
        {
            Initialize();
        }

        public override void OnReceivedBroadcast(string fromAddress, string data)
        {
            if (!_receivedBradcast)
            {
                _receivedBradcast = true;
                base.OnReceivedBroadcast(fromAddress, data);
                Debug.Log("FromAddress: " + fromAddress + "  Data: " + data);
                string[] addressSplit = fromAddress.Split(':');
                string[] dataSplit = data.Split(':');
                NetworkManager.singleton.networkAddress = addressSplit[addressSplit.Length - 1];
                NetworkManager.singleton.networkPort = int.Parse(dataSplit[dataSplit.Length - 1]);
                NetworkManager.singleton.StartClient();
            }
        }

        public void StartListeningBroadcast()
        {
            StartAsClient();
        }

        public void StartAsHost()
        {
            NetworkManager.singleton.StartHost();
            StartAsServer();
        }

    }
}
