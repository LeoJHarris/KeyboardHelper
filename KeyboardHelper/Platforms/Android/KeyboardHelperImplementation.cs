using Android.App;
using Android.Content;
using Android.OS;
using Android.Views.InputMethods;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace Plugin.KeyboardHelper
{
    /// <summary>
    /// Interface for $safeprojectgroupname$
    /// </summary>
    public class KeyboardHelperImplementation : IKeyboardHelper
    {
        private readonly Context _context;


        public KeyboardHelperImplementation()
        {
            this._context = Android.App.Application.Context;
        }

        public void HideKeyboard()
        {
            if (this._context.GetSystemService(Context.InputMethodService) is InputMethodManager inputMethodManager &&
                this._context is Activity)
            {
                Activity activity = (Activity)this._context;
                IBinder token = activity.CurrentFocus?.WindowToken;
                inputMethodManager.HideSoftInputFromWindow(token, HideSoftInputFlags.None);

                activity.Window.DecorView.ClearFocus();
            }
        }

        public static void Init(Context context) { PackageName = context.PackageName; }

        public void ShowKeyboard(View v)
        {
            IVisualElementRenderer renderer = Platform.CreateRendererWithContext(v, this._context);
            Android.Views.View rendererView = renderer.View;
            renderer.Tracker.UpdateLayout();
            rendererView.Layout(0, 0, (int)v.WidthRequest, (int)v.HeightRequest);

            Android.Views.View child = rendererView;

            if (this._context.GetSystemService(Context.InputMethodService) is InputMethodManager inputMethodManager)
            {
                child.RequestFocus();
                inputMethodManager.ShowSoftInput(child, ShowFlags.Forced);
                inputMethodManager.ToggleSoftInput(ShowFlags.Forced, HideSoftInputFlags.ImplicitOnly);
            }
        }

        private static string PackageName
        {
            get;
            set;
        }
    }
}
