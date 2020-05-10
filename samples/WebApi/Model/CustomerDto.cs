using AspNetCore.Hashids;

namespace WebApi.Model
{
    public class CustomerDto
    {
        public HashidInt Id { get; set; }
        public int NonHashid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
