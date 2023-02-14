using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcquisitionSystem_WPF.Models
{
    public class Device
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Protocol { get; set; }
        public string IpAddress { get; set; }
        public string Port { get; set; }
        public string Description { get; set; }
        public string UpdateTime { get; set; }
        public string LastMessage { get; set; }
        public List<Item> Items { get; set; }
    }
}
