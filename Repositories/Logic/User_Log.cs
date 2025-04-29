using arq_micro_tiempo.Repositories.DTO;
using arq_micro_tiempo.Repositories.Interfaces;
using arq_micro_pru_tiempo.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Azure.Core;

namespace arq_micro_pru_tiempo.Repositories.Logic
{
    public class User_Log : IUser
    {
        private readonly IMapper _mapper;
        private readonly UserContext _context;

        public User_Log(IMapper mapper, UserContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        /**
         * Metodo que permite crear un Estudiante
         */
        public async Task<User_DTO> CreateUser(User_DTO request)
        {
            /*
             * Este codigo se ejecutaria para saber si el estudiante existe se asume que no existe 
             */
            string accion = "C";
            User user = await _context.Users.Where(x => 
                x.NumberDocument == request.NumberDocument &&
                x.Active == true
             ).FirstOrDefaultAsync();

            accion = user != null ? "U" : accion;
            user = user == null ? new User() : user;

            user.UserName = request.UserName;
            user.Password = request.Password;
            user.Names = request.Names;
            user.LastName = request.LastName;
            user.NumberDocument = request.NumberDocument;
            user.TipDocumentId = request.TipDocumentId;
            user.DateTuition = request.DateTuition;
            user.TipUserId = request.TipUserId;
            user.Active = request.Active;

            /*
             * Funcionalidad que permite determinar si es un usuario nuevo o uno a editar
             */
            if (accion == "C"){
                _context.Users.Add(user);
            }
            else{
                _context.Users.Update(user);
            }            

            await _context.SaveChangesAsync();
            return _mapper.Map<User_DTO>(user);
        }

        /**
         * Metodo que permite consultar un estudiante por id
         */
        public async Task<User_DTO> SearchUser(int request)
        {
            var student = await _context.Users.Where(x => x.Id == request && x.Active == true).FirstOrDefaultAsync();
            return _mapper.Map<User_DTO>(student);
        }

        /**
         * Metodo que permite obtener el listado de estudiantes creados
         */
        public async Task<List<User_DTO>> ListUsers()
        {
            var students = await _context.Users.Where(x => x.Active == true).ToListAsync();
            return _mapper.Map<List<User_DTO>>(students);
        }

        /**
         * Metodo que permite eliminar un estudiante
         */
        public async Task<bool> DeleteUser(User_DTO request)
        {
            User studentDelete = await _context.Users.Where(u => u.Id == request.Id).FirstOrDefaultAsync();

            if (studentDelete != null)
            {
                studentDelete.Active = false;
                _context.Update(studentDelete);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;

        }

        /**
         * Metodo que permite obtener postulados de una oferta
         */
        public async Task<List<User_DTO>> searchStudentSubject(int IdOffer)
        {
            var students = await _context.OfferXUsers.Where(x => x.IdOffer == IdOffer).ToListAsync();
            return _mapper.Map<List<User_DTO>>(students);
        }
    }
}

