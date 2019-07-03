using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;

namespace DialogResultTest.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly IDialogService _dialogService;
        private string _title = "Prism Application";
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public MainWindowViewModel(IDialogService dialogService )
        {
            _dialogService = dialogService;
            ShowDialogCommand=new DelegateCommand(ShowDialog);
        }

        private void ShowDialog()
        {
            _dialogService.ShowDialog("ViewA",null, result =>
            {
                if (result.Result == ButtonResult.OK)
                {
                    Message = result.Parameters.GetValue<string>("message");
                }
            });
        }


        private string _message;

        public string Message
        {
            get => _message;
            set => SetProperty(ref _message , value);
        }


        public DelegateCommand ShowDialogCommand { get; set; }
    }
}
