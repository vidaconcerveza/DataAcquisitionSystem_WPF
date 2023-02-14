using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcquisitionSystem_WPF.Models
{
    public class Item
    {
        public int Id { get; set; }
        public Device Device { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string Code { get; set; }
        public string Value { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public bool IsEvent { get; set; }
        public bool IsLog { get; set; }
    }
}
