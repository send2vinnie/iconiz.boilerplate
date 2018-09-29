using System;
using  System.Collections.Generic;

namespace Iconiz.Boilerplate.IconizFinance.Dto
{
    public class IconizTopicOneDto
    {
        public long? UserId { get; set; }
        
        public DateTime CreationTime { get; set; }
        
        public List<IconizTopicCommentDto> IconizTopicComments { get; set; }
        
        public string Url { get; set; }
        
        public string Title { get; set; }
        
        public string Summary { get; set; }
        
        public string KeyWords{ get; set; }
        
        public string Content { get; set; }
        
        public DateTime PublishTime { get; set; }
        
        public string Category { get; set; }

        public string Category2 { get; set; }
        
        public string Resource { get; set; }

        public string ResourceUrl { get; set; }
        
        public string Author { get; set; }
        
        public string Thumbnail { get; set; }
      
        public int UpCount { get; set; }
        
        public int DownCount { get; set; }
        
        public int CommitCount { get; set; }
        
        public string ReadCount { get; set; }
        
        public float Raty { get; set; }

        public int TopicCommentStatus { get; set; } 
    }
}