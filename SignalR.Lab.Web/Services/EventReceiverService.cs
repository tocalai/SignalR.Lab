using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using SignalR.Lab.Web.Hubs;
using SignalR.Lab.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;

namespace SignalR.Lab.Web.Services
{
    public class EventReceiverService
    {
        private readonly IHubContext<EventHub> _eventHub;

        private Timer _mockEventGenTimer;

        public EventReceiverService(IHubContext<EventHub> eventHub)
        {
            _eventHub = eventHub;

            Init();
        }

        private void Init()
        {
            _mockEventGenTimer = new Timer(3 * 1000)
            {
                AutoReset = false
            };

            _mockEventGenTimer.Elapsed += MockEventGenTimer_Elapsed; ;

           
        }

        public void StartReceive()
        {
            _mockEventGenTimer.Start();
            Console.WriteLine("Start receiving..........");
        }

        private void MockEventGenTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _mockEventGenTimer.Enabled = false;

            var mockEvent = new EventModel()
            {
                Content = $"{new Random().Next()}"
            };

            _eventHub.Clients.All.SendAsync(nameof(IEventHub.SendNoticeEventToClient),
                JsonConvert.SerializeObject(mockEvent)).GetAwaiter().GetResult();

            _mockEventGenTimer.Enabled = true;
        }
    }
}
