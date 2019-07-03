using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Services.Dialogs;

namespace DialogResultTest.ViewModels
{
    public class ViewAViewModel : BindableBase,IDialogAware
    {
        public ViewAViewModel()
        {
            CloseCommand = new DelegateCommand(Close);
        }

        private void Close()
        {
            var result = new DialogResult(ButtonResult.OK);
            result.Parameters.Add("message","Closed from View Model");
            OnRequestClose(result);
        }

        public DelegateCommand CloseCommand { get; set; }
        #region Implementation of IDialogAware

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
            
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            
        }

        public string Title { get; }
        public event Action<IDialogResult> RequestClose;

        #endregion

        protected virtual void OnRequestClose(IDialogResult obj)
        {
            RequestClose?.Invoke(obj);
        }
    }
}
