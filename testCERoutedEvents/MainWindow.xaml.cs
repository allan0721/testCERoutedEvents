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

namespace testCERoutedEvents
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CustomControl1 theCC = new CustomControl1();
            MainGrid.Children.Add(theCC);
            theCC.RaiseCustomControlEvent += theCC_RaiseCustomControlEvent;
        }

        void theCC_RaiseCustomControlEvent(object sender , EventArgs e)
        {
            MessageBox.Show(@"Made it!");
        }

    } 
}
