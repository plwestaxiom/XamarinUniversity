using Android.App;
using Android.Content;
using Android.OS;
using Android.Util;
using Android.Widget;
using System;

namespace ActivityLifecycle
{
    [Activity(Label = "Activity A", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {

        private int _counter;

        protected override void OnCreate(Bundle bundle)
        {
            Log.Debug(GetType().FullName, "Activity A - OnCreate");
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);


            //FindViewById<Button>(Resource.Id.myButton).Click += (object sender, EventArgs)
            FindViewById<Button>(Resource.Id.btnStartB).Click += (sender, args) =>
            {
                var intent = new Intent(this, typeof(SecondActivity));
                StartActivity(intent);
            };


            if (bundle != null)
            {
                _counter = bundle.GetInt("click_count", 0);
                Log.Debug(GetType().FullName, "Activity A - Recovered instance state.");
            }

            var clickButton = FindViewById<Button>(Resource.Id.clickButton);
            clickButton.Text = Resources.GetString(Resource.String.counterbutton_text, _counter);
            clickButton.Click += (object sender, EventArgs e) =>
            {
                _counter++;
                clickButton.Text = Resources.GetString(Resource.String.counterbutton_text, _counter);
            };
        }

        protected override void OnDestroy()
        {
            Log.Debug(GetType().FullName, "Activity A - OnDestroy");
            base.OnDestroy();
        }
        protected override void OnPause()
        {
            Log.Debug(GetType().FullName, "Activity A - OnPause");
            base.OnPause();
        }
        protected override void OnRestart()
        {
            Log.Debug(GetType().FullName, "Activity A - OnRestart");
            base.OnRestart();
        }
        protected override void OnResume()
        {
            Log.Debug(GetType().FullName, "Activity A - OnResume");
            base.OnResume();
        }
        protected override void OnStart()
        {
            Log.Debug(GetType().FullName, "Activity A - OnStart");
            base.OnStart();
        }
        protected override void OnStop()
        {
            Log.Debug(GetType().FullName, "Activity A - OnStop");
            base.OnStop();
        }

        protected override void OnSaveInstanceState(Bundle outState)
        {
            base.OnSaveInstanceState(outState);


            outState.PutInt("click_count", _counter);
            Log.Debug(GetType().FullName, "Activity A - OnSaveInstanceState");
        }

    }
}

