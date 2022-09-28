using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carmageddon.Forms
{
    public class HubConnectionSingleton
    {
        private object lockObject = new object();
        private HubConnection _connection = null;
        private const string URI = "https://localhost:7237/current-time";

        public HubConnectionSingleton()
        {
        }

        public HubConnection GetInstance()
        {
            lock (lockObject)
            {
                if (_connection == null)
                {
                    _connection = new HubConnectionBuilder().WithUrl(URI).Build();

                    _connection.StartAsync();
                }
            }

            return _connection;
        }
    }
}
