using Ex1_API.Application.Interfaces;
using Ex1_API.Application.UseCases;

namespace Ex1_API
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
            
                Id deve ser preenchido e não deve se repetir

            Entregar a URL do projeto no GitHub. */


            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<ICadastrarPessoaUseCase, CadastrarPessoaUseCase>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            /* Criar um Middleware para controle de perfil

            Somente usuários com o perfil "Ada" devem poder acessar os métodos.

            O perfil deve vir via HEADER chamado “Profile” */

            app.Use(async (context, next) =>
            {
                if (context.Request.Headers["Profile"] != "Ada")
                {
                    context.Response.StatusCode = 500;
                    context.Response.ContentType = "application/json";
                    var responseJson = new
                    {
                        Error = "Somente usuários com o perfil Ada podem acessar os métodos."
                    };
                    await context.Response.WriteAsJsonAsync(responseJson);
                } else
                    await next.Invoke();
            });

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}