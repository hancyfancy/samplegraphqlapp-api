using SampleGraphqlApp.Data.Interface.Models.Complete;

namespace SampleGraphqlApp.Api.Models
{
    public class BookDetails
    {
        public string studentFirstName { get; set; }

        public List<Book> books { get; set; }
    }
}
