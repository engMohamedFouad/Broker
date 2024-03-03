using Microsoft.EntityFrameworkCore;
using Pinnacle.Data.Entities.BasicData;
using Pinnacle.Infrustructure.Context;
using Pinnacle.Infrustructure.InfrastructureBases;
using Pinnacle.Plans.Infrastructure.Abstracts;

namespace Pinnacle.Plans.Infrastructure.Repositories
{
    public class FilesRepository : GenericRepositoryAsync<Files>, IFilesRepository
    {
        #region Fields
        private DbSet<Files> _files;
        #endregion

        #region Constructors
        public FilesRepository(ApplicationDBContext dbContext) : base(dbContext)
        {
            _files=dbContext.Set<Files>();
        }
        #endregion
    }
}
