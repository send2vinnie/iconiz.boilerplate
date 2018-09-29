using System;

namespace Iconiz.Boilerplate.IconizFinance.Dto
{
    public class GetIconizTopicOutput
    {
        public int Id { get; set; }

        public string Url { get; set; }

        public string Title { get; set; }

        public string Summary { get; set; }

        public string KeyWords { get; set; }

        public DateTime PublishTime { get; set; }

        public string Resource { get; set; }

        public string ResourceUrl { get; set; }

        public string Author { get; set; }

        public string Thumbnail { get; set; }

        public int UpCount { get; set; }

        public int DownCount { get; set; }

        public int CommitCount { get; set; }

        public string ReadCount { get; set; }

        public float Raty { get; set; }
    }
}