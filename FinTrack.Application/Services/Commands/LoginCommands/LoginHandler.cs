using FinTrack.Core.Auth;
using FinTrack.Core.UnitOfWork;
using MediatR;

namespace FinTrack.Application.Services.Commands.LoginCommands
{
    public class LoginHandler : IRequestHandler<LoginCommand, string>
    {
        private readonly IUoF _uof;
        private readonly IAuthService authService;

        public LoginHandler(IAuthService authService, IUoF uof)
        {
            this.authService = authService;
            _uof = uof;
        }

        public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            //Encrypta a senha 
            request.Password = authService.ComputeHash(request.Password);

            // Busca o usuário pelo e-mail (Username)
            var user = await _uof.UserRepository.Get(u=>u.Email==request.Username);
            
            if (user == null)
            {
                return "Usuario ou senha incorretos";
            }

            // Aqui você pode validar a senha, gerar token, etc.
            // Exemplo de validação simples (NÃO recomendado para produção):
            if (user.Password == request.Password)
            {
                var token = authService.GenerateToken(user.Email, user.Id, user.Role);
                return $"Login realizado com sucesso. Token:{token}";
            }

            return "Usuario ou senha incorretos";
        }
    }
}
