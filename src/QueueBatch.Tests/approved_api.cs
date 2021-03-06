[assembly: System.Runtime.CompilerServices.InternalsVisibleToAttribute("QueueBatch.Tests")]
[assembly: System.Runtime.Versioning.TargetFrameworkAttribute(".NETStandard,Version=v2.0", FrameworkDisplayName="")]
namespace QueueBatch
{
    public interface IMessageBatch
    {
        System.Collections.Generic.IEnumerable<QueueBatch.Message> Messages { get; }
        void MarkAllAsProcessed();
        void MarkAsProcessed(QueueBatch.Message message);
    }
    public struct Message
    {
        public readonly string Id;
        public readonly System.Memory<byte> Payload;
        public Message(string id, System.Memory<byte> payload) { }
    }
    public class QueueBatchExtensionConfig : Microsoft.Azure.WebJobs.Host.Config.IExtensionConfigProvider
    {
        public QueueBatchExtensionConfig() { }
        public void Initialize(Microsoft.Azure.WebJobs.Host.Config.ExtensionConfigContext context) { }
    }
    public class static QueueBatchExtensionConfigExtensions
    {
        public static void UseQueueBatch(this Microsoft.Azure.WebJobs.JobHostConfiguration config) { }
    }
    [Microsoft.Azure.WebJobs.Description.BindingAttribute()]
    [System.AttributeUsageAttribute(System.AttributeTargets.Parameter | System.AttributeTargets.All)]
    [System.Diagnostics.DebuggerDisplayAttribute("{QueueName,nq}")]
    public class QueueBatchTriggerAttribute : System.Attribute
    {
        public QueueBatchTriggerAttribute(string queueName) { }
        public int MaxBackOffInSeconds { get; set; }
        public int ParallelGets { get; set; }
        public string QueueName { get; }
    }
}