using Quiz_Configurator.Command;
using Quiz_Configurator.Model;
using Quiz_Configurator.Windows;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace Quiz_Configurator.Viewmodel
{
    class ConfigurationViewModel : ViewModelBase
    {

        private readonly MainWindowViewModel mainWindowViewModel;
        public ObservableCollection<string> Categories { get; set; }

        public DelegateCommand NewQuestionCommand { get; }
        public DelegateCommand NewCategoryCommand { get; }
        public DelegateCommand DeleteQuestionCommand { get; }
        public DelegateCommand DeleteCategoryCommand { get; }
        public DelegateCommand SetActiveQuestionCommand { get; }
        public DelegateCommand PackOptionsCommand { get; }




        private Difficulty _difficulty;
        public Difficulty Difficulty
        {
            get
            {
                return _difficulty;
            }
            set
            {
                _difficulty = value;
                
                RaiseProperyChanged("Difficulty");
            }
        }

        private string _newCategory;
        public string NewCategory
        {
            get
            {
                return _newCategory;
            }
            set
            {
                _newCategory = value;

                RaiseProperyChanged("NewCategory");
            }
        }


        private Question? _activeQuestion;

        public Question? ActiveQuestion
        {
            get => _activeQuestion;
            set
            {
                _activeQuestion = value;
                mainWindowViewModel.save.SaveData(mainWindowViewModel.Packs);
                RaiseProperyChanged();
                DeleteQuestionCommand.RaiseCanExecuteChanged();
            }
        }


        public ConfigurationViewModel(MainWindowViewModel? mainWindowViewModel)
        {
            this.mainWindowViewModel = mainWindowViewModel;

            Categories = mainWindowViewModel.Categories;
            NewQuestionCommand = new DelegateCommand(NewQuestionButton, mainWindowViewModel.CanPlay);
            NewCategoryCommand = new DelegateCommand(NewCategoryButton, mainWindowViewModel.CanPlay);
            DeleteQuestionCommand = new DelegateCommand(DeleteQuestionButton, CanDeleteQuestion);
            DeleteCategoryCommand = new DelegateCommand(DeleteCategoryButton, mainWindowViewModel.CanPlay);
            SetActiveQuestionCommand = new DelegateCommand(SetActiveQuestion, mainWindowViewModel.CanPlay);
            PackOptionsCommand = new DelegateCommand(PackOptions, mainWindowViewModel.CanPlay);

        }


        private bool CanDeleteQuestion(object? arg) => ActivePack?.Questions.Count > 0;


        private void PackOptions(object obj)
        {
            PackOptionsDialog packOptionsDialog = new PackOptionsDialog() {DataContext = this};

            packOptionsDialog.ShowDialog();
            if(ActivePack != null)
            { 
                Difficulty = ActivePack.Difficulty;
            }
            mainWindowViewModel.save.SaveData(mainWindowViewModel.Packs);

        }

        private void SetActiveQuestion(object obj)
        {
            if (obj is Question selectedQuestion)
            {
                ActiveQuestion = selectedQuestion;
                RaiseProperyChanged(nameof(ActiveQuestion));
                mainWindowViewModel.save.SaveData(mainWindowViewModel.Packs);

            }
        }


        private async void DeleteCategoryButton(object obj)
        {
            RemoveCategoryDialog packOptionsDialog = new RemoveCategoryDialog() { DataContext = this };

            var result = packOptionsDialog.ShowDialog();


            if (result == true)
            {
                await MongoDBCategory.RemoveCategoryMongoDB(NewCategory);
                mainWindowViewModel.InitializeCategoriesAsync();
                Categories = mainWindowViewModel.Categories;
            }
        }
        private void DeleteQuestionButton(object obj)
        {
            ActivePack?.Questions.Remove(ActiveQuestion);
            mainWindowViewModel.save.SaveData(mainWindowViewModel.Packs);

        }

        private void NewQuestionButton(object obj)
        {
            Question q = new Question("New Question", "", "", "", "");
            ActivePack?.Questions.Add(q);
            ActiveQuestion = q;

            mainWindowViewModel.save.SaveData(mainWindowViewModel.Packs);


        }

        private async void NewCategoryButton(object obj)
        {
            AddCategoryDialog packOptionsDialog = new AddCategoryDialog() { DataContext = this };

            var result = packOptionsDialog.ShowDialog();
            

            if(result == true)
            {
                await MongoDBCategory.AddCategoryToMongoDB(NewCategory);
                mainWindowViewModel.InitializeCategoriesAsync();
                Categories = mainWindowViewModel.Categories;
            }
        }

        public QuestionPackViewModel? ActivePack { get => mainWindowViewModel.ActivePack; }
    }
}
