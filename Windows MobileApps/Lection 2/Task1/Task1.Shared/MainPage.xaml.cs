using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Task1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private int counter;

        public MainPage()
        {
            this.InitializeComponent();
            this.counter = 0;
        }

        private void Button_GetText_Click(object sender, RoutedEventArgs e)
        {
            this.counter++;
            this.textBlockResult.Text = this.textBoxImportant.SelectedText;
            this.textBlockCounter.Text = this.counter.ToString();
            this.comboBoxResult.Items.Add(string.Format("Item {0}", this.counter));
        }
    }
}
