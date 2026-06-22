namespace LeaseMate.Core.Entities;

public class Contract
{
    public int Id { get; set; }

    public string ContractNumber { get; set; } = string.Empty;

    // Lessor / Owner
    public string LessorName { get; set; } = string.Empty;
    public string? LessorRepresentativeName { get; set; }
    public string? LessorAddress { get; set; }
    public string LessorNationality { get; set; } = "Filipino";
    public string? LessorIdType { get; set; }
    public string? LessorIdNumber { get; set; }

    // Lessee / Renter
    public string LesseeName { get; set; } = string.Empty;
    public string? LesseeAddress { get; set; }
    public string LesseeNationality { get; set; } = "Filipino";
    public string? LesseeIdType { get; set; }
    public string? LesseeIdNumber { get; set; }

    // Property / Unit
    public string PropertyType { get; set; } = "Residential Condominium Unit";
    public string? BuildingName { get; set; }
    public string? Tower { get; set; }
    public string? UnitNumber { get; set; }
    public string? PropertyAddress { get; set; }
    public int? OccupancyLimit { get; set; }

    // Lease Terms
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string? LeaseDurationText { get; set; }

    public decimal MonthlyRentAmount { get; set; }
    public string? MonthlyRentInWords { get; set; }

    public string? PaymentTerms { get; set; }
    public int? PdcCount { get; set; }
    public decimal? LateFeePercentagePerDay { get; set; } = 2;
    public int? DefaultAfterDays { get; set; } = 30;

    // Advance / Deposit
    public int? AdvanceMonths { get; set; } = 1;
    public int? SecurityDepositMonths { get; set; } = 2;
    public decimal? AdvanceAmount { get; set; }
    public decimal? SecurityDepositAmount { get; set; }
    public decimal? TotalPaymentReceived { get; set; }
    public DateTime? PaymentDate { get; set; }

    // Rules
    public string? RulesAndRegulations { get; set; }

    // Status
    public string Status { get; set; } = "Draft";

    // Audit
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }

    public ICollection<ContractAttachment> Attachments { get; set; } = new List<ContractAttachment>();
    public ICollection<GeneratedDocument> GeneratedDocuments { get; set; } = new List<GeneratedDocument>();
}