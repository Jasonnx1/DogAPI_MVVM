using System;
using System.Collections.Generic;
using System.Text;

namespace ApiConsumerDemo.ViewModels.Commands
{
    public interface IErrorHandler
    {
        void HandleError(Exception ex);
    }
}
