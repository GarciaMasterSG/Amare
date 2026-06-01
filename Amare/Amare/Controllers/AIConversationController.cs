using Microsoft.AspNetCore.Mvc;

namespace Amare.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AIConversationController : ControllerBase
    {
        [HttpGet("{input}")]
        public async Task GetUserMessage(string input)
        {
            Response.Headers.Append("Content-Type", "Text/event-stream");

            using var httpClient = new HttpClient();

            httpClient.Timeout = TimeSpan.FromMinutes(5);

            var request = new HttpRequestMessage(
            HttpMethod.Post,
            $"http://127.0.0.1:8000/plan_wedding?input={input}"
            );

            var pythonResponse = await httpClient.SendAsync(
                request,
                HttpCompletionOption.ResponseHeadersRead
            );

            var stream = await pythonResponse.Content.ReadAsStreamAsync();

            using var reader = new StreamReader(stream);

            while (!reader.EndOfStream)
            {
                var line = await reader.ReadLineAsync();

                if (line != null)
                {
                    await Response.WriteAsync(line + "\n");
                    await Response.Body.FlushAsync();
                }
            }


        }
    }
}
