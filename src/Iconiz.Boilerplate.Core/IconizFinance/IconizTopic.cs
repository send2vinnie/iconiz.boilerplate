using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp;
using Abp.Authorization.Users;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;
using System.Collections.Generic;

namespace Iconiz.Boilerplate.IconizFinance
{
    public class IconizTopic : Entity, IHasCreationTime
    {
        public long? UserId { get; set; }
        
        public DateTime CreationTime { get; set; }
        
        [ForeignKey("TopicId")]
        public virtual List<IconizTopicComment> IconizTopicComments { get; set; }
        
        [Display(Name = "API来源Id")]
        public int SourceId{ get; set; }
        
        [Display(Name = "API来源")]
        [StringLength(50)]
        public string Source{ get; set; }
        
        [Display(Name = "连接")]
        [StringLength(200)]
        public string Url { get; set; }
        
        [Display(Name = "标题")]
        [StringLength(200)]
        public string Title { get; set; }
        
        [Display(Name = "摘要")]
        [StringLength(200)]
        public string Summary { get; set; }
        
        [Display(Name = "关键词,英文逗号分隔")]
        [StringLength(200)]
        public string KeyWords{ get; set; }
        
        [Display(Name = "内文")]
        public string Content { get; set; }
        
        [Display(Name = "发表时间")]
        public DateTime PublishTime { get; set; }
        
        [Display(Name = "分类")]
        [StringLength(16)]
        public string Category { get; set; }

        [Display(Name = "二级分类")]
        [StringLength(16)]
        public string Category2 { get; set; }
        
        [Display(Name = "来源")]
        [StringLength(50)]
        public string Resource { get; set; }
        
        [Display(Name = "来源URL")]
        [StringLength(200)]
        public string ResourceUrl { get; set; }
        
        [Display(Name = "作者")]
        [StringLength(50)]
        public string Author { get; set; }
        
        [Display(Name = "缩略图")]
        [StringLength(200)]
        public string Thumbnail { get; set; }
      
        [Display(Name = "赞")]
        public int UpCount { get; set; }
        
        [Display(Name = "踩")]
        public int DownCount { get; set; }
        
        [Display(Name = "评论数")]
        public int CommitCount { get; set; }
        
        [Display(Name = "阅读数")]
        public int ReadCount { get; set; }
        
        [Display(Name = "平均分")]
        public float Raty { get; set; } = 5;
        
        [Display(Name = "文章状态")]
        public TopicStatusEnum TopicStatus { get; set; } = TopicStatusEnum.草稿;

        [Display(Name = "评论设置")]
        public TopicCommentAllowEnum TopicCommentStatus { get; set; } = TopicCommentAllowEnum.仅注册;
    }
    
    public enum TopicStatusEnum
    {
        草稿,
        待审批,
        拒绝,
        正常,
        置顶
    }
    
    public enum TopicCommentAllowEnum
    {
        开启,
        关闭,
        仅注册
    }
}