using System;
using Framework.Messages;

namespace CrossCuttingLayer
{
    public class Todo: IMessage
    {
        public string Id { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.UtcNow;
        public string TaskDescription { get; set; }
        public bool IsCompleted { get; set; }
        public Guid MessageId { get; }
        public DateTime PublishDateTime { get; }
    }  
    public class Todo11: IMessage
    {
        public string Id { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.UtcNow;
        public string TaskDescription { get; set; }
        public bool IsCompleted { get; set; }
        public Guid MessageId { get; }
        public DateTime PublishDateTime { get; }
    }

}
