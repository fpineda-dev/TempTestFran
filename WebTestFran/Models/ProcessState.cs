using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WebTestFran.Models
{
    public enum ProcessState
    {
        [Description("Success")]
        Success = 1,
        [Description("Failed")]
        Failed = 2,
        [Description("Canceled")]
        Canceled = 3

    }
}