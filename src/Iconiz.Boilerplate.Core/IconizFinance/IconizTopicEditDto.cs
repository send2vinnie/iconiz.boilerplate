using System;
using  System.Collections.Generic;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities.Auditing;

namespace Iconiz.Boilerplate.IconizFinance
{
    public class IconizTopicEditDto : EntityDto, IHasCreationTime
    {
         public long? UserId { get; set; }
        
        public DateTime CreationTime { get; set; }
        
        public int SourceId{ get; set; }
        
        public string Source{ get; set; }
        
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
        
        public int ReadCount { get; set; }
        
        public float Raty { get; set; } = 5;
        
        public TopicStatusEnum TopicStatus { get; set; } = TopicStatusEnum.草稿;

        public TopicCommentAllowEnum TopicCommentStatus { get; set; } = TopicCommentAllowEnum.仅注册;
    }
}