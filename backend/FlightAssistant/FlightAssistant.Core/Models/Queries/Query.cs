namespace FlightAssistant.Core.Models.Queries
{
    public class Query
    {
        private int _page = 1;
        private int _itemsPerPage = 10;

        public int Page
        {
            get
            {
                if (_page < 1)
                {
                    _page = 1;
                }
                return _page;
            }
            set
            {
                _page = value;
            }
        }

        public int ItemsPerPage
        {
            get
            {
                if (_itemsPerPage < 10)
                {
                    _itemsPerPage = 10;
                }
                return _itemsPerPage;
            }
            set
            {
                _itemsPerPage = value;
            }
        }
    }
}
