using System;

namespace Iconiz.Boilerplate.IconizFinance.Dto
{
    public class IconizTopicCommentDto
    {
        public int Id { get; set; }
        
        public string AuthorName { get; set; }

        public string AuthorIP { get; set; }
     
        public DateTime CreationTime { get; set; }

        public string Content { get; set; }

        public int Raty { get; set; }

        public int Parent { get; set; }     
    }
}