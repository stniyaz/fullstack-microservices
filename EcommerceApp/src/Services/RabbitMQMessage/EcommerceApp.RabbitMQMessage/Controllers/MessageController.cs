using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace EcommerceApp.RabbitMQMessage.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MessageController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateMessage(string message)
    {
        var factory = new ConnectionFactory() { HostName = "localhost" };

        using var connection = await factory.CreateConnectionAsync();
        using var channel = await connection.CreateChannelAsync();

        await channel.QueueDeclareAsync("Queue2", false, false, false, arguments: null);

        var messageContent = message;

        var byteMessageContent = Encoding.UTF8.GetBytes(messageContent);

        var basicProperties = new BasicProperties();

        await channel.BasicPublishAsync(
            exchange: "",
            routingKey: "Queue2",
            mandatory: false,
            basicProperties: basicProperties,
            body: byteMessageContent);


        return Ok("Your message added to queue.");
    }

    [HttpGet("read message")]
    public async Task<IActionResult> ReadMessage()
    {
        var factory = new ConnectionFactory() { HostName = "localhost" };

        using var connection = await factory.CreateConnectionAsync();
        using var channel = await connection.CreateChannelAsync();

        var result = await channel.BasicGetAsync("Queue2", autoAck: true);

        if (result == null)
        {
            return Ok("No messages in queue.");
        }

        var message = Encoding.UTF8.GetString(result.Body.ToArray());

        return Ok(message);
    }
}
