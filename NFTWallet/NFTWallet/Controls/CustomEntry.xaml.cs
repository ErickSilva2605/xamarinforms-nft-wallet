using System;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Effects;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NFTWallet.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomEntry : ContentView
    {
        public event EventHandler<EventArgs> Completed;

        public static readonly BindableProperty TextProperty = BindableProperty.Create(
            nameof(Text), 
            typeof(string), 
            typeof(CustomEntry), 
            string.Empty, 
            BindingMode.TwoWay, 
            null,
            async (bindable, oldValue, newValue) =>
            {
                var control = bindable as CustomEntry;
                control.entryBorderless.Text = (string)newValue;

                if (!control.entryBorderless.IsFocused)
                {
                    if (!string.IsNullOrEmpty((string)newValue))
                        await control.TranslatePlaceholderToTitle(false);
                    else
                        await control.TranslateTitleToPlaceholder(false);
                }
            }
        );

        public static readonly BindableProperty TextColorProperty = BindableProperty.Create(
            nameof(TextColor), 
            typeof(Color), 
            typeof(CustomEntry), 
            Color.Gray,
            BindingMode.Default,
            null,
            (bindable, oldValue, newValue) =>
            {
                var control = bindable as CustomEntry;
                control.entryBorderless.TextColor = (Color)newValue;
            }
        );

        public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create(
            nameof(Placeholder), 
            typeof(string), 
            typeof(CustomEntry), 
            string.Empty,
            BindingMode.Default,
            null,
            (bindable, oldValue, newValue) =>
            {
                var control = bindable as CustomEntry;
                control.placeholderText.Text = (string)newValue;
            }
        );

        public static readonly BindableProperty PlaceholderColorProperty = BindableProperty.Create(
            nameof(PlaceholderColor), 
            typeof(Color), 
            typeof(CustomEntry), 
            Color.Gray,
            BindingMode.Default,
            null,
            (bindable, oldValue, newValue) =>
            {
                var control = bindable as CustomEntry;

                if (!control.entryBorderless.IsFocused && string.IsNullOrEmpty(control.entryBorderless.Text))
                    control.placeholderText.TextColor = (Color)newValue;
            }
        );

        public static readonly BindableProperty LeadingIconProperty = BindableProperty.Create(
            nameof(LeadingIcon), 
            typeof(ImageSource), 
            typeof(CustomEntry), 
            default(ImageSource),
            BindingMode.Default,
            null,
            (bindable, oldValue, newValue) =>
            {
                var control = bindable as CustomEntry;
                control.leadingIcon.Source = (ImageSource)newValue;
            }
        );


        public static readonly BindableProperty LeadingIconColorProperty = BindableProperty.Create(
            nameof(LeadingIconColor), 
            typeof(Color), 
            typeof(CustomEntry), 
            Color.White,
            BindingMode.Default,
            null,
            (bindable, oldValue, newValue) =>
            {
                var control = bindable as CustomEntry;

                if (!control.entryBorderless.IsFocused && string.IsNullOrEmpty(control.entryBorderless.Text))
                    IconTintColorEffect.SetTintColor(control.leadingIcon, (Color)newValue);
            }
        );

        public static readonly BindableProperty CardBackgroundColorProperty = BindableProperty.Create(
            nameof(CardBackgroundColor), 
            typeof(Color), 
            typeof(CustomEntry), 
            Color.White,
            BindingMode.Default,
            null,
            (bindable, oldValue, newValue) =>
            {
                var control = bindable as CustomEntry;
                control.frameContainer.BackgroundColor = (Color)newValue;
            }
        );

        public static readonly BindableProperty CardBorderColorProperty = BindableProperty.Create(
            nameof(CardBorderColor), 
            typeof(Color), 
            typeof(CustomEntry), 
            Color.White,
            BindingMode.Default,
            null,
            (bindable, oldValue, newValue) =>
            {
                var control = bindable as CustomEntry;

                if (!control.entryBorderless.IsFocused && string.IsNullOrEmpty(control.entryBorderless.Text))
                    control.frameContainer.BorderColor = (Color)newValue;
            }
        );

        public static readonly BindableProperty AccentColorProperty = BindableProperty.Create(
            nameof(AccentColor), 
            typeof(Color), 
            typeof(CustomEntry), 
            Color.Blue,
            BindingMode.Default
        );

        public static readonly BindableProperty KeyboardProperty = BindableProperty.Create(
            nameof(Keyboard), 
            typeof(Keyboard), 
            typeof(CustomEntry), 
            Keyboard.Default,
            BindingMode.Default,
            null,
            (bindable, oldValue, newValue) =>
            {
                var control = bindable as CustomEntry;
                control.entryBorderless.Keyboard = (Keyboard)newValue;
            }
        );

        public static readonly BindableProperty IsPasswordProperty = BindableProperty.Create(
            nameof(IsPassword), 
            typeof(bool), 
            typeof(CustomEntry), 
            default(bool),
            BindingMode.Default,
            null,
            (bindable, oldValue, newValue) =>
            {
                var control = bindable as CustomEntry;
                control.entryBorderless.IsPassword = (bool)newValue;
            }
        );

        public static readonly BindableProperty ReturnTypeProperty = BindableProperty.Create(
            nameof(ReturnType), 
            typeof(ReturnType), 
            typeof(CustomEntry), 
            ReturnType.Default,
            BindingMode.Default,
            null,
            (bindable, oldValue, newValue) =>
            {
                var control = bindable as CustomEntry;
                control.entryBorderless.ReturnType = (ReturnType)newValue;
            }
        );

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public Color TextColor
        {
            get => (Color)GetValue(TextColorProperty);
            set => SetValue(TextColorProperty, value);
        }

        public string Placeholder
        {
            get => (string)GetValue(PlaceholderProperty);
            set => SetValue(PlaceholderProperty, value);
        }

        public Color PlaceholderColor
        {
            get => (Color)GetValue(PlaceholderColorProperty);
            set => SetValue(PlaceholderColorProperty, value);
        }

        public ImageSource LeadingIcon
        {
            get => (ImageSource)GetValue(LeadingIconProperty);
            set => SetValue(LeadingIconProperty, value);
        }

        public Color CardBackgroundColor
        {
            get => (Color)GetValue(CardBackgroundColorProperty);
            set => SetValue(CardBackgroundColorProperty, value);
        }

        public Color CardBorderColor
        {
            get => (Color)GetValue(CardBorderColorProperty);
            set => SetValue(CardBorderColorProperty, value);
        }

        public Color AccentColor
        {
            get => (Color)GetValue(AccentColorProperty);
            set => SetValue(AccentColorProperty, value);
        }

        public Color LeadingIconColor
        {
            get => (Color)GetValue(LeadingIconColorProperty);
            set => SetValue(LeadingIconColorProperty, value);
        }

        public Keyboard Keyboard
        {
            get => (Keyboard)GetValue(KeyboardProperty);
            set => SetValue(KeyboardProperty, value);
        }

        public bool IsPassword
        {
            get => (bool)GetValue(IsPasswordProperty);
            set => SetValue(IsPasswordProperty, value);
        }

        public ReturnType ReturnType
        {
            get => (ReturnType)GetValue(ReturnTypeProperty);
            set => SetValue(ReturnTypeProperty, value);
        }

        public CustomEntry()
        {
            InitializeComponent();
            entryBorderless.Text = Text;
        }

        private void HandleTapped(object sender, EventArgs e)
        {
            MainThread.BeginInvokeOnMainThread(async () => await TranslatePlaceholderToTitle(true));
        }

        private void HandleFocused(object sender, FocusEventArgs e)
        {
            if (e.IsFocused)
                MainThread.BeginInvokeOnMainThread(async () => await TranslatePlaceholderToTitle(true));
        }

        private void HandleUnfocused(object sender, FocusEventArgs e)
        {
            if (!e.IsFocused)
                MainThread.BeginInvokeOnMainThread(async () => await TranslateTitleToPlaceholder(true));
        }

        private void HandleCompleted(object sender, EventArgs e) => Completed?.Invoke(this, e);

        private async Task TranslatePlaceholderToTitle(bool animated)
        {
            frameContainer.BorderColor = AccentColor;
            IconTintColorEffect.SetTintColor(leadingIcon, AccentColor);

            entryBorderless.Focus();

            if (animated)
            {
                await Task.WhenAll(
                    placeholderText.TranslateTo(0, -12, 100, Easing.Linear),
                    entryBorderless.TranslateTo(0, 8, 100, Easing.Linear),
                    TranslateToColor(AccentColor),
                    TranslateToFontSize(12)
                );
            }
            else
            {
                placeholderText.TranslationY = -12;
                placeholderText.TextColor = AccentColor;
                placeholderText.FontSize = 12;
                entryBorderless.TranslationY = 8;

            }
        }

        private async Task TranslateTitleToPlaceholder(bool animated)
        {
            if (string.IsNullOrEmpty(entryBorderless.Text))
            {
                frameContainer.BorderColor = CardBorderColor;
                IconTintColorEffect.SetTintColor(leadingIcon, LeadingIconColor);

                entryBorderless.Unfocus();

                if (animated)
                {
                    await Task.WhenAll(
                        placeholderText.TranslateTo(0, 0, 100, Easing.Linear),
                        entryBorderless.TranslateTo(0, 0, 100, Easing.Linear),
                        TranslateToColor(PlaceholderColor),
                        TranslateToFontSize(16)
                    );
                }
                else
                {
                    placeholderText.TranslationY = 0;
                    placeholderText.TextColor = TextColor;
                    placeholderText.FontSize = 16;
                    entryBorderless.TranslationY = 0;
                }
            }
        }

        private Task TranslateToFontSize(int fontSize)
        {
            var taskCompletionSource = new TaskCompletionSource<bool>();

            Action<double> callback = size => { placeholderText.FontSize = size; };
            double startingHeight = placeholderText.FontSize;
            double endingHeight = fontSize;
            uint rate = 5;
            uint length = 100;
            Easing easing = Easing.Linear;

            placeholderText.Animate(
                "ToFontSize",
                callback,
                startingHeight,
                endingHeight,
                rate,
                length,
                easing,
                (v, c) => taskCompletionSource.SetResult(c)
            );

            return taskCompletionSource.Task;
        }

        private Task TranslateToColor(Color color)
        {
            var taskCompletionSource = new TaskCompletionSource<bool>();

            Action<Color> callback = callbackColor => { placeholderText.TextColor = callbackColor; };
            Color startingColor = placeholderText.TextColor;
            Color endingColor = color;
            uint rate = 5;
            uint length = 100;
            Easing easing = Easing.Linear;

            Color transform(double t) =>
            Color.FromRgba(startingColor.R + t * (endingColor.R - startingColor.R),
            startingColor.G + t * (endingColor.G - startingColor.G),
            startingColor.B + t * (endingColor.B - startingColor.B),
            startingColor.A + t * (endingColor.A - startingColor.A));

            placeholderText.Animate(
                "ToColor",
                transform,
                callback,
                rate,
                length,
                easing,
                (v, c) => taskCompletionSource.SetResult(c)
            );

            return taskCompletionSource.Task;
        }
    }
}