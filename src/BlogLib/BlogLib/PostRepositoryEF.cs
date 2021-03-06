﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace StraussDA.BlogLib
{
    public class PostRepositoryEF:IPostRepository
    {
        private readonly BlogDbContext _postContext;

        public void GetRawPostString(int id)
        {
            string rawHtml = GetByID(id).PostContent;
                 }

        public PostRepositoryEF(BlogDbContext dbContext)
        {
            _postContext = dbContext;
        }
        public List<Post> ListAll()
        {
            return _postContext.Post.ToList();
        }

        public List<Post> SortByDate()
        {
            
            return _postContext.Post.OrderByDescending(e => e.ModifyDate).ToList();
        }

        public Post GetByID(int id)
        {
             return _postContext.Post
                .Single(b => b.Id == id);
            
        }

        public Post GetByUrl(string url)
        {
            return _postContext.Post
              .Single(b => b.PostUrl == url);
        }


        public void EditPost(Post editedPost)
        {
            var OrigPost = GetByID(editedPost.Id);
            OrigPost.PostContent = editedPost.PostContent;
            OrigPost.ModifyDate = DateTime.Now;
            OrigPost.PostName = editedPost.PostName;
            OrigPost.PostUrl = editedPost.PostUrl;
            OrigPost.PostTags = editedPost.PostTags;
            OrigPost.PostCategory = editedPost.PostCategory;
            _postContext.SaveChanges();
        }

        public void NewPost(Post NewPost)
        {
            NewPost.PostDate = DateTime.Now;
            NewPost.ModifyDate = DateTime.Now;
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
