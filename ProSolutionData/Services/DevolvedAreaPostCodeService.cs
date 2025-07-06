using ProSolutionData.Data;
using ProSolutionData.Models;
using Microsoft.EntityFrameworkCore;
using ProSolutionData.Shared;

namespace ProSolutionData.Services
{
    public class DevolvedAreaPostCodeService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public List<DevolvedAreaPostCodeModel>? DevolvedAreaPostCodes { get; }

        public DevolvedAreaPostCodeService(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;

            //Moved out of main method so does not run every time

            //DevolvedAreaPostCodes = _context.DevolvedAreaPostCode
            //    .FromSqlInterpolated($"EXEC SPR_API_DevolvedAreaPostCode @PostCode = 'NE61 3RB'")
            //
        }

        public List<DevolvedAreaPostCodeModel> GetAll() => _context.DevolvedAreaPostCode.FromSqlInterpolated($"EXEC SPR_API_DevolvedAreaPostCode @PostCode = 'ALL'").ToList();
        public DevolvedAreaPostCodeModel? Get(string postcode) => (_context.DevolvedAreaPostCode.FromSqlInterpolated($"EXEC SPR_API_DevolvedAreaPostCode @PostCode = {postcode}").ToList()).FirstOrDefault();
    }
}
