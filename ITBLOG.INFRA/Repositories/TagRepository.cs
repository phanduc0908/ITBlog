using System;
using System.Collections.Generic;
using System.Text;
using ITBLOG.CORE.Models;
using ITBLOG.INFRA.Infrastructure;
using System.Linq;

namespace ITBLOG.INFRA.Repositories
{
    public interface ITagRepository
    {
        IEnumerable<Tag> GetAllTagNames();
    }
    public class TagRepository : RepositoryBase<Tag>,ITagRepository
    {
        public TagRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<Tag> GetAllTagNames()
        {
            var Tags = this.DbContext.Tags.ToList();
            return Tags;
        }
    }
}
