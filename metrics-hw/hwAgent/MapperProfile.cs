using AutoMapper;
using hwAgent.Models;
using hwAgent.Requests;
using hwAgent.Responses;

namespace hwAgent
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CpuMetric, CpuMetricDto>();
            CreateMap<DotNetMetric, DotNetMetricDto>();
            CreateMap<HddMetric, HddMetricDto>();
            CreateMap<NetworkMetric, NetworkMetricDto>();
            CreateMap<RamMetric, RamMetricDto>();
            CreateMap<CpuMetricCreateRequest, CpuMetric>();
            CreateMap<DotNetMetricCreateRequest, DotNetMetric>();
            CreateMap<HddMetricCreateRequest, HddMetric>();
            CreateMap<NetworkMetricCreateRequest, NetworkMetric>();
            CreateMap<RamMetricCreateRequest, RamMetric>();
        }
    }
}
