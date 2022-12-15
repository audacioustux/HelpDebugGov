namespace Api.Services;

using Api.Db;
using EntityFramework.Exceptions.Common;

public interface IUserService : IGenericService<User>
{
    Task<ServiceResponse<Guid>> Register(UserRegisterDTO userRegisterDTO);
}

public class UserService : GenericService<User>, IUserService
{
    public UserService(ApplicationContext _context) : base(_context) { }

    public async Task<ServiceResponse<Guid>> Register(UserRegisterDTO userRegisterDTO)
    {
        var user = new User
        {
            Name = userRegisterDTO.Name,
            Email = userRegisterDTO.Email.ToLower(),
            Password = BCrypt.Net.BCrypt.HashPassword(userRegisterDTO.Password)
        };

        Add(user);

        var response = new ServiceResponse<Guid>();

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (UniqueConstraintException ex)
        {
            response.IsSuccess = false;
            response.Message = ex.Message;
            return response;
        }

        response.Data = user.Id;
        return response;
    }
}