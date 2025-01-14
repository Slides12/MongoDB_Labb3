using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Quiz_Configurator.Model;
using System.Collections.ObjectModel;

namespace Quiz_Configurator.Viewmodel
{
    class QuestionPackViewModel : ViewModelBase
    {
        private readonly QuestionPack _model;
        
        [BsonId]
        public ObjectId _id
        {
            get => _model._id;
            set
            {
                _model._id = value;
                RaiseProperyChanged();
            }
        }

        public string Name
        {
            get => _model.Name;
            set
            {
                _model.Name = value;
                RaiseProperyChanged();
            }
        }

        public Difficulty Difficulty
        {
            get => _model.Difficulty;
            set
            {
                _model.Difficulty = value;
                RaiseProperyChanged();
            }
        }

        public string Category
        {
            get => _model.Category;
            set
            {
                _model.Category = value;
                RaiseProperyChanged();
            }
        }


        public int TimeLimitInSeconds
        {
            get => _model.TimeLimitInSeconds;
            set
            {
                _model.TimeLimitInSeconds = value;
                RaiseProperyChanged();
            }
        }

        public ObservableCollection<Question> Questions { get; }


        public QuestionPackViewModel()
        {
            this._model = new QuestionPack(string.Empty);
            this.Questions = new ObservableCollection<Question>();
        }

        public QuestionPackViewModel(QuestionPack model)
        {
            this._model = model;
            this.Questions = new ObservableCollection<Question>(model.Questions);
        }
    }
}
