using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using OpenAI_API;
using OpenAI_API.Chat;
using OpenAI_API.Models;

public class GPT3Interactor
{    
    OpenAIAPI api = new OpenAIAPI("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"); 
    public GPT3Interactor()
    { }

    public async void Chat()
    {
        // for example
        var chat = api.Chat.CreateConversation();
        chat.Model = Model.ChatGPTTurbo;
        chat.RequestParameters.Temperature = 0;

        /// give instruction as System
        chat.AppendSystemMessage("You are a teacher who helps children understand if things are animals or not.  If the user tells you an animal, you say \"yes\".  If the user tells you something that is not an animal, you say \"no\".  You only ever respond with \"yes\" or \"no\".  You do not say anything else.");

        // give a few examples as user and assistant
        chat.AppendUserInput("Is this an animal? Cat");
        chat.AppendExampleChatbotOutput("Yes");
        chat.AppendUserInput("Is this an animal? House");
        chat.AppendExampleChatbotOutput("No");

        // now let's ask it a question
        chat.AppendUserInput("Is this an animal? Dog");
        // and get the response
        string response = await chat.GetResponseFromChatbotAsync();
        Console.WriteLine(response); // "Yes"

        // and continue the conversation by asking another
        chat.AppendUserInput("Is this an animal? Chair");
        // and get another response
        response = await chat.GetResponseFromChatbotAsync();
        Console.WriteLine(response); // "No"

        // the entire chat history is available in chat.Messages
        foreach (ChatMessage msg in chat.Messages)
        {
            Console.WriteLine($"{msg.Role}: {msg.Content}");
        }
    }
}
