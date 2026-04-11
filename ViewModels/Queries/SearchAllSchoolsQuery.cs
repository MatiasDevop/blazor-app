namespace ViewModels.Queries
{
    public class SearchAllSchoolsQuery
    {
        public int Skip { get; set; }
        public int Take { get; set; } = 20;

        public string SearchString { get; set; }

    }
}