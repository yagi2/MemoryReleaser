using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using System.IO;
using System.Diagnostics;

namespace MemoryReleaser
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        private System.Diagnostics.PerformanceCounter MemF = null;

        public MainWindow()
        {
            InitializeComponent();

            this.MouseLeftButtonDown += (sender, e) => this.DragMove();

            MemF = new System.Diagnostics.PerformanceCounter();
            MemF.CategoryName = "Memory";
            MemF.CounterName = "Available MBytes";
            MemF.NextValue();
            if (MemF != null)
            {
                StatusLabel.Content = "FreeMemory: " + MemF.NextValue() + "MB";
            }
        }

        void FreeButtonOver(object sender, RoutedEventArgs e)
        {
            IntroLabel.Content = "メモリを開放します";
        }

        void FreeButtonLeave(object sender, RoutedEventArgs e)
        {
            IntroLabel.Content = " ";
        }

        void PIDButtonOver(object sender, RoutedEventArgs e)
        {
            IntroLabel.Content = "プロセスIDを指定します";
        }

        void PIDButtonLeave(object sender, RoutedEventArgs e)
        {
            IntroLabel.Content = " ";
        }

        void PNAMEButtonOver(object sender, RoutedEventArgs e)
        {
            IntroLabel.Content = "イメージ名を指定します";
        }

        void PNAMEButtonLeave(object sender, RoutedEventArgs e)
        {
            IntroLabel.Content = " ";
        }

        void Hidden_Button_DoubleClick(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        void Free_Button_Click(object sender, RoutedEventArgs e)
        {
            MemF = new System.Diagnostics.PerformanceCounter();
            MemF.CategoryName = "Memory";
            MemF.CounterName = "Available MBytes";

            if (MemF != null)
            {
                Before_Label.Content = MemF.NextValue() + " MB";
            }

            string program = @"C:\Windows\System32\empty.exe";
            string argument = @"*";

            Process extProcess = new Process();

            extProcess.StartInfo.FileName = Environment.GetEnvironmentVariable("ComSpec");
            extProcess.StartInfo.CreateNoWindow = true;
            extProcess.StartInfo.UseShellExecute = false;
            extProcess.StartInfo.RedirectStandardInput = false;
            extProcess.StartInfo.RedirectStandardOutput = true;
            extProcess.StartInfo.FileName = program;
            extProcess.StartInfo.Arguments = argument;

            extProcess.Start();

            string output = extProcess.StandardOutput.ReadToEnd();
            extProcess.WaitForExit();
            InfoLabel.Content = output;

            MemF = new System.Diagnostics.PerformanceCounter();
            MemF.CategoryName = "Memory";
            MemF.CounterName = "Available MBytes";
            MemF.NextValue();

            if (MemF != null)
            {
                After_Label.Content = MemF.NextValue() + " MB";
                StatusLabel.Content = "FreeMemory: " + MemF.NextValue() + "MB";

            }

        }

        void PID_Button_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        void PNAME_Button_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        void Click_Close(object sender, RoutedEventArgs e)
        {
            this.Close();   
        }

        void Click_Min(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

    }
}
