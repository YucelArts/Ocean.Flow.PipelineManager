using Ocean.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocean.Activity.SmtpClientService.Middleware
{
    public class SmtpClientJob : IPipelineMiddleware
    {
        public async Task<object> InvokeAsync(object input, Func<Task<object>> next, object parameters)
        {

            /*
            
                begin method

             */

            return input;
        }
    }
}
