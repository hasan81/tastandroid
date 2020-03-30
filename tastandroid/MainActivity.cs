using System;
using System.ComponentModel;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace tastandroid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        public MySampleBroadcastReceiver _mySampleBroadcastReceiver = new MySampleBroadcastReceiver();

        private TextView idTextView;
        private static string _uploadstring;
        public string Uploadstring
        {
            get
            {
                return _uploadstring;
            }
            set
            {
                _uploadstring = value;
               
            }
        }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            Uploadstring = "Test";
            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += FabOnClick;

            idTextView = FindViewById<TextView>(Resource.Id.textView1);
            idTextView.Text = Uploadstring;

            Button button = FindViewById<Button>(Resource.Id.button1);
            button.Click += Button_Click;
            RegisterReceiver(new MySampleBroadcastReceiver(), new IntentFilter("com.xamarin.example.TEST"));



            _mySampleBroadcastReceiver.UpdateText += _Class1_UpdateText;

        }

        private void _Class1_UpdateText(string obj)
        {
            Uploadstring = obj;
            idTextView.Text = Uploadstring;
        }

        private  void Button_Click(object sender, EventArgs e)
        {
            Intent message = new Intent("com.xamarin.example.TEST");
            SendBroadcast(message);
            _mySampleBroadcastReceiver.Dispose();


            //Uploadstring = "Hurray it works";
            //idTextView.Text = Uploadstring;


        }
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View) sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
	}
}

