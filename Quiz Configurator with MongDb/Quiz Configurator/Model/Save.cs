using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using Quiz_Configurator.Viewmodel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Windows.Forms.Design.AxImporter;

namespace Quiz_Configurator.Model
{
    internal class Save
    {
        MongoClient mongoClient;
        public async Task SaveData(ObservableCollection<QuestionPackViewModel> Packs)
        {
            var config = new ConfigurationBuilder().AddUserSecrets<MainWindowViewModel>().Build();
            var connectionString = config["ConnectionString"];
            mongoClient = new MongoClient(connectionString);

            var packCollection = mongoClient.GetDatabase("QuizConfigurator").GetCollection<BsonDocument>("Packs");


            foreach (var pack in Packs)
            {
                var questionArray = new BsonArray();

                foreach (var question in pack.Questions)
                {
                    
                    var questionDoc = new BsonDocument
                    {
                        { "Query", question.Query },
                        { "CorrectAnswer", question.CorrectAnswer },
                        { "IncorrectAnswers", new BsonArray{ question.IncorrectAnswers[0], question.IncorrectAnswers[1], question.IncorrectAnswers[2] } }
                    };
                    questionArray.Add(questionDoc);
                }


                var doc = new BsonDocument
                {
                    { "_id", pack._id },
                    { "Name", pack.Name },
                    { "Difficulty", pack.Difficulty },
                    { "TimeLimitInSeconds", pack.TimeLimitInSeconds },
                    { "Category", pack.Category },
                    { "Questions", questionArray }
                };


                var filter = Builders<BsonDocument>.Filter.Eq("_id", pack._id);
                var existingDocument = await packCollection.Find(filter).FirstOrDefaultAsync();

                if (existingDocument != null)
                {
                    var updateDefinition = Builders<BsonDocument>.Update
                        .Set("Name", pack.Name)
                        .Set("Difficulty", pack.Difficulty)
                        .Set("TimeLimitInSeconds", pack.TimeLimitInSeconds)
                        .Set("Category", pack.Category)
                        .Set("Questions", questionArray);

                    await packCollection.UpdateOneAsync(filter, updateDefinition);
                }
                else
                {
                    await packCollection.InsertOneAsync(doc);
                }
            }
        }
    }
}
