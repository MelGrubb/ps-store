namespace Store.Common.Contracts
{
    public class PagingOptions
    {
        private const int defaultTake = 100;
        private int _take;
        public int Skip { get; set; }

        public int Take
        {
            get => _take == 0 ? defaultTake : _take;
            set => _take = value;
        }
    }
}
