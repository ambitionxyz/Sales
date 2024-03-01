using ProductService.Domain;

namespace ProductService.Init
{
    internal static class DemoProductFactory
    {
        internal static Product Travel()
        {
            var p = Product.CreateDraft(
                "TRI",
                "Safe Traveller",
                "https://images.pexels.com/photos/19760927/pexels-photo-19760927/free-photo-of-d-ng-v-ng.jpeg?auto=compress&cs=tinysrgb&w=800",
                "Travel insurance",
                10,
                "plane");

            p.AddCover("C2", "Illness", "", false, 5000);
            p.AddCover("C3", "Assistance", "", true, null);

            p.AddQuestions(new List<Question>
            {
            new ChoiceQuestion("DESTINATION", 1, "Destination", new List<Choice>
            {
                new("EUR", "Europe"),
                new("WORLD", "World"),
                new("PL", "Poland")
            }),
            new NumericQuestion("NUM_OF_ADULTS", 2, "Number of adults"),
            new NumericQuestion("NUM_OF_CHILDREN", 3, "Number of children")
            });
            p.Activate();
            return p;
        }


        internal static Product House()
        {
            var p = Product.CreateDraft(
                "HSI",
                "Happy House",
                "https://images.pexels.com/photos/323780/pexels-photo-323780.jpeg?auto=compress&cs=tinysrgb&w=800",
                "House insurance",
                5,
                "building");

            p.AddCover("C1", "Fire", "", false, 200000);
            p.AddCover("C2", "Flood", "", false, 100000);
            p.AddCover("C3", "Theft", "", false, 50000);
            p.AddCover("C4", "Assistance", "", true, null);

            p.AddQuestions(new List<Question>
        {
            new ChoiceQuestion("TYP", 1, "Apartment / House", new List<Choice>
            {
                new("APT", "Apartment"),
                new("HOUSE", "House")
            }),
            new NumericQuestion("AREA", 2, "Area"),
            new NumericQuestion("NUM_OF_CLAIM", 3, "Number of claims in last 5 years"),
            new ChoiceQuestion("FLOOD", 4, "Located in flood risk area", ChoiceQuestion.YesNoChoice())
        });
            p.Activate();
            return p;
        }

        internal static Product Farm()
        {
            var p = Product.CreateDraft(
                "FAI",
                "Happy farm",
                "https://images.pexels.com/photos/96715/pexels-photo-96715.jpeg?auto=compress&cs=tinysrgb&w=800",
                "Farm insurance",
                1,
                "apple");

            p.AddCover("C1", "Crops", "", false, 200000);
            p.AddCover("C2", "Flood", "", false, 100000);
            p.AddCover("C3", "Fire", "", false, 50000);
            p.AddCover("C4", "Equipment", "", true, 300000);

            p.AddQuestions(new List<Question>
        {
            new ChoiceQuestion("TYP", 1, "Cultivation type", new List<Choice>
            {
                new("ZB", "Crop"),
                new("KW", "Vegetable")
            }),
            new NumericQuestion("AREA", 2, "Area"),
            new NumericQuestion("NUM_OF_CLAIM", 3, "Number of claims in last 5 years")
            //new ChoiceQuestion("FLOOD", 4, "Located in flood risk area", ChoiceQuestion.YesNoChoice()) //FIXME problem with code duplication
        });
            p.Activate();
            return p;
        }

        internal static Product Car()
        {
            var p = Product.CreateDraft(
                "CAR",
                "Happy Driver",
                "https://images.pexels.com/photos/112460/pexels-photo-112460.jpeg?auto=compress&cs=tinysrgb&w=800",
                "Car insurance",
                1,
                "car");

            p.AddCover("C1", "Assistance", "", true, null);
            p.AddQuestions(new List<Question>
        {
            new NumericQuestion("NUM_OF_CLAIM", 3, "Number of claims in last 5 years")
        });
            p.Activate();
            return p;
        }
    }
}
