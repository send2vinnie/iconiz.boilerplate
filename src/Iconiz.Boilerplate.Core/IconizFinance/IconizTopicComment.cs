using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp;
using Abp.Authorization.Users;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;

namespace Iconiz.Boilerplate.IconizFinance
{   
    public class IconizTopicComment: Entity, IHasCreationTime
    {
        public int TopicId { get; set; }

        [ForeignKey("TopicId")]
        public virtual IconizTopic IconizTopic { get; set; }

        [Display(Name = "评论者id")]
        public long? AuthorId { get; set; }

        [Display(Name = "评论者名称")]
        [StringLength(50)]
        public string AuthorName { get; set; }

        [Display(Name = "评论者ip")]
        [StringLength(50)]
        public string AuthorIP { get; set; }

        [Display(Name = "评论发布时间")]
        public DateTime CreationTime { get; set; }

        [Display(Name = "评论正文")]
        public string Content { get; set; }

        [Display(Name = "评分")]
        public int Raty { get; set; }

        [Display(Name = "评论状态")]
        public TopicCommentStatusEnum TopicCommentStatus { get; set; } = TopicCommentStatusEnum.显示;

        [Display(Name = "客户端")]
        [StringLength(128)]
        public string Agent { get; set; }

        [Display(Name = "上级评论")]
        public int Parent { get; set; }     
    }
    
    public enum TopicCommentStatusEnum
    {
        显示,
        隐藏,
        垃圾
    }
}