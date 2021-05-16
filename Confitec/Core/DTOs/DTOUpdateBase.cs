namespace Confitec.Core.DTOs
{
    public class UpdateRequestBase<TType> where TType : class
    {
        public string[] Props { get; set; }
        public TType Dados { get; set; }
    }
}
