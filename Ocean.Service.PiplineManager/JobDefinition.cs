using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Ocean.Service.PipelineManager
{
    public class JobDefinition
    {
        public int BaseID { get; set; }
        public int ParentId { get; set; } // Job'un bağlı olduğu üst job
        public int JobOrder { get; set; }
        public string JobType { get; set; } // Job türü (BeginJob, EndJob, vs.)
        public JsonElement Parameters { get; set; } // Job için gerekli parametreler
    }
}
