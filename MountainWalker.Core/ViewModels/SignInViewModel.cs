﻿using System;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;

namespace MountainWalker.Core.ViewModels
{
    public class SignInViewModel : MvxViewModel
    {
        public SignInViewModel()
        {
        }


    public override Task Initialize()
        {
            //TODO: Add starting logic here

            return base.Initialize();
        }

        public IMvxCommand SignInButton => new MvxCommand(checkFields);
        private void checkFields()
        {

            if (_login.Equals("admin") && _password.Equals("admin"))
            {
                ShowViewModel<MainViewModel>();
            }
            else
            {
                var foo = Mvx.Resolve<IDialogAlert>();
                foo.Alert("Uwaga!", "Dane są nieprawidłowe", "OK");
            }
        }
        private string _login;
        private string _password;

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
    }


}