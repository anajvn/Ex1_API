using Ex1_API.Application.Interfaces;
using Ex1_API.Application.UseCases;

namespace Ex1_API.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            /* Crie uma API Web, utilizando conceitos de Clean Architecture, na qual contenha:

            Criação de 5 Actions

                Criar: POST
                Editar: PUT
                Remover: DELETE
                Listar todos: GET parâmetros: nome, cidade
                Listar por Id: GET /{id}

            Regras:

                Nome e Cidade do aluno não podem ser vazios
            
                Id deve ser preenchido e não deve se repetir. */

            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<ICadastrarAlunoUseCase, CadastrarAlunoUseCase>();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            /* Criar um Middleware para controle de perfil. Somente usuários com o perfil "Ada" devem poder acessar os métodos.
            O perfil deve vir via HEADER chamado “Profile” */

            /*app.Use(async (context, next) =>
            {
                var profile = context.Request.Headers["Profile"];

                if (profile != "Ada")
                {
                    context.Response.StatusCode = 403;
                    context.Response.ContentType = "application/json";
                    var responseJson = new
                    {
                        Error = "Somente usuários com o perfil Ada podem acessar esse método."
                    };
                    await context.Response.WriteAsJsonAsync(responseJson);
                } else
                    await next.Invoke();
            });*/

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}