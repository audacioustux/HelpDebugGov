namespace Api.Services;

using Api.Db;
using EntityFramework.Exceptions.Common;

public interface IUserService : IGenericService<User>
{
    Task<Guid> Register(UserRegisterDTO userRegisterDTO);
}

public class UserService : GenericService<User>, IUserService
{
    public UserService(ApplicationContext _context) : base(_context) { }

    public async Task<Guid> Register(UserRegisterDTO userRegisterDTO)
    {
        var user = new User
        {
            Name = userRegisterDTO.Name,
            Email = userRegisterDTO.Email.ToLower(),
            Password = BCrypt.Net.BCrypt.HashPassword(userRegisterDTO.Password)
        };

        Add(user);

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (UniqueConstraintException ex)
        {
            response.Success = false;
            response.Message = ex.Message;
            return response;
        }

        response.Data = user.Id;
        return response;
    }
}