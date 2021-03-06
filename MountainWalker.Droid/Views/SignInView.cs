﻿using System;
using Android.App;
using Android.Media;
using Android.OS;
using MvvmCross.Droid.Views;

namespace MountainWalker.Droid.Views
{
    [Activity(Label = "View for SignInViewModel")]
    public class SignInView : MvxActivity
    {
        public MediaPlayer _mediaPlayer;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            _mediaPlayer = MediaPlayer.Create(this, Resource.Raw.background);
            _mediaPlayer.Start();
            SetContentView(Resource.Layout.SignInView);

        }
    }
}
