using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace StraussDA.BlogLib
{
    public class PostRepositoryEF:IPostRepository
    {
        private readonly BlogDbContext _postContext;

        public PostRepositoryEF(BlogDbContext dbContext)
        {
            _postContext = dbContext;
        }
        public List<Post> ListAll()
        {
            return _postContext.Post.ToList();
        }

        public Post GetByID(int id)
        {
            return _postContext.Post
                .Single(b => b.Id == id);
        }

        public void EditPost(Post editedPost)
        {
            var OrigPost = GetByID(editedPost.Id);
            OrigPost.PostCategory = editedPost.PostCategory;
            OrigPost.PostContent = editedPost.PostContent;
            OrigPost.ModifyDate = editedPost.ModifyDate;
            OrigPost.PostName = editedPost.PostName;
            OrigPost.PostTags = editedPost.PostTags;
            _postContext.SaveChanges();
        }

        public void NewPost(Post NewPost)
        {
            _postContext.Add(NewPost);
            _postContext.SaveChanges();
        }

        public void DeletePost(int id)
        {
            _postContext.Remove(GetByID(id));
            _postContext.SaveChanges();
        }

      
    }
}
