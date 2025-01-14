using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using Quiz_Configurator.Viewmodel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_Configurator.Model;

internal class MongoDBCategory
{
    public static async Task AddCategorysToMongoDBAsync()
    {
        var config = new ConfigurationBuilder().AddUserSecrets<MainWindowViewModel>().Build();
        var connectionString = config["ConnectionString"];
        MongoClient mongoClient = new MongoClient(connectionString);

        var categoryCollection = mongoClient.GetDatabase("QuizConfigurator").GetCollection<BsonDocument>("Categories");

        string[] categories = new string[]
     {
            "Technology",
            "Science",
            "Health",
            "Education",
            "Entertainment",
            "Sports",
            "Business",
            "Travel",
            "Food",
            "Lifestyle",
            "Fashion",
            "Art",
            "Music",
            "Movies",
            "History",
            "Politics",
            "Environment",
            "Finance",
            "Gaming",
            "Culture"
     };


        foreach (var category in categories)
        {



            var categoryDocument = new BsonDocument
        {
            { "Name", category }
        };

            var filter = Builders<BsonDocument>.Filter.Eq("Name", category);
            var options = new ReplaceOptions { IsUpsert = true };
            await categoryCollection.ReplaceOneAsync(filter, categoryDocument, options);
        }
    }


    public static async Task<ObservableCollection<string>> GetCategorysFromMongoDBAsync()
    {
        var config = new ConfigurationBuilder().AddUserSecrets<MainWindowViewModel>().Build();
        var connectionString = config["ConnectionString"];
        MongoClient mongoClient = new MongoClient(connectionString);

        var categoryCollection = mongoClient.GetDatabase("QuizConfigurator").GetCollection<BsonDocument>("Categories");
        ObservableCollection<String> Categories = new ObservableCollection<String>();

        var bsonCategories = categoryCollection.AsQueryable().ToList();

        foreach (var category in bsonCategories)
        {
            Categories.Add(category.GetValue("Name").ToString());
        }

        return Categories;
    }

    public static async Task AddCategoryToMongoDB(string categoryToAdd)
    {
        var config = new ConfigurationBuilder().AddUserSecrets<MainWindowViewModel>().Build();
        var connectionString = config["ConnectionString"];
        MongoClient mongoClient = new MongoClient(connectionString);

        var categoryCollection = mongoClient.GetDatabase("QuizConfigurator").GetCollection<BsonDocument>("Categories");


        var categoryDoc = new BsonDocument()
        {
            { "Name", categoryToAdd },
        };
        var updateOptions = new UpdateOptions { IsUpsert = true };
        var filter = Builders<BsonDocument>.Filter.Eq("Name", categoryToAdd);

        categoryCollection.UpdateOne(
        filter,
        new BsonDocument { { "$setOnInsert", categoryDoc } },
        updateOptions
        );
    }

    public static async Task RemoveCategoryMongoDB(string categoryToRemove)
    {
        var config = new ConfigurationBuilder().AddUserSecrets<MainWindowViewModel>().Build();
        var connectionString = config["ConnectionString"];
        MongoClient mongoClient = new MongoClient(connectionString);

        var categoryCollection = mongoClient.GetDatabase("QuizConfigurator").GetCollection<BsonDocument>("Categories");


        
        var filter = Builders<BsonDocument>.Filter.Eq("Name", categoryToRemove);

        categoryCollection.DeleteOne(filter);
    }

}
