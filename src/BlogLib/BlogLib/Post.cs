using System;
using System.Collections.Generic;
using System.Text;

namespace StraussDA.BlogLib
{
    public class Post
    {
        public int Id { get; set; }
        public string PostName { get; set; }
        public DateTime PostDate { get; set; }
        public DateTime ModifyDate  { get; set; }
        public string PostContent { get; set; }
        public string PostTags { get; set; }
      }
}
