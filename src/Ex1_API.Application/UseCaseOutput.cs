using System.Net;

namespace Ex1_API.Application
{
    public class UseCaseOutput
    {
        public List<string> Errors { get; set; }
        public object Data { get; set; }
        public HttpStatusCode Code { get; set; }
        public bool HasErrors => this.Errors.Any();

        public UseCaseOutput()
        {
            Errors = new List<string>();
        }

        public UseCaseOutput(List<string> errors)
        {
            Errors = errors;
            Code = HttpStatusCode.BadRequest;
        }
        public UseCaseOutput(object data)
        {
            Data = data;
            Code = HttpStatusCode.OK;
            Errors = new List<string>();
        }
    }
}