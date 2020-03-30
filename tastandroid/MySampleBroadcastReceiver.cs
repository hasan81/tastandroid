using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace tastandroid
{
    [BroadcastReceiver(Enabled = true)]
    [IntentFilter(new[] { "com.xamarin.example.TEST" })]
    public class MySampleBroadcastReceiver : BroadcastReceiver
    {
       
       
       
        public event Action<string> UpdateText;
        public override void OnReceive(Context context, Intent intent)
        {

            if (intent != null)
            {
                Toast.MakeText(context, "Hurray it works", ToastLength.Short).Show();

                UpdateText?.Invoke("Hurray it works");
            }
           
                    
        }
    }


}