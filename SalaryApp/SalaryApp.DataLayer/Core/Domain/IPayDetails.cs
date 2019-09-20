namespace SalaryApp.DataLayer.Core.Domain
{
    public interface IPayDetails
    {
        decimal GetGrossAmount();
        decimal GetTaxAmount();
        decimal GetInsuranceAmount();
        decimal GetNetAmount();
    }
}