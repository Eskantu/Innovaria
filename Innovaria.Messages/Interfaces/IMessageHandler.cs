using Innovaria.Messages.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovaria.Messages.Interfaces
{
    public interface IMessageHandler<T> where T:IMessage
    {
        Task Handle(T message);
    }
}
