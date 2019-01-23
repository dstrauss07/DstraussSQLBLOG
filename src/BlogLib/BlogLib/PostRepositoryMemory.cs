using System;
using System.Collections.Generic;
using System.Text;

namespace StraussDA.BlogLib
{
    public class PostRepositoryMemory:IPostRepository
    {
        public static List<Post> _posts;
        public static int _nextId = 1;
        public void GetRawPostString(int id)
        {
            string rawHtml = GetByID(id).PostContent;
        }
        public PostRepositoryMemory()
        {
            if(_posts == null)
            {
                _posts = new List<Post>();
            }
        }
        public List<Post> ListAll()
        {
            return _posts;
        }

        public Post GetByID(int id)
        {
            GetRawPostString(id);
            return _posts.Find(b => b.Id == id);
        }

        public void EditPost(Post editedPost)
        {
            var OrigPost = GetByID(editedPost.Id);
            OrigPost.PostContent = editedPost.PostContent;
            OrigPost.ModifyDate = editedPost.ModifyDate;
            OrigPost.PostName = editedPost.PostName;
            OrigPost.PostTags = editedPost.PostTags;
        }

        public void NewPost(Post NewPost)
        {
            NewPost.Id = _nextId++;
            _posts.Add(NewPost);
        }

        public void DeletePost(int id)
        {
            _posts.Remove(GetByID(id));
        }

        public List<Post> SortByDate()
        {
            throw new NotImplementedException();
        }
    }
}
