using System;

namespace GraphQL.Domain.Entities
{
    public class TargetHistory : Entity<TargetHistory>
    {
        public string Sequence { get; set; }
        public int Target { get; set; }
        public string Result { get; set; }
        public DateTime Date { get; private set; } = DateTime.Now;

        public static implicit operator TargetHistory((string sequence, string result, int target) history)
        {
            return new TargetHistory
            {
                Sequence = history.sequence,
                Result = history.result,
                Target = history.target
            };
        }
    }
}
