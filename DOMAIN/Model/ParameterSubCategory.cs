namespace DOMAIN.Model;

public class ParameterSubCategory
{
    public int Id { get; set; }
    public string ParameterSubCategoryName { get; set; }

    // Fk ParameterCategory
    public int ParameterCategoryId { get; set; }
    public ParameterCategory ParameterCategory { get; set; }

    // Navigation Properties
    public ICollection<Parameter> Parameters { get; set; }
}