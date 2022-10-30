using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    public partial class Rootobject
    {
        public string status { get; set; }
        public Datum[] data { get; set; }
        public string message { get; set; }
    }

    public partial class RootObjectPost
    {
        public string status { get; set; }
        public DatumPost data { get; set; }
        public string message { get; set; }
    }

    public partial class RootObjectPut
    {
        public string status { get; set; }
        public DatumPut data { get; set; }
        public string message { get; set; }
    }

    public partial class Datum
    {
        public int id { get; set; }
        public string employee_name { get; set; }
        public int employee_salary { get; set; }
        public int employee_age { get; set; }
        public string profile_image { get; set; }
    }
    public partial class DatumPost
    {
        public string name { get; set; }
        public int salary { get; set; }
        public int age { get; set; }
        public int id { get; set; }
    }
    public partial class DatumPut
    {
        public string name { get; set; }
        public int salary { get; set; }
        public int age { get; set; }
    }

    public partial class Data
    {
        public int id { get; set; }
        public string employee_name { get; set; }
        public string employee_salary { get; set; }
        public string employee_age { get; set; }
        public string profile_image { get; set; }
    }
}
