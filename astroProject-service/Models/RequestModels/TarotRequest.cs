using astroProject_service.Entities;

namespace astroProject_service.Models.RequestModels
{
    public class TarotRequest
    {
        public string? Question { get; set; }
        public string? SpreadType { get; set; }
        public string? DeckStyle { get; set; }
        public string? InterpretationLevel { get; set; }
        public bool? IncludeReversedCards { get; set; }
        public string? TimeFrame { get; set; }
        public List<SelectedTarotCard> SelectedTarotCards { get; set; }
        public TarotRequest()
        {
            SpreadType = SpreadType ?? "3-Card Spread";
            DeckStyle = DeckStyle ?? "Rider-Waite";
            InterpretationLevel = InterpretationLevel ?? "Intermediate";
            IncludeReversedCards = IncludeReversedCards ?? false;
            TimeFrame = TimeFrame ?? "No time frame specified";
            SelectedTarotCards = SelectedTarotCards ?? new List<SelectedTarotCard>();
        }

        public class SelectedTarotCard
        {
            public string Name { get; set; }
            public bool? IsReversed { get; set; }

            public SelectedTarotCard()
            {
                IsReversed = IsReversed ?? false;
            }
        }
    }

}

