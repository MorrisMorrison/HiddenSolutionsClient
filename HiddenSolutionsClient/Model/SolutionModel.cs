using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.ComponentModel.DataAnnotations;

namespace HiddenSolutionsClient.Model
{
    public class SolutionModel
    {
        public string Id { get; set; }
        [Required] public string Title { get; set; }
        [Required] public string ProblemDescription { get; set; }
        [Required] public string SolutionDescription { get; set; }
        [Required] public Category Category { get; set; } = new Category();
        [Required] public IList<Tag> Tags { get; set; } = new List<Tag>();
        public IList<Image> Images { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        [Required]
        public string Link { get; set; }
        public DateTime LinkLastVisited { get; set; } = DateTime.Today.Date;
    }

    public class Image
    {
        public Path Path { get; set; }
    }

    public class Category
    {
        public string Name { get; set; }
    }
    
    public class Tag
    {
        public string Value { get; set; }
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