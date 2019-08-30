using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR.Lab.Web.Hubs
{
    public interface IEventHub
    {
        Task SendNoticeEventToClient(string message);
    }
}
