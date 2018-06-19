using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleRESTServer.Models
{
    public class Person
    {
        public long ID { get; set; }

        public Double payRate { get; set; }
        public String lastName { get; set; }
        public String firstName { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }

    }
}