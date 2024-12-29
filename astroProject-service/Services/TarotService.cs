using astroProject_service.Entities;
using astroProject_service.Models;
using astroProject_service.Models.RequestModels;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using static astroProject_service.Models.RequestModels.TarotRequest;

namespace astroProject_service.Services
{
    public class TarotService
    {
        private readonly AppDbContext appDbContext;
        private readonly IConfiguration configuration;
        private readonly TextGeneratorService textGeneratorService;
        public TarotService(
            IConfiguration configuration,
            AppDbContext appDbContext,
            TextGeneratorService textGeneratorService
            )
        {
            this.configuration = configuration;
            this.appDbContext = appDbContext;
            this.textGeneratorService = textGeneratorService;
        }

        public async Task<object> CreateTarotReadingAsync(TarotRequest tarotRequest)
        {
            try
            {
                var prompt = await GetCreateTarotReadingPrompt(tarotRequest);

                string rawResponse = await textGeneratorService.CreateTextFromPromptAsync(new TextGeneratorRequest
                {
                    Prompt = prompt,
                    Model = "openai",
                    Seed = 42
                });
                var jsonResponse = JsonConvert.DeserializeObject<dynamic>(rawResponse);
                return rawResponse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> GetCreateTarotReadingPrompt(TarotRequest tarotRequest)
        {
            var prompt = $"You are a skilled tarot reader, known for your deep insights and intuitive interpretations. Based on the following details, provide a reading that matches the requested level of depth:\n\n";

            if (!string.IsNullOrEmpty(tarotRequest.Question))
            {
                prompt += $"**Question:** {tarotRequest.Question}\n";
            }
            else
            {
                prompt += $"**General Guidance Reading**\n"; 
            }

            prompt += $"**Spread Type:** {tarotRequest.SpreadType}\n" +
                      $"**Deck Style:** {tarotRequest.DeckStyle}\n" +
                      $"**Interpretation Level:** {tarotRequest.InterpretationLevel}\n" +
                      $"**Include Reversed Cards:** {(tarotRequest.IncludeReversedCards == null || tarotRequest.IncludeReversedCards == false ? "No" : "Yes")}\n" +
                      $"**Time Frame:** {tarotRequest.TimeFrame}\n\n" +
                      $"**Selected Tarot Cards:**\n";

            foreach (var card in tarotRequest.SelectedTarotCards)
            {
                prompt += $"- {card.Name}{(card.IsReversed == null || card.IsReversed == false ? " (Reversed)" : "")}\n";
            }

            if (!String.IsNullOrEmpty(tarotRequest.InterpretationLevel) && tarotRequest.InterpretationLevel.Equals("Basic", StringComparison.OrdinalIgnoreCase))
            {
                prompt += "\nPlease offer a simple, straightforward interpretation of the cards, focusing on clear, direct meanings and insights.";
            }
            else if (!String.IsNullOrEmpty(tarotRequest.InterpretationLevel) && tarotRequest.InterpretationLevel.Equals("Intermediate", StringComparison.OrdinalIgnoreCase))
            {
                prompt += "\nProvide a balanced reading with a deeper connection between the cards. Include some context and potential influences that may be at play, but keep the interpretation concise.";
            }
            else if (!String.IsNullOrEmpty(tarotRequest.InterpretationLevel) && tarotRequest.InterpretationLevel.Equals("Advanced", StringComparison.OrdinalIgnoreCase))
            {
                prompt += "\nGive a detailed, comprehensive reading, exploring the intricate relationships between the cards. Delve into subtle themes, spiritual influences, and potential outcomes. Offer profound insights that help guide the querent on their path.";
            }
            else
            {
                prompt += "\nPlease provide a clear and insightful reading based on the provided cards and question, with a focus on the overall message from the spread.";
            }

            return prompt;
        }
    }
}
