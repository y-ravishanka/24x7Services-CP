using Services1.Shared;

namespace Services1.Client.Services
{
    internal interface IReportService
    {
        Task<Reports> GetReportById(int id);
        Task<List<Reports>> GetReportsByMark(int id, int value);
        Task<bool> SetReport(Reports report);
        Task<bool> UpdateReport(int id, int value);
    }
}
