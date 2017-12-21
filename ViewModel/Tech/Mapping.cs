using System.Linq;
using AutoMapper;
using Model.Player;

namespace ViewModel.Tech
{
    public class Mapping
    {
        public static IMapper CreateMapping()
        {
            var config = new MapperConfiguration(cfg =>
            {
            cfg.CreateMap<Player, PetViewModel>().ForMember(dest => dest.Stats, opt => opt.MapFrom(src => src.CheckPet().Select(attr => new AttributeViewModel(attr.Key, attr.Value)).ToList()));
                cfg.CreateMap<Player, InventoryViewModel>().ForMember(dest => dest.Content, opt => opt.
                MapFrom(src => src.Show().GroupBy(i => new { i.Name, i.Value })
                .Select(group => new { Name = group.Key.Name, Value = group.Key.Value, Quantity = group.Count() })));
                cfg.CreateMap<Player, MainViewModel>().ForMember(dest => dest.Pet, opt => opt.MapFrom(src=>Mapper.Map<Player,PetViewModel>(src)))
                .ForMember(dest => dest.Inventory, opt => opt.MapFrom(src => Mapper.Map<Player, InventoryViewModel>(src)));
            });
           
            return config.CreateMapper();
        }
    }
}
