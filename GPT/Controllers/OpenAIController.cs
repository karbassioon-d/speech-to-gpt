using Microsoft.AspNetCore.Mvc;
using OpenAI_API;
using OpenAI_API.Completions;

namespace ChatGPT_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpenAIController : ControllerBase
    {
        [HttpGet]
        [Route("UseChatGPT")]
        public async Task<ActionResult<ChatGptResponse>> UseChatGPT(string query)
        {
            string outputResult = "";
            DotNetEnv.Env.Load();
            string? variableValue = Environment.GetEnvironmentVariable("API_KEY");
            var openai = new OpenAIAPI(variableValue);
            CompletionRequest completionRequest = new CompletionRequest();
            completionRequest.Prompt = query;
            completionRequest.Model = OpenAI_API.Models.Model.DavinciText;
            completionRequest.MaxTokens = 1024;

            var completions = await openai.Completions.CreateCompletionAsync(completionRequest);

            foreach (var completion in completions.Completions)
            {
                outputResult += completion.Text;
            }

            var response = new ChatGptResponse
            {
                OutputResult = outputResult
            };

            return Ok(response);
        }
    }
}