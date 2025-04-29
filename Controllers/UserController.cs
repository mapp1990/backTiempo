using Microsoft.AspNetCore.Mvc;
using arq_micro_tiempo.Repositories.Interfaces;
using arq_micro_tiempo.Repositories.DTO;
using Azure.Core;
using Microsoft.AspNetCore.Authorization;

namespace arq_micro_tiempo.Controllers
{
    [ApiController]
    [Route("api/usuario")]

    /**
    * Servicios HTTP
    */
    public class UsuarioController : ControllerBase
    {
        public readonly IUser _usuario;

        public UsuarioController(IUser usuario)
        {
            _usuario = usuario;
        }

        /**
         * Servicio de creacion y edicion de usuario
         */
        [HttpPost("crear"), Authorize]
        public async Task<ActionResult<User_DTO>> PostCreateUser(User_DTO request)
        {
            User_DTO userOut = await _usuario.CreateUser(request);

            return userOut == null ? NotFound() : userOut;
        }


        /**
         * Servicio de consulta de un usuario
         */
        [HttpGet("consultar/{id}"), Authorize]
        public async Task<ActionResult<User_DTO>> GetSearchUser(int id)
        {
            User_DTO usuarioSalida = await _usuario.SearchUser(id);

            return usuarioSalida == null ? NotFound() : usuarioSalida;
        }

        /**
         * Servicio de consulta de varios usuarios
         */
        [HttpGet("listar"), Authorize]
        public async Task<ActionResult<List<User_DTO>>> GetListUsers()
        {
            List<User_DTO> ListUserOut = await _usuario.ListUsers();

            return ListUserOut.Count() == 0 ? NotFound() : ListUserOut;
        }

        /**
         * Servicio de eliminación de un usuario
         */
        [HttpPut("eliminar"), Authorize]
        public async Task<ActionResult<bool>> PutDeleteUser(User_DTO request)
        {
            bool OutResponse = await _usuario.DeleteUser(request);

            return OutResponse;
        }

    }
}
