using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTrainning_1.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public DateTime AddTime { get; set; }
        public bool Confirmation { get; set; }
        public bool HomePage { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}