using LeaseMate.Core.Entities;

namespace LeaseMate.Infrastructure.Services;

public class DocumentGeneratorService
{
    public Task<byte[]> GenerateContractAsync(Contract contract)
    {
        // Temporary placeholder.
        // Later, this will load ContractOfLeaseTemplate.docx
        // and replace placeholders like {{LessorName}}, {{LesseeName}}, etc.

        var content = $"""
        CONTRACT OF LEASE

        LESSOR: {contract.LessorName}
        LESSEE: {contract.LesseeName}
        PROPERTY: {contract.PropertyType} {contract.BuildingName} {contract.Tower} {contract.UnitNumber}
        RENT: PHP {contract.MonthlyRentAmount:N2}
        TERM: {contract.StartDate:MMMM dd, yyyy} to {contract.EndDate:MMMM dd, yyyy}
        """;

        var bytes = System.Text.Encoding.UTF8.GetBytes(content);

        return Task.FromResult(bytes);
    }

    public Task<byte[]> GenerateReceiptAsync(Contract contract)
    {
        var content = $"""
        ACKNOWLEDGEMENT RECEIPT

        This is to formally acknowledge that {contract.LessorName}
        received the payment amounting PHP {contract.TotalPaymentReceived:N2}
        on {contract.PaymentDate:MMMM dd, yyyy}
        from {contract.LesseeName}.

        The payment will serve as the advance rental and security deposit.
        """;

        var bytes = System.Text.Encoding.UTF8.GetBytes(content);

        return Task.FromResult(bytes);
    }
}