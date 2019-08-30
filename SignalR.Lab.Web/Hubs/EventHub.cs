using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR.Lab.Web.Hubs
{
    //[HubName("EventHub")]
    public class EventHub : Hub<IEventHub>
    {
       // method for client to invoke
    }
}
