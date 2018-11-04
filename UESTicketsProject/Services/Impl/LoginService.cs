using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UESTicketsProject.Data.Entities;
using UESTicketsProject.Data.Repositories.Interfaces;
using UESTicketsProject.Helpers;
using UESTicketsProject.Models;
using UESTicketsProject.Services.Interfaces;

namespace UESTicketsProject.Services.Impl
{
    public class LoginService:ILoginService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public LoginService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public bool Login(LoginModel model, out Usuario usuario)
        {
            var details = _usuarioRepository.GetByUserName(model.UserName);
            usuario = details;
            return (details != null && (String.Equals(details.Password, model.Password.ToBase64(), StringComparison.CurrentCultureIgnoreCase)));
        }
    }
}