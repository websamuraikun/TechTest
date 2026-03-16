namespace TechnicalTest.API.DTOs;

public class ClaimRequestDTO
{
    public required string AssuredName { get; set; }
    public decimal IncurredLoss { get; set; }
    public bool Closed { get; set; }
    public DateTime LossDate { get; set; }
    public DateTime ClaimDate { get; set; }
}
