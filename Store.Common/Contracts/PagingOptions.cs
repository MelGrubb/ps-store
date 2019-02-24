namespace Store.Common.Contracts
{
    public class PagingOptions
    {
        private int _take;
        public int Skip { get; set; }

        public int Take
        {
            get => _take == 0 ? 10 : _take;
            set => _take = value;
        }
    }
}
