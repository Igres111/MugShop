using MugShop.Common;
using MugShop.Common.MugResponses;
using MugShop.DTOs.MugDTOs;


namespace MugShop.Service.Interfaces.MugInterfaces
{
    public interface IMug
    {
        public Task<APIResponse> CreateMug(CreateMugDto mugInfo);
        public Task<GetAllMugsResponse> GetAllMugs();
    }
}
