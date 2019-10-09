namespace Fisher.Core.Utilities
{
    public class PaginationRequest
    {
        public int NumberOfPage { get; set; }
        public int Size { get; set; }

        public PaginationRequest(int numberOfPage, int size=10)
        {
            NumberOfPage = numberOfPage;
            Size = size;
        }
    }
}