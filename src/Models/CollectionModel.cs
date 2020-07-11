namespace NoteDotNet.Models
{
    public class CollectionModel<TItem>
    {
        public int Offset { get; set; }

        public int Total { get; set; }

        public TItem[] Items { get; set; }
    }
}
