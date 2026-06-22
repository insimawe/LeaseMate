namespace LeaseMate.Core.Entities;

public class ContractAttachment
{
    public int Id { get; set; }

    public int ContractId { get; set; }
    public Contract? Contract { get; set; }

    public string FileName { get; set; } = string.Empty;
    public string StoredFileName { get; set; } = string.Empty;
    public string FilePath { get; set; } = string.Empty;
    public string? ContentType { get; set; }

    public string AttachmentType { get; set; } = "Other";

    public DateTime UploadedAt { get; set; } = DateTime.UtcNow;
}