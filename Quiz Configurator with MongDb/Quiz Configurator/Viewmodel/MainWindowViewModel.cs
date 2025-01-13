﻿using Quiz_Configurator.Command;
using Quiz_Configurator.Model;
using Quiz_Configurator.View;
using Quiz_Configurator.Windows;
using System.Collections.ObjectModel;
using System.Net.Http.Json;
using System.Text.Json;
using System.Web;
using System.Windows;
using System.Windows.Controls;

namespace Quiz_Configurator.Viewmodel
{
    class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<QuestionPackViewModel> Packs { get; set; }
        public PlayerViewModel PlayerViewModel { get; }
        public ConfigurationViewModel ConfigurationViewModel { get; }

        public Save save;
        public Load load;
        public Import import;

        public DelegateCommand NewPackCommand { get; }
        public DelegateCommand SetActivePackCommand { get; }
        public DelegateCommand DeletePackCommand { get; }

        public DelegateCommand SaveOnCloseCommand { get; }
        public DelegateCommand ImportFromDBCommand { get; }
        public DelegateCommand ImportMenuCommand { get; }
        public DelegateCommand FullscreenCommand { get; }
        public DelegateCommand ExitCommand { get; }


        public DelegateCommand SetPlayerViewCommand { get; }
        public DelegateCommand SetConfigViewCommand { get; }




        private QuestionPackViewModel? _activePack;

        public ObservableCollection<Category> CategoriesList { get; set; }

