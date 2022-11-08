using ExpressEaglesCourier.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressEaglesCourier.Data.Models
{
    public class EmployeeShipment
    {
        public string ShipmentId { get; set; }

        public virtual Shipment Shipment { get; set; }

        public string EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }


    }
}
