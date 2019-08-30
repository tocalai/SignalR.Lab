using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR.Lab.Web.Models
{
    public class EventModel
    {
        public string EventDateTime { get; set; } = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
        public string Content { get; set; }
    }
}
