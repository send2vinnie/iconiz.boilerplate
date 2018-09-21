using System;
using System.Collections.Generic;

namespace Iconiz.Boilerplate.IconizFinance.Dto
{
    [Serializable]
    public class JinseLiveOutputListLivesImages
    {
        public string url { get; set; }
        public string thumbnail { get; set; }
        public int height { get; set; }
        public int width { get; set; }
    }

    [Serializable]
    public class JinseLiveOutputListLives
    {
        public int id { get; set; }
        public string content { get; set; }
        public string content_prefix { get; set; }
        public string link_name { get; set; }
        public string link { get; set; }
        public int grade { get; set; }
        public string sort { get; set; }
        public string highlight_color { get; set; }
        public List<JinseLiveOutputListLivesImages> images { get; set; }
        public int created_at { get; set; }
        public int up_counts { get; set; }
        public int down_counts { get; set; }
        public string zan_status { get; set; }
        public string readings { get; set; }
        public string extra_type { get; set; }
        public string extra { get; set; }
    }

    [Serializable]
    public class JinseLiveOutputList
    {
        public DateTime date { get; set; }
        public List<JinseLiveOutputListLives> lives { get; set; }
    }

    [Serializable]
    public class JinseLiveOutput
    {
        public int news { get; set; }
        public int count { get; set; }
        public int total { get; set; }
        public int top_id { get; set; }
        public int bottom_id { get; set; }
        public List<JinseLiveOutputList> list { get; set; }
    }
}