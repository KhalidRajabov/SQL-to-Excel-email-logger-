namespace WebApiLogger.Interfaces
{
    public interface IEmailService
    {
        bool SendEmail(string email, string subject, string message, string file, byte[] bytes);
    }
}