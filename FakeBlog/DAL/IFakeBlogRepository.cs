using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeBlog.DAL
{
    public interface IFakeBlogRepository
    {
        // Users who signup are considered "Authors"
        // Published posts will be viewable by everyone
        // Authors will be able to make drafts for blog posts
        // Authors will be able to manually publish a draft.
        // Authors will be able to delete published posts and drafts
        // Authors will be able to edit a drafts
    }
}
