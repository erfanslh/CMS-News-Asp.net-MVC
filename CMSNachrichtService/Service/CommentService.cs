using CMSNachrichtModel.Context;
using CMSNachrichtModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSNachrichtService.Service
{
    public class CommentService : GenericService<Comment>, ICommentService
    {
        public CommentService(DbNachrichtContext context) : base(context)
        {
        }
    }
}
