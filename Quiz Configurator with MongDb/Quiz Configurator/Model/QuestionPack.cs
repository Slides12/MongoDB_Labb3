using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Quiz_Configurator.Model
{
    public enum Difficulty { Easy, Medium, Hard }

    class QuestionPack
    {
        public QuestionPack(string name, Difficulty difficulty = Difficulty.Medium, int timeLimitInSeconds = 30)
        {
            _id = ObjectId.GenerateNewId();
            Name = name;
            Difficulty = difficulty;
            TimeLimitInSeconds = timeLimitInSeconds;
            Questions = new List<Question>();
        }

        public ObjectId _id { get; set; }
        public string Name { get; set; }
        public Difficulty Difficulty { get; set; }
        public int TimeLimitInSeconds { get; set; }
        public List<Question> Questions { get; set; }
    }
}
