namespace WebApiSistemaGestion.CustomExceptions
{
    public class CustomHttpException : Exception
    {

        //Esto son excepciones personalizadas que puedo utilizar ademas de mandar la clasica exception
        public int HttpStatusCode { get; }

        public CustomHttpException(string message, int httpStatusCode) : base(message) //http status code es el codigo que podemos pasarle 400, 404, 500, etc.
        {
            HttpStatusCode = httpStatusCode;
        }
    }

}
