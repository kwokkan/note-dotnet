using NoteDotNet.Abstractions;

namespace NoteDotNet.Web.Models
{
    public class QueryChangedEventArgs
    {
        public string Query { get; set; }

        public int Limit { get; set; }

        public SortProperty SortProperty { get; set; }

        public SortDirection SortDirection { get; set; }
    }
}
