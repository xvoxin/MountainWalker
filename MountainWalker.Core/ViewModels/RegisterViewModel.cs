using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using MountainWalker.Core.Interfaces;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using System.Text.RegularExpressions;

namespace MountainWalker.Core.ViewModels
{
    class RegisterViewModel : MvxViewModel
    {
        private string _name = "";
        private string _surname = "";
        private string _login = "";
        private string _password = "";
        private string _repPassword = "";
        private string _email = "";
        private readonly IDialogService _dialogService;
        private readonly IRegisterService _registerService;

        public RegisterViewModel(IDialogService dialogService, IRegisterService registerService)
        {
            _dialogService = dialogService;
            _registerService = registerService;
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Surname
        {
            get { return _surname; }
            set { _surname = value; }
        }
        public string Login
        {
            get { return _login; }
            set { _login = value; }
        }
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        public string RepPassword
        {
            get { return _repPassword; }
            set { _repPassword = value; }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public IMvxCommand RegisterButton => new MvxCommand(Walidate);

        private void Walidate()
        {
            if (CheckName(_name) && CheckName(_surname) && CheckLogin(_login) && CheckPassword(_password) && CheckPassword(_repPassword) && CheckEmail(_email) && (_password.Equals(_repPassword)))
            {
                //TODO: Insert new user into DB
                ShowViewModel<MainViewModel>();
            }
            else
            {
                _dialogService.ShowAlert("Uwaga!", "Dane są nieprawidłowe", "OK");
            }
        }

        private Boolean CheckName(string name)
        {
            if ((name.Length <= 1) && (name.Length >= 20))
                return false;
            if (name.ToCharArray().Any(char.IsDigit))
                return false;
            if (name.ToCharArray().Any(char.IsSymbol))
                return false;
            return true;
        }

        private Boolean CheckLogin(string login)
        {
            if ((login.Length <= 2) && (login.Length >= 12))
                return false;
            if (login.ToCharArray().Any(char.IsSymbol))
                return false;
            if (Regex.IsMatch(login, @"^\d+"))
                return false;

            //TODO: Check if login is taken

            return true;

        }

        private Boolean CheckPassword(string password)
        {
            if ((password.Length <= 5) && (password.Length >= 20))
                return false;
            return true;

        }

        private Boolean CheckEmail(string email)
        {
            if ((email.Length <= 5) && (email.Length >= 20))
                return false;
            if (Regex.IsMatch(email, @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$"))
                return false;
            return true;
        }
    }
}
