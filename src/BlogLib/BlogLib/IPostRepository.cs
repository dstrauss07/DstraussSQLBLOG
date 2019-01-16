using System;
using System.Collections.Generic;
using System.Text;

namespace StraussDA.BlogLib
{
    public interface IPostRepository
    {
        List<Post> ListAll();
        Post GetByID(int id);
        void EditPost(Post editedPost);
        void NewPost(Post NewPost);
        void DeletePost(int id);

    }
}
