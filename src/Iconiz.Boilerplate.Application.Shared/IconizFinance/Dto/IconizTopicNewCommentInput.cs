using System.ComponentModel.DataAnnotations;

namespace Iconiz.Boilerplate.IconizFinance.Dto
{
    public class IconizTopicNewCommentInput
    {
        public int TopicId { get; set; }

        [MaxLength(500)] public string Content { get; set; }

        public int Raty { get; set; }

        public int Parent { get; set; }
    }
}