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

        public LoginHandler(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            // Busca o usuário pelo e-mail (Username)
            var user = await mediator.Send(request.Username, cancellationToken);

            if (user == null)
            {
                // Usuário não encontrado
                return null;
            }

            // Aqui você pode validar a senha, gerar token, etc.
            // Exemplo de validação simples (NÃO recomendado para produção):
            if (user.Password != request.Password)
            {
                return null;
            }

            // Retorne um token, mensagem de sucesso, ou o que for necessário
            return "Login realizado com sucesso";
        }
    }
}
