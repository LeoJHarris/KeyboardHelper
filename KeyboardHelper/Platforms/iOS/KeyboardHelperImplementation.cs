using System;
using System.Collections.Generic;
using System.Text;
using UIKit;
using Xamarin.Forms;

namespace Plugin.KeyboardHelper
{
    /// <summary>
    /// Interface for $safeprojectgroupname$
    /// </summary>
    public class KeyboardHelperImplementation : IKeyboardHelper
    {
        /// <summary>
        /// The hide keyboard.
        /// </summary>
        public void HideKeyboard()
        {
            UIApplication.SharedApplication.KeyWindow.EndEditing(true);
        }

        /// <summary>
        /// The show keyboard.
        /// </summary>
        /// <param name="v">
        /// The v.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public void ShowKeyboard(View v)
        {
            v.Focus();
        }
    }
}
