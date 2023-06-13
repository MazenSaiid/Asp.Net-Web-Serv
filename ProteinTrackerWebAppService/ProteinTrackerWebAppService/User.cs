using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProteinTrackerWebAppService
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Goal { get; set; }
        public int Total { get; set; }
    }
}