using WordWiz.Domain.Entities.Common;

namespace WordWiz.Domain.Entities;

public class Category
{
    public long Id { get; set; }
    public string Name { get; set; } = null!;
    public ICollection<Question> Questions { get; set; } = new List<Question>();
} 