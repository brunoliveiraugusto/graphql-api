using System;

namespace GraphQL.Application.ViewModels
{
    public class TargetHistoryViewModel
    {
        public int Id { get; set; }
        public string Sequence { get; set; }
        public int Target { get; set; }
        public string Result { get; set; }
        public string Date { get; set; }
    }
}
