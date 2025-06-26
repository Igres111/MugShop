using MugShop.DTOs.MugDTOs;
using MugShop.ViewModels;

namespace MugShop.Common.MugResponses
{
    public class GetAllMugsResponse:APIResponse
    {
        public MugPageViewModel ViewModel { get; set; } = new MugPageViewModel();

    }
}
