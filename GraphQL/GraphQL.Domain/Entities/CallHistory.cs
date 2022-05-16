using System;

namespace GraphQL.Domain.Entities
{
    public class CallHistory : Entity<CallHistory>
    {
        public string Sequence { get; set; }
        public string Target { get; set; }
        public string Result { get; set; }
        public DateTime CallDate { get; private set; } = DateTime.Now;
    }
}
