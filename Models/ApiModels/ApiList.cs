namespace ARS_OS.Models.ApiModels
{
    public record ApiList<T>
    {
        public long DisplayCount { get; set; }

        public long TotalCount { get; set; }

        public T Items { get; set; }

        public ApiList(T items, long displayCount, long totalCount)
        {
            DisplayCount = displayCount;
            TotalCount = totalCount;
            Items = items;
        }
    }
}
