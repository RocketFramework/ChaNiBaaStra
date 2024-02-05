
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;

namespace ChaNiBaaStra.Utilities
{
   /* public class ChatGTPWrapper
    {
        public const string API_KEY = "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";
        public async void CallChatGTPToSummarize()
        {
            var openAiApi = new OpenAIAPI(API_KEY);
            string response;
            try
            {
                var completions = await openAiApi.Completions.CreateCompletionAsync(
                    prompt: "Summarize this for a second-grade student:\n\nJupiter is the fifth planet from the Sun and the largest in the Solar System. It is a gas giant with a mass one-thousandth that of the Sun, but two-and-a-half times that of all the other planets in the Solar System combined. Jupiter is one of the brightest objects visible to the naked eye in the night sky, and has been known to ancient civilizations since before recorded history. It is named after the Roman god Jupiter.[19] When viewed from Earth, Jupiter can be bright enough for its reflected light to cast visible shadows,[20] and is on average the third-brightest natural object in the night sky after the Moon and Venus.",
                    model: "text-davinci-003",
                    max_tokens: 64,
                    temperature: 0.7,
                    top_p: null,
                    numOutputs: 10,
                    presencePenalty: 0.0,
                    frequencyPenalty: 0.0,
                    logProbs: 10,
                    echo: null,
                    stopSequences: new[] { "\n" });

                Console.WriteLine(completions.Completions[0].Text);
            }
            catch (Exception ex){
                response = ex.Message;
            }
        }
    }*/
}
