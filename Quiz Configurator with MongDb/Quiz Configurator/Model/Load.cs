using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using Quiz_Configurator.Viewmodel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Quiz_Configurator.Model
{
    internal class Load
    {
        MongoClient mongoClient;
        public async Task<ObservableCollection<QuestionPackViewModel>> LoadData()
        {
            var config = new ConfigurationBuilder().AddUserSecrets<MainWindowViewModel>().Build();
            var connectionString = config["ConnectionString"];
            mongoClient = new MongoClient(connectionString);

            var packCollection = mongoClient.GetDatabase("QuizConfigurator").GetCollection<BsonDocument>("Packs");
            ObservableCollection<QuestionPackViewModel> Packs = new ObservableCollection<QuestionPackViewModel>();




            var bsonPacks = packCollection.AsQueryable().ToList();

            foreach(var bsonDoc in bsonPacks)
            {

                var questions = new ObservableCollection<Question>();

                var qp = new QuestionPackViewModel() { 
                    _id = new ObjectId(bsonDoc.GetValue("_id").ToString()), 
                    Difficulty = Enum.Parse<Difficulty>(bsonDoc.GetValue("Difficulty").ToString()),
                    Name = bsonDoc.GetValue("Name").ToString(),
                };

                foreach(var question in bsonDoc["Questions"].AsBsonArray)
                {

                    var incorrectAnswersArray = question["IncorrectAnswers"].AsBsonArray;

                    var incorrectAnswers = incorrectAnswersArray.Select(a => a.ToString()).ToArray();

                    qp.Questions.Add(new Question() { 
                        Query = question["Query"].ToString(), 
                        CorrectAnswer = question["CorrectAnswer"].ToString(),
                        IncorrectAnswers = incorrectAnswers
                    });
                }

                Packs.Add(qp);
            }




                

            return Packs;
        }
    }
}
