using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace VanillaWPF.Controls
{
    /// <summary>
    /// Interaction logic for FileInputBox.xaml
    /// </summary>
    public partial class FileInputBox : UserControl
    {

        public static readonly DependencyProperty FileNameProperty =
            DependencyProperty.Register("FileName", typeof(string), typeof(FileInputBox));

        public string FileName
        {
            get { return (string)GetValue(FileNameProperty); }
            set { SetValue(FileNameProperty, value); }
        }

        public static readonly RoutedEvent FileNameChangedEvent = 
            EventManager.RegisterRoutedEvent("FileNameChanged", RoutingStrategy.Bubble, 
                typeof(RoutedEventHandler), typeof(FileInputBox));

        public event RoutedEventHandler FileNameChanged
        {
            add { AddHandler(FileNameChangedEvent, value); }
            remove { RemoveHandler(FileNameChangedEvent, value);}
        }

        public FileInputBox()
        {
            InitializeComponent();
           
        }

        private void theButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog d = new OpenFileDialog();
            if (d.ShowDialog() == true)
            {
                FileName = d.FileName;
            }
        }

        private void theTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            e.Handled = true;
            RoutedEventArgs routedEventArgs = new RoutedEventArgs(FileNameChangedEvent);
            RaiseEvent(routedEventArgs);
        }

    }
}
