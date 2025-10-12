using FinTrack.Application.Services.Queries.UsersQueries.GetByIdUsersQuery;
using FinTrack.Infrastructure.Auth;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTrack.Application.Services.Commands.LoginCommands
{
    public class LoginHandler : IRequestHandler<LoginCommand, string>
    {
        private readonly IMediator mediator;
        private readonly AuthService authService;

        public LoginHandler(IMediator mediator, AuthService authService)
        {
            this.mediator = mediator;
            this.authService = authService;
        }

        public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            //Encrypta a senha 
            request.Password = authService.ComputeHash(request.Password);

            // Busca o usuário pelo e-mail (Username)
            GetByEmailUserQuery getByEmail = new(request.Username);
            var user = await mediator.Send(getByEmail);
            
            if (user == null)
            {
                return null;
            }

            // Aqui você pode validar a senha, gerar token, etc.
            // Exemplo de validação simples (NÃO recomendado para produção):
            if (user.Data.Password == request.Password)
            {
                var token = authService.GenerateToken(user.Data.Email, user.Data.Id, user.Data.Role);
                return "Login realizado com sucesso";
            }

                return null;
            // Retorne um token, mensagem de sucesso, ou o que for necessário
        }
    }
}
