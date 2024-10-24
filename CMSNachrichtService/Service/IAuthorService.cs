using CMSNachrichtModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSNachrichtService.Service
{
    public interface IAuthorService : IGenericService<Author>
    {
        int GetUserId(string mobileNumber);
    }
}
