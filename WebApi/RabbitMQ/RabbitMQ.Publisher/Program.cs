using RabbitMQ.Client;
using System.Text;

namespace RabbitMQ.Publisher;

internal class Program
{
    static void Main(string[] args)
    {
        var factory = new ConnectionFactory();
        //var uri = new Uri("amqps://labbpnzs:rFJ0aZYgr37OFhlhA41h2YVvIxlagcOC@rat.rmq2.cloudamqp.com/labbpnzs");

        //factory.Uri = uri;
        factory.HostName = "localhost";
        //factory.Port = 5672; //AMQP Portu
       // factory.UserName = "guest";
        //factory.Password = "guest";

        var connection = factory.CreateConnection();
        var channel = connection.CreateModel();

        channel.QueueDeclare(
            queue: "task_queue",
            durable: true,
            exclusive: false,
            autoDelete: false,
            arguments: null);

        string message = args[0] is null ? "Hello World" : args[0];
        
        var body = Encoding.UTF8.GetBytes(message);
        var properties = channel.CreateBasicProperties();
        properties.Persistent = true;

        channel.BasicPublish(
            exchange: string.Empty,
            routingKey: "hello",
            basicProperties: properties,
            body: body
            );


        Console.WriteLine("Kuyruğa mesaj gönderildi");

        //Console.ReadLine();
    }
}
