using Xamarin.Forms;

namespace Plugin.KeyboardHelper
{
    public interface IKeyboardHelper
    {
        void HideKeyboard();

        void ShowKeyboard(View v);
    }
}
