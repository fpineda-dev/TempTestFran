using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebTestFran.Models
{

    [DataContract(Namespace = "")]
    public class ProcessResult
    {

        [DataMember]
        public string Details { get; set; }
        [DataMember]
        public object OutputValue { get; set; }
        [DataMember]
        public ProcessState State { get; set; }

        public bool OutputValueIsNull()
        {

            return OutputValue == null ? true : false;

        }

        public bool IsSuccess()
        {
            return State == ProcessState.Success ? true : false;
        }

        public bool IsFailed()
        {
            return State == ProcessState.Failed ? true : false;
        }

        public bool IsCanceled()
        {
            return State == ProcessState.Canceled ? true : false;
        }



    }
}