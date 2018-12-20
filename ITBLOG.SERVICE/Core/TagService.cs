using ITBLOG.CORE.Models;
using ITBLOG.INFRA.Infrastructure;
using ITBLOG.INFRA.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITBLOG.SERVICE.Core
{
    public interface ITagService
    {
        IEnumerable<Tag> GetAllTagNames();
    }
    public class TagService : ITagService
    {
        private readonly ITagRepository _tagRepository;
        private readonly IUnitOfWork _unitOfWork;
        public TagService(ITagRepository tagRepository, IUnitOfWork unitOfWork)
        {
            _tagRepository = tagRepository;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Tag> GetAllTagNames()
        {
            return _tagRepository.GetAllTagNames();
        }
    }
}
