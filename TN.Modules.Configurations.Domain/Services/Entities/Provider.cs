using TN.Modules.Buildings.Shared.SharedKernel;
using TN.Modules.Configurations.Domain.Services.ValueObjects;

namespace TN.Modules.Configurations.Domain.Services.Entities
{
    public sealed class Provider : EntityBase<ProviderId>
    {
        public string Name { get; private set; }

        public string Username { get; private set; }

        public string Password { get; private set; }

        public string Server { get; private set; }

        public int Timeout { get; private set; }

        public Guid TypeId { get; private set; }

        public Guid StatusId { get; private set; }

        public string Metadata { get; private set; }

        public Provider() : base(default) { }

        public Provider(ProviderId id, string name, string username, string password, string server, int timeout, Guid typeId, Guid statusId, string metadata) : base(id)
        {
            Name = name;
            Username = username;
            Password = password;
            Server = server;
            Timeout = timeout;
            TypeId = typeId;
            StatusId = statusId;
            Metadata = metadata;
        }
    }
}
