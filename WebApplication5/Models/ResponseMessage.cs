namespace WebApplication5.Models
{
    public class ResponseMessage
    {
        public string MessageType { get; set; }
        public dynamic Data { get; set; }
        public string Message { get; set; }

        public ResponseMessage setResponseMessage(string messaType , dynamic data , string message)
        {
            return new ResponseMessage { MessageType = messaType, Data = data, Message = message };
        }
    }
}
