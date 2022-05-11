using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace StartApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnDateTime_Click(object sender, RoutedEventArgs e)
        {
            
            var filename = @"E:\LearnToCode\Codebase\CSharp\DailyDotNET\Language\Syntax\DateTimeType\bin\Debug\net5.0\DateTimeEssentials.exe";
            InvokeMyfile(filename);
        }

        public void InvokeMyfile(string filename)
        {
            Process proc = new Process();
            proc.StartInfo.FileName = filename;
            proc.Start();
        }

        private void btnNumbers_Click(object sender, RoutedEventArgs e)
        {
            var filename = @"E:\LearnToCode\Codebase\CSharp\DailyDotNET\Language\Syntax\Numbers\bin\Debug\net5.0\Numbers.exe";
            InvokeMyfile(filename);
        }

   

        private void btnString_Click(object sender, RoutedEventArgs e)
        {
            var filename = @"E:\LearnToCode\Codebase\CSharp\DailyDotNET\Language\Syntax\StringEssentials\bin\Debug\net5.0\StringEssentials.exe";
            InvokeMyfile(filename);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var filename = @"E:\LearnToCode\Codebase\CSharp\DailyDotNET\Language\Syntax\Currency\bin\Debug\net5.0\Currency.exe";
            InvokeMyfile(filename);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var filename = @"E:\LearnToCode\Codebase\CSharp\DailyDotNET\Language\Syntax\LINQ-where\bin\Debug\net5.0\LINQ-ExtensionMethods.exe";
            InvokeMyfile(filename);
        }
    }
}
