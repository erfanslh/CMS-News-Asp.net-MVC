using CMSNachrichtModel.Context;
using CMSNachrichtModel.Model;
using CMSNachrichtRepository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSNachrichtService.Service
{
    public class AuthorService : GenericService<Author>, IAuthorService
    {
        IAuthorRepository _authorRepository;
        public AuthorService(DbNachrichtContext context) : base(context)
        {
            _authorRepository = new AuthorRepository(context);
        }

        public int GetUserId(string mobileNumber)
        {
            var user = _authorRepository.GetAll().FirstOrDefault(t => t.Mobilenumber == mobileNumber);
            return user.AuthorId;
        }


    }
}
