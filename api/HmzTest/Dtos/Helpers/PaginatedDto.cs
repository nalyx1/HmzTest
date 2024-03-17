namespace HmzTest.Dtos.Helpers
{
    public class PaginatedDto<T>(int page, int totalPages, int perPage, int totalItems, List<T> data)
    {
        public int Page { get; set; } = page;
        public int TotalPages { get; set; } = totalPages;
        public int PerPage { get; set; } = perPage;
        public int TotalItems { get; set; } = totalItems;
        public List<T> Data { get; set; } = data;
    }
}
