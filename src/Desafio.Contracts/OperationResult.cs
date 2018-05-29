namespace Desafio.Contracts
{
    public class OperationResult<T>
    {
        public OperationResult(bool success, string message, T result)
        {
            Success = success;
            Message = message;
            Result = result;
        }
        public bool Success { get; set; }
        public T Result { get; set; }
        public string Message { get; set; }
    }
    
    public class OperationResult
    {
        public OperationResult(bool success, string message)
        {
            Success = success;
            Message = message;
        }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
