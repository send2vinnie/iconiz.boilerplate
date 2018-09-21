using System;

namespace Iconiz.Boilerplate.IconizFinance.Dto
{
    [Serializable]
    public class JinseTopicListOutput
    {
        public int id { get; set; }
        public string url { get; set; }
        public string title { get; set; }
        public string summary { get; set; }
        public string content { get; set; }
        public string published_at { get; set; }
        public DateTime published_time { get; set; }
        public string resource { get; set; }
        public string resource_url { get; set; }
        public string author { get; set; }
        public string thumbnail { get; set; }
    }
}