using ApiEcommerce.Models;
using ApiEcommerce.Models.Dtos;
using Mapster;

namespace ApiEcommerce.Mapping;

public class UserProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<User, UserDto>().TwoWays();
        config.NewConfig<User, CreateUserDto>().TwoWays();
        config.NewConfig<User, UserLoginDto>().TwoWays();
        config.NewConfig<User, UserLoginResponseDto>().TwoWays();
        config.NewConfig<ApplicationUser, UserDataDto>().TwoWays();
        config.NewConfig<ApplicationUser, UserDto>().TwoWays();
    }
}
