using Ocean.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocean.Activity.ResponseService.Middleware
{
    public class ResponseJob : IPipelineMiddleware
    {
        public async Task<object> InvokeAsync(object input, Func<Task<object>> next, object parameters)
        {
            /*
             
                begin process

             */


            return input;

        }
    }
}
