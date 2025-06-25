using MugShop.DTOs.MugDTOs;

namespace MugShop.Common.MugResponses
{
    public class GetAllMugsResponse:APIResponse
    {
        public List<GetAllMugsDto> Mugs { get; set; } = new List<GetAllMugsDto>();
    }
}
