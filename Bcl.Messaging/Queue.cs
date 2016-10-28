using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bcl.Messaging
{
    public class Queue
    {

        private readonly Queue<string> _q;

        public Queue()
        {
            _q = new Queue<string>();
        }

        public void Enqueue(MessageBase message)
        {
            var serialisedMessage = JsonConvert.SerializeObject(message);
            _q.Enqueue(serialisedMessage);
        }

        public MessageBase Dequeue()
        {
            var serialisedMessage = _q.Dequeue();
            var messageObject = (JObject)JsonConvert.DeserializeObject(serialisedMessage);

            var typeName = messageObject["TypeName"].ToString();

            // by on using the short name of the type we can serialise and deserialise
            // from and to different types as long as members match
            // we just find the first type in the current appdomain with the same name
            var type =
                AppDomain.CurrentDomain.GetAssemblies() // get all load assemblies
                .Select(a => a.GetTypes() // get all types
                .FirstOrDefault(t => t.Name == typeName)) // get matching names
                .FirstOrDefault(t => t != null); // get first where one exists

            var message = (MessageBase)messageObject.ToObject(type);
            return message;
        }

    }
}
