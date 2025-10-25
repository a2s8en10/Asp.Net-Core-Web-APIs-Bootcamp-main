using JWT_Sample.Data;

namespace JWT_Sample.Repository
{
    public class SampleRepository : ISampleRepository
    {
        private readonly SampleContext _context;
        public SampleRepository(SampleContext context)
        {
            _context = context;
        }





    }
}
