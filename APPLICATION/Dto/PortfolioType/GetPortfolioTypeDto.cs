using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.PortfolioType;
public class GetPortfolioTypeDto
{
    public int Id { get; set; }
    public string Type { get; set; }
    public string TypeGroup { get; set; }
}
