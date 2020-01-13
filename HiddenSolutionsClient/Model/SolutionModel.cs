using System;
using System.Collections.Generic;
using System.Net.Mime;

namespace HiddenSolutionsClient.Model
{
    public class SolutionModel
    {
        public string Title { get; set; }
        public string ProblemDescription { get; set; }
        public string SolutionDescription { get; set; }
        public Category Category { get; set; } = new Category();
        public IList<Tag> Tags { get; set; } = new List<Tag>();
        public IList<Image> Images { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public string Link { get; set; }
        public DateTime LinkLastVisited { get; set; } = DateTime.Today.Date;
    }

    public class Category
    {
        public string Name { get; set; }
    }

    public class Tag
    {
        public string Value { get; set; }
    }

    public class Image
    {
            public Path Path { get; set; }
    }
    
    public class Path
    {
        public string Value { get; set; }

        public Path(string p_value)
        {
            Value = p_value;
        }

        public override string ToString()
        {
            return Value;
        }
    }
}