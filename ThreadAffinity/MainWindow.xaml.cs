using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ThreadAffinity
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Task.Factory.StartNew(ChangeText);
        }

        private void ChangeText()
        {
            Thread.Sleep(2500);
            UpdateText("changed text");
        }

        private void UpdateText(string text)
        {
            //// txtMessage.Text = text;
            /// System.InvalidOperationException
            /// Message = The calling thread cannot access this object because a different thread owns it.

            Dispatcher.Invoke(() => { txtMessage.Text = text; });
        }
    }
}
