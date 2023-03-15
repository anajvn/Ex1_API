using Ex1_API.Application.Interfaces;
using Ex1_API.Application.Interfaces.Repositories;
using Ex1_API.Application.UseCases;
using Ex1_API.Database;
using Ex1_API.Database.Repositories;
using Ex1_API.Presentation.Filters;

namespace Ex1_API.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            /* Crie uma API Web, utilizando conceitos de Clean Architecture.

            Regras:
                Nome e Cidade do aluno n�o podem ser vazios
                Id deve ser preenchido e n�o deve se repetir. */

            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers(options =>
            {
                // Global - para toda a aplica��o
                options.Filters.Add(typeof(ExceptionFilter));
            });
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
               options.OperationFilter<ProfileHeaderFilter>();
            });

            //builder.Services.AddScoped<Connection>();
            builder.Services.AddScoped<IAlunoRepository, AlunoRepository>();
            builder.Services.AddScoped<ICadastrarAlunoUseCase, CadastrarAlunoUseCase>();
            builder.Services.AddScoped<IEditarAlunoUseCase, EditarAlunoUseCase>();
            builder.Services.AddScoped<IBuscarAlunosUseCase, BuscarAlunosUseCase>();
            builder.Services.AddScoped<IDeletarAlunoUseCase, DeletarAlunoUseCase>();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            /* Criar um Middleware para controle de perfil. Somente usu�rios com o perfil "Ada" devem poder acessar os m�todos.
            O perfil deve vir via HEADER chamado �Profile� */

            app.Use(async (context, next) =>
            {
                var profile = context.Request.Headers["Profile"];
                // var method = context.Request.Method; // POST, GET - n�o usa pois todos os m�todos precisam do perfil Ada
                var url = context.Request.Path;

                if (url == "/api/student" && profile == "Ada")
                    await next.Invoke();
                else
                {
                    context.Response.StatusCode = 403;
                    context.Response.ContentType = "application/json";
                    var responseJson = new
                    {
                        Error = "Somente usu�rios com o perfil Ada podem acessar esse m�todo."
                    };
                    await context.Response.WriteAsJsonAsync(responseJson);
                }
            });

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}