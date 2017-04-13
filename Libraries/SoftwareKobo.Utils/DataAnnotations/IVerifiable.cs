namespace SoftwareKobo.DataAnnotations
{
    public interface IVerifiable
    {
        ValidationResultCollection Errors
        {
            get;
        }

        bool IsValid
        {
            get;
        }
    }
}