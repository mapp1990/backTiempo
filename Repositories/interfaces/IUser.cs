using arq_micro_tiempo.Repositories.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace arq_micro_tiempo.Repositories.Interfaces
{
    public interface IUser
    {
        Task<User_DTO> CreateUser(User_DTO request);
        Task<User_DTO> SearchUser(int request);
        Task<List<User_DTO>> ListUsers();
        Task<bool> DeleteUser(User_DTO request);

    }
}
