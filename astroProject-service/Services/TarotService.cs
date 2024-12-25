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

        #region Initial Tarot Card Creation
        public async Task<bool> CreateTarotCardsAsync()
        {
            try
            {
                var tarotCardsDb = await appDbContext.TarotCard.ToListAsync();
                if (tarotCardsDb.Count == 78)
                {
                    return true;
                }
                var tarotCards = new List<TarotCard>
                {
                    new TarotCard { Name = "The Fool", Type = "Major Arcana" },
                    new TarotCard { Name = "The Magician", Type = "Major Arcana" },
                    new TarotCard { Name = "The High Priestess", Type = "Major Arcana" },
                    new TarotCard { Name = "The Empress" ,  Type = "Major Arcana" },
                    new TarotCard { Name = "The Emperor" , Type = "Major Arcana"},
                    new TarotCard { Name = "The Hierophant" , Type = "Major Arcana"},
                    new TarotCard { Name = "The Lovers" , Type = "Major Arcana"},
                    new TarotCard { Name = "The Chariot" , Type = "Major Arcana"},
                    new TarotCard { Name = "Strength" , Type = "Major Arcana"},
                    new TarotCard { Name = "The Hermit" , Type = "Major Arcana"}  ,
                    new TarotCard { Name = "Wheel of Fortune" , Type = "Major Arcana"},
                    new TarotCard { Name = "Justice" , Type = "Major Arcana"},
                    new TarotCard { Name = "The Hanged Man" , Type = "Major Arcana"},
                    new TarotCard { Name = "Death" , Type = "Major Arcana"},
                    new TarotCard { Name = "Temperance" , Type = "Major Arcana"},
                    new TarotCard { Name = "The Devil" , Type = "Major Arcana"},
                    new TarotCard { Name = "The Tower" , Type = "Major Arcana"},
                    new TarotCard { Name = "The Star" , Type = "Major Arcana"},
                    new TarotCard { Name = "The Moon" , Type = "Major Arcana"},
                    new TarotCard { Name = "The Sun" , Type = "Major Arcana"},
                    new TarotCard { Name = "Judgement" , Type = "Major Arcana"},
                    new TarotCard { Name = "The World" , Type = "Major Arcana"},
                    // Minor Arcana
                    new TarotCard { Name = "Ace of Wands" , Type = "Minor Arcana"},
                    new TarotCard { Name = "Two of Wands", Type = "Minor Arcana" },
                    new TarotCard { Name = "Three of Wands" , Type = "Minor Arcana"},
                    new TarotCard { Name = "Four of Wands" , Type = "Minor Arcana"},
                    new TarotCard { Name = "Five of Wands" , Type = "Minor Arcana"},
                    new TarotCard { Name = "Six of Wands" , Type = "Minor Arcana"},
                    new TarotCard { Name = "Seven of Wands", Type = "Minor Arcana"},
                    new TarotCard { Name = "Eight of Wands", Type = "Minor Arcana"},
                    new TarotCard { Name = "Nine of Wands", Type = "Minor Arcana"},
                    new TarotCard { Name = "Ten of Wands", Type = "Minor Arcana"},
                    new TarotCard { Name = "Page of Wands" ,Type = "Minor Arcana"},
                    new TarotCard { Name = "Knight of Wands" ,Type = "Minor Arcana"},
                    new TarotCard { Name = "Queen of Wands" ,Type = "Minor Arcana"},
                    new TarotCard { Name = "King of Wands" ,Type = "Minor Arcana"},
                    new TarotCard { Name = "Ace of Cups" ,Type = "Minor Arcana"},
                    new TarotCard { Name = "Two of Cups" ,Type = "Minor Arcana"},
                    new TarotCard { Name = "Three of Cups" ,Type = "Minor Arcana"},
                    new TarotCard { Name = "Four of Cups" ,Type = "Minor Arcana"},
                    new TarotCard { Name = "Five of Cups" ,Type = "Minor Arcana"},
                    new TarotCard { Name = "Six of Cups" ,Type = "Minor Arcana"},
                    new TarotCard { Name = "Seven of Cups" ,Type = "Minor Arcana"},
                    new TarotCard { Name = "Eight of Cups" ,Type = "Minor Arcana"},
                    new TarotCard { Name = "Nine of Cups" ,Type = "Minor Arcana"},
                    new TarotCard { Name = "Ten of Cups" ,Type = "Minor Arcana"},
                    new TarotCard { Name = "Page of Cups" ,Type = "Minor Arcana"},
                    new TarotCard { Name = "Knight of Cups" ,Type = "Minor Arcana"},
                    new TarotCard { Name = "Queen of Cups" ,Type = "Minor Arcana"},
                    new TarotCard { Name = "King of Cups" ,Type = "Minor Arcana"},
                    new TarotCard { Name = "Ace of Swords" ,Type = "Minor Arcana"},
                    new TarotCard { Name = "Two of Swords" ,Type = "Minor Arcana"},
                    new TarotCard { Name = "Three of Swords" ,Type = "Minor Arcana"},
                    new TarotCard { Name = "Four of Swords" ,Type = "Minor Arcana"},
                    new TarotCard { Name = "Five of Swords" ,Type = "Minor Arcana"},
                    new TarotCard { Name = "Six of Swords" ,Type = "Minor Arcana"},
                    new TarotCard { Name = "Seven of Swords" ,Type = "Minor Arcana"},
                    new TarotCard { Name = "Eight of Swords" ,Type = "Minor Arcana"},
                    new TarotCard { Name = "Nine of Swords" ,Type = "Minor Arcana"},
                    new TarotCard { Name = "Ten of Swords" ,Type = "Minor Arcana"},
                    new TarotCard { Name = "Page of Swords" ,Type = "Minor Arcana"},
                    new TarotCard { Name = "Knight of Swords" ,Type = "Minor Arcana"},
                    new TarotCard { Name = "Queen of Swords" ,Type = "Minor Arcana"},
                    new TarotCard { Name = "King of Swords" ,Type = "Minor Arcana"},
                    new TarotCard { Name = "Ace of Pentacles" ,Type = "Minor Arcana"},
                    new TarotCard { Name = "Two of Pentacles" ,Type = "Minor Arcana"},
                    new TarotCard { Name = "Three of Pentacles" ,Type = "Minor Arcana"},
                    new TarotCard { Name = "Four of Pentacles" ,Type = "Minor Arcana"},
                    new TarotCard { Name = "Five of Pentacles" ,Type = "Minor Arcana"},
                    new TarotCard { Name = "Six of Pentacles" ,Type = "Minor Arcana"},
                    new TarotCard { Name = "Seven of Pentacles" ,Type = "Minor Arcana"},
                    new TarotCard { Name = "Eight of Pentacles" ,Type = "Minor Arcana"},
                    new TarotCard { Name = "Nine of Pentacles" ,Type = "Minor Arcana"},
                    new TarotCard { Name = "Ten of Pentacles" ,Type = "Minor Arcana"},
                    new TarotCard { Name = "Page of Pentacles" ,Type = "Minor Arcana"},
                    new TarotCard { Name = "Knight of Pentacles" ,Type = "Minor Arcana"},
                    new TarotCard { Name = "Queen of Pentacles" ,Type = "Minor Arcana"},
                    new TarotCard { Name = "King of Pentacles",Type = "Minor Arcana"}
                };

                foreach (var item in tarotCards)
                {
                    appDbContext.TarotCard.Add(item);
                }
                appDbContext.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
