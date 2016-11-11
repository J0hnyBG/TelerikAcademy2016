using System;
using System.Collections.Generic;

namespace ConsoleWebServer.Framework.HttpMessages.Contracts
{
    public interface IHttpMessage
    {
        Version ProtocolVersion { get; }

        IDictionary<string, ICollection<string>> Headers { get; }

        void AddHeader(string name, string value);
    }
}
