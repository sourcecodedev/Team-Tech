using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using System;
using System.Threading.Tasks;

namespace TeamTech.Common.StorageQueque
{
    public class QueueManager
    {
        private CloudQueueClient _queueClient = null;
        public string Error { get; set; }

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="storageConnectionString">Cadena de conexión de la cuenta de almacenamiento de azure</param>
        public QueueManager(string storageConnectionString)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(storageConnectionString);
            _queueClient = storageAccount.CreateCloudQueueClient();

        }


        /// <summary>
        /// Manda una cola a azure 
        /// </summary>
        /// <param name="msg">Mensaje de la cola</param>
        /// <param name="queueName">Nombre de la cola</param>
        /// <returns>Estado de la operación</returns>
        public bool SendQueue(string msg, string queueName)
        {
            try
            {
                CloudQueue queue = _queueClient.GetQueueReference(queueName.ToLower());
                queue.CreateIfNotExistsAsync();
                CloudQueueMessage message = new CloudQueueMessage(msg);
                queue.AddMessageAsync(message);
                return true;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Obtiene la cola de azure en función del nombre
        /// </summary>
        /// <param name="queueName">Nombre de la cola que deseas obtener el mensaje</param>
        /// <returns>Mensaje de la cola</returns>
        public async Task<string> GetQueue(string queueName)
        {
            try
            {
                CloudQueue queue = _queueClient.GetQueueReference(queueName.ToLower());
                CloudQueueMessage retrievedMessage = await queue.GetMessageAsync();
                await queue.DeleteMessageAsync(retrievedMessage);
                return retrievedMessage.AsString;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return string.Empty;

            }
        }

    }

}
