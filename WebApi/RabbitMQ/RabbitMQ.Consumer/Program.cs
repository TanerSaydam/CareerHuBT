using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace RabbitMQ.Consumer;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Consumer ayağa kalktı");
        var factory = new ConnectionFactory();
        //var uri = new Uri("amqps://labbpnzs:rFJ0aZYgr37OFhlhA41h2YVvIxlagcOC@rat.rmq2.cloudamqp.com/labbpnzs");
        //factory.Uri = uri;
        factory.HostName = "localhost";

        var connection = factory.CreateConnection();
        var channel = connection.CreateModel();

        channel.QueueDeclare(
            queue: "task_queue",
            durable: true,
            exclusive: false,
            autoDelete: false,
            arguments: null);

        channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);

        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += (model, ea) =>
        {
            var body = ea.Body.ToArray();
            string message = Encoding.UTF8.GetString(body);


            Console.WriteLine("Kuyruğu işlemeye başladım");

            Thread.Sleep(10000);

            Console.WriteLine("Kuyruktaki mesaj: " + message);
            channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);

        };

        channel.BasicConsume(
            queue: "hello",
            autoAck: false,
            consumer: consumer);


        Console.ReadLine();
    }
}
