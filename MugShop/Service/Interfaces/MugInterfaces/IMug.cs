using MugShop.Common;
using MugShop.Common.MugResponses;
using MugShop.DTOs.MugDTOs;


namespace MugShop.Service.Interfaces.MugInterfaces
{
    public interface IMug
    {
        public Task<APIResponse> CreateMug(CreateMugDto mugInfo);
        public Task<GetAllMugsResponse> GetAllMugs();
        public Task<APIResponse> UpdateMug(UpdateMugDto mugInfo);
        public Task<APIResponse> DeleteMug(int id);
    }
}
