using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocean.Interface
{
    public interface IPipelineMiddleware
    {
        Task<object> InvokeAsync(object input, Func<Task<object>> next, object parameters);
    }
}
