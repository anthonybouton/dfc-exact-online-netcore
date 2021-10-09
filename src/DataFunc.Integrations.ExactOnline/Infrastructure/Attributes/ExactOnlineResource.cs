using System;
using DataFunc.Integrations.ExactOnline.Infrastructure.Interfaces;

namespace DataFunc.Integrations.ExactOnline.Infrastructure.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ExactOnlineResource : Attribute, IExactOnlineEndPoint
    {
        public ExactOnlineResource(string endPoint)
        {
            EndPoint = endPoint;
        }

        public string EndPoint { get; }
    }
}