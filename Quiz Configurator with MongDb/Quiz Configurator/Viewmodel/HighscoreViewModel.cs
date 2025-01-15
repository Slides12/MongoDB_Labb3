using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_Configurator.Viewmodel;

internal class HighscoreViewModel : ViewModelBase
{
    private readonly MainWindowViewModel mainWindowViewModel;

    private string _playerName = "";
    public string PlayerName
    {
        get
        {
            return _playerName;
        }
        set
        {
            _playerName = value;

            RaiseProperyChanged("PlayerName");
            mainWindowViewModel.SetPlayerViewCommand.RaiseCanExecuteChanged();
        }
    }

    public HighscoreViewModel(MainWindowViewModel? mainWindowViewModel)
    {
            this.mainWindowViewModel = mainWindowViewModel;

    }

}