        public QuestionPackViewModel? ActivePack
        {
            get => _activePack;
            set
            {
                _activePack = value;
                RaiseProperyChanged();
                ConfigurationViewModel?.RaiseProperyChanged("ActivePack");
                if(ConfigurationViewModel != null) { 
                ConfigurationViewModel.DeleteQuestionCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public bool _playActive = false;

        public bool PlayActive
        {
            get
            {
                return _playActive;
            }
            set
            {
                _playActive = value;

                RaiseProperyChanged("PlayActive");

                NewPackCommand.RaiseCanExecuteChanged();
                SetActivePackCommand.RaiseCanExecuteChanged();
                DeletePackCommand.RaiseCanExecuteChanged();
                SetPlayerViewCommand.RaiseCanExecuteChanged();
                ImportMenuCommand.RaiseCanExecuteChanged();
                ConfigurationViewModel.NewQuestionCommand.RaiseCanExecuteChanged();
                ConfigurationViewModel.SetActiveQuestionCommand.RaiseCanExecuteChanged();
                ConfigurationViewModel.PackOptionsCommand.RaiseCanExecuteChanged();
            }
        }


        //Import

        private string _downloadDifficulty = "medium";
        public string DownloadDifficulty
        {
            get
            {
                return _downloadDifficulty;
            }
            set
            {
                _downloadDifficulty = value.ToLower();

                RaiseProperyChanged("Difficulty");
            }
        }

        private Category _selectedCategory;
        public Category SelectedCategory
        {
            get
            {
                return _selectedCategory;
            }
            set
            {

                _selectedCategory = value;

                Category = _selectedCategory?.id ?? 9;

                RaiseProperyChanged("SelectedCategory");
            }
        }

        private int _category = 9;
        public int Category
        {
            get
            {
                return _category;
            }
            set
            {
                _category = value;
                RaiseProperyChanged("Category");
            }
        }

        private int _numberOfQuestions = 10;
        public int NumberOfQuestions
        {
            get
            {
                return _numberOfQuestions;
            }
            set
            {
                _numberOfQuestions = value;

                RaiseProperyChanged("NumberOfQuestions");
            }
        }

        // Visibility

        private Visibility _playerVisibility;
        public Visibility PlayerVisibility
        {
            get
            {
                return _playerVisibility;
            }
            set
            {
                _playerVisibility = value;

                RaiseProperyChanged("PlayerVisibility");
            }
        }

        private Visibility _configVisibility;
        public Visibility ConfigVisibility
        {
            get
            {
                return _configVisibility;
            }
            set
            {
                _configVisibility = value;

                RaiseProperyChanged("ConfigVisibility");
            }
        }


        private Visibility _endScreenVisibility;
        public Visibility EndScreenVisibility
        {
            get
            {
                return _endScreenVisibility;
            }
            set
            {
                _endScreenVisibility = value;

                RaiseProperyChanged("EndScreenVisibility");
            }
        }


        // Add Pack


        private Difficulty _packDifficulty;
        public Difficulty PackDifficulty
        {
            get
            {
                return _packDifficulty;
            }
            set
            {
                _packDifficulty = value;

                RaiseProperyChanged("PackDifficulty");
            }
        }

        private string _packName = "<PackName>";
        public string PackName
        {
            get
            {
                return _packName;
            }
            set
            {
                _packName = value;

                RaiseProperyChanged("PackName");
            }
        }

        private int _packTimeLimit = 30;
        public int PackTimeLimit
        {
            get
            {
                return _packTimeLimit;
            }
            set
            {
                _packTimeLimit = value;

                RaiseProperyChanged("PackTimeLimit");
            }
        }

        public MainWindowViewModel()
        {
            load = new Load();
            save = new Save();
            import = new Import();
            GetCategorys();
            LoadAsync();



            NewPackCommand = new DelegateCommand(AddPack, CanPlay);
            SetActivePackCommand = new DelegateCommand(SetActivePack, CanPlay);
            DeletePackCommand = new DelegateCommand(DeleteActivePack, CanPlay);
            SetPlayerViewCommand = new DelegateCommand(SetPlayerView, CanPlay);
            SetConfigViewCommand = new DelegateCommand(SetConfigView);
            FullscreenCommand = new DelegateCommand(SetFullscreen);

            SaveOnCloseCommand = new DelegateCommand(SaveOnClose);
            ImportFromDBCommand = new DelegateCommand(async _ => await GetQuestions(ActivePack), _ => true);
            ImportMenuCommand = new DelegateCommand(ImportMenu, CanPlay);
            ExitCommand = new DelegateCommand(Exit);

            ConfigVisibility = Visibility.Visible;
            PlayerVisibility = Visibility.Hidden;
            EndScreenVisibility = Visibility.Hidden;





            PlayerViewModel = new PlayerViewModel(this);
            ConfigurationViewModel = new ConfigurationViewModel(this);
        }


        public bool CanPlay(object? arg) => PlayActive == false;



        private void SetFullscreen(object obj)
        {
            if (Application.Current.MainWindow.WindowState == WindowState.Normal)
            {
                Application.Current.MainWindow.WindowState = WindowState.Maximized;
                
            }
            else
            {
                Application.Current.MainWindow.WindowState = WindowState.Normal;

            }
        }

      

        private void Exit(object obj)
        {
            
            Application.Current.Shutdown();
        }

        private void SaveOnClose(object obj)
        {
            save.SaveData(Packs);
        }

        private void DeleteActivePack(object obj)
        {
            var Result = MessageBox.Show($"Are you sure you want to delete {ActivePack.Name}?","Delete question pack.",MessageBoxButton.YesNo);
            if(Result == MessageBoxResult.Yes) 
            { 
                Packs?.Remove(ActivePack);

                if(Packs.Count > 0) { 
                    ActivePack = Packs[0];
                }
                else
                {
                    ActivePack = null;
                }
            }
            
            save.SaveData(Packs);
        }

        private void SetConfigView(object obj)
        {
            ConfigVisibility = Visibility.Visible;
            PlayerVisibility = Visibility.Hidden;
            EndScreenVisibility = Visibility.Hidden;
            PlayerViewModel.StopTimer();
            PlayActive = false;
            save.SaveData(Packs);

            RaiseProperyChanged(nameof(ConfigVisibility));
            RaiseProperyChanged(nameof(PlayerVisibility));
            RaiseProperyChanged(nameof(EndScreenVisibility));
        }

        private void SetPlayerView(object obj)
        {
            if (!PlayActive)
            {
                PlayActive = true;
                if (ActivePack.Questions.Count > 0) { 
                ConfigVisibility = Visibility.Hidden;
                PlayerVisibility = Visibility.Visible;
                EndScreenVisibility = Visibility.Hidden;
                PlayerViewModel.CurrentAmountOfQuestions = ActivePack.Questions.Count();
                PlayerViewModel.StartGame();
            
                RaiseProperyChanged(nameof(ConfigVisibility));
                RaiseProperyChanged(nameof(PlayerVisibility));
                RaiseProperyChanged(nameof(EndScreenVisibility));
                }
                else
                {
                    SetConfigView(obj);

                    MessageBox.Show("You currently have no questions in this packs. Add questions or choose another pack.");
                }
            }
            

        }

        public void SetEndScreen()
        {
            ConfigVisibility = Visibility.Hidden;
            PlayerVisibility = Visibility.Hidden;
            EndScreenVisibility = Visibility.Visible;
            PlayerViewModel.CurrentAmountOfQuestions = ActivePack.Questions.Count();
            PlayerViewModel.StopTimer();

            RaiseProperyChanged(nameof(ConfigVisibility));
            RaiseProperyChanged(nameof(PlayerVisibility));
            RaiseProperyChanged(nameof(EndScreenVisibility));
        }

        private void SetActivePack(object obj)
        {
            if (obj is QuestionPackViewModel selectedPack)
            {
                ActivePack = selectedPack;
                PlayerViewModel.SetTimerValue();

                RaiseProperyChanged(nameof(ActivePack));  
            }
        }

        private void AddPack(object obj)
        {
            CreateNewPackDialog createNewPackDialog = new CreateNewPackDialog() { DataContext = this };
            var result = createNewPackDialog.ShowDialog();



            if (result == true)
            {
                QuestionPackViewModel qp = new QuestionPackViewModel(new QuestionPack(PackName, PackDifficulty, PackTimeLimit));
                ActivePack = qp;
                ConfigurationViewModel.Difficulty = ActivePack.Difficulty;
                Packs.Add(qp);
                save.SaveData(Packs);
            }

        }


        private async void ImportMenu(object obj)
        {
            if(CategoriesList.Count > 0) { 
            _selectedCategory = CategoriesList[0];

            ImportQuestions createNewImportDialog = new ImportQuestions() {DataContext = this};
            var result = createNewImportDialog.ShowDialog();



            if (result == true)
            {
                await GetQuestions(ActivePack, NumberOfQuestions, Category, DownloadDifficulty);
                save.SaveData(Packs);

                }
            }
        }
       


        public async Task LoadAsync()
        {
            var loadedPacks = await load.LoadData();

            if (loadedPacks.Count > 0)
            {
                Packs = loadedPacks;
                ActivePack = Packs[0];
            }
            else
            {
                Packs = new ObservableCollection<QuestionPackViewModel>();
                QuestionPackViewModel qp = new QuestionPackViewModel(new QuestionPack("My Question pack"));
                Packs.Add(qp);
                ActivePack = qp;
            }
        }



        public static async Task GetQuestions(QuestionPackViewModel? ActivePack, int amount = 10, int category = 9, string difficulty = "medium" )
        {
            Import import = new Import();
            string questions = await import.ImportAsync(amount,category,difficulty);

            if (questions != null)
            {
                var quizResponse = JsonSerializer.Deserialize<ImportClass>(questions);
                
                if (quizResponse != null && quizResponse.Results != null && ActivePack?.Questions != null)
                {
                    foreach (var question in quizResponse.Results)
                    {
                        question.Query = HttpUtility.HtmlDecode(question.Query);
                        question.CorrectAnswer = HttpUtility.HtmlDecode(question.CorrectAnswer);
                        question.IncorrectAnswers[0] = HttpUtility.HtmlDecode(question.IncorrectAnswers[0]);
                        question.IncorrectAnswers[1] = HttpUtility.HtmlDecode(question.IncorrectAnswers[1]);
                        question.IncorrectAnswers[2] = HttpUtility.HtmlDecode(question.IncorrectAnswers[2]);

                        ActivePack.Questions.Add(question);
                    }
                }
                if (quizResponse.ResponseCode == 1)
                {
                    MessageBox.Show("The API doesn't have enough questions for your query. (Ex. Asking for 20 Questions in a Category that only has 10.)");
                }
                else if (quizResponse.ResponseCode > 1)
                {
                    MessageBox.Show($"{quizResponse.ResponseCode} Huh?");
                }
            }
        }


        public async Task GetCategorys()
        {
            CategoriesList = new ObservableCollection<Category>();

            Import import = new Import();
            string triviaCategories = await import.ImportCategorysAsync();

            if (triviaCategories != null)
            {
                var categoryResponse = JsonSerializer.Deserialize<TriviaCategories>(triviaCategories);

                CategoriesList.Clear();

                foreach (var category in categoryResponse.triviaCategories)
                {
                    CategoriesList.Add(category);
                }

            }
        }

    }
}
