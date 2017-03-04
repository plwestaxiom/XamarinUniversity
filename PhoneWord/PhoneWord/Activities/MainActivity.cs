using Android.App;
using Android.Widget;
using Android.OS;
using System;
using Android.Content;
using PhoneWord.Interfaces;
using System.Collections.Generic;

namespace PhoneWord
{
    [Activity(Label = "Phone Word", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        static readonly List<string> phoneNumbers = new List<string>();
        public object Core { get; private set; }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);


            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);


            EditText phoneNumberText = FindViewById<EditText>(Resource.Id.phoneNumberText);
            Button translateButton = FindViewById<Button>(Resource.Id.translateButton);
            Button callButton = FindViewById<Button>(Resource.Id.callButton);
            Button callHistoryButton = FindViewById<Button>(Resource.Id.CallHistoryButton);

            callButton.Enabled = false;

            string translatedNumber = string.Empty;

            translateButton.Click += (object sender, EventArgs e) => 
            {
                translatedNumber = PhoneNumberTranslator.ToNumber(phoneNumberText.Text);
                if (string.IsNullOrWhiteSpace(translatedNumber))
                {
                    callButton.Text = "Call";
                    callButton.Enabled = false;
                }
                else
                {
                    callButton.Text = string.Format("Call {0}", translatedNumber);
                    callButton.Enabled = true;
                }
            };

            callButton.Click += (object sender, EventArgs e) =>
            {
                var callDialog = new AlertDialog.Builder(this);
                callDialog.SetMessage(string.Format("Call {0}?", translatedNumber));
                callDialog.SetNeutralButton("Call", delegate
                                                    {
                                                        phoneNumbers.Add(translatedNumber);

                                                        callHistoryButton.Enabled = true;

                                                        var callIntent = new Intent(Intent.ActionCall);
                                                        callIntent.SetData(Android.Net.Uri.Parse(string.Format("tel:{0}?", translatedNumber)));
                                                        StartActivity(callIntent);
                                                    });
                callDialog.SetNegativeButton("Cancel", delegate { });

                callDialog.Show();
            };

            callHistoryButton.Click += (object sender, EventArgs e) =>
            {
                var intent = new Intent(this, typeof(CallHistoryActivity));
                intent.PutStringArrayListExtra("phone_numbers", phoneNumbers);
                StartActivity(intent);
            };

        }
    }
}

