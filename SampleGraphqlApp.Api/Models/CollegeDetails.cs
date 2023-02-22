using SampleGraphqlApp.Data.Interface.Models.Complete;

namespace SampleGraphqlApp.Api.Models
{
    public class CollegeDetails
    {
        public string studentId { get; set; }

        public College college { get; set; }
    }
}
