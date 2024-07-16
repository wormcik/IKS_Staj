using System;
namespace Yetki.Helpers
{
	public class ProcessResult<T>
	{
        public bool Success { get; set; }

        public string Message { get; set; }

        public T? Model { get; set; }

        public ProcessResult<T> Successful(T? data = default(T?), string message = "Process Successful.")
        {
            return new ProcessResult<T>
            {
                Success = true,
                Model = data,
                Message = message
            };
        }

        public ProcessResult<T> Failed(string message)
        {
            return new ProcessResult<T>
            {
                Success = false,
                Message = message
            };
        }
    }
}

