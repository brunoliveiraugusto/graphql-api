using System;

namespace GraphQL.Application.ViewModels
{
    public class TargetHistoryViewModel
    {
        public string Sequence { get; set; }
        public int Target { get; set; }
        public string Result { get; set; }
        public DateTime Date { get; set; }
    }
}
