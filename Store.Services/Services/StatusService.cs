using System;
using System.Globalization;
using System.Reflection;
using System.Runtime.Versioning;
using System.Threading.Tasks;
using Store.Domain.Repositories;
using Store.Services.Contracts.Status;
using Store.Services.Framework;

namespace Store.Services
{
    public interface IStatusService
    {
        Task<StatusGetResponse> GetAsync();
    }

    public class StatusService : Service, IStatusService
    {
        private readonly IStatusRepository _statusRepository;

        public StatusService(IStatusRepository statusRepository)
        {
            _statusRepository = statusRepository;
        }

        public async Task<StatusGetResponse> GetAsync()
        {
            var latestMigration = await _statusRepository.GetLatestMigrationAsync();

            var result = new StatusGetResponse
            {
                ApiVersion = GetType().GetTypeInfo().Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion,
                LatestMigrationDate = DateTime.ParseExact(latestMigration?.Substring(0, 14) ?? DateTime.MinValue.ToString("yyyyMMddHHmmss"), "yyyyMMddHHmmss", CultureInfo.InvariantCulture),
                LatestMigrationNote = latestMigration?.Substring(15)?.Replace('_', ' ') ?? string.Empty,
                TargetFramework = Assembly.GetEntryAssembly()?.GetCustomAttribute<TargetFrameworkAttribute>()?.FrameworkName
            };

            return result;
        }
    }
}
