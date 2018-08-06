using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Diagnostics;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace week5_hw
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hello");
        }

        private void process_Click(object sender, EventArgs e)
        {
            Process[] activeProcs = Process.GetProcesses();
            foreach(Process p in activeProcs)
            {
                //    ListViewItem item = new ListViewItem(p.ProcessName);
                var row = new { pPID = p.Id, Name = p.ProcessName};
                listView.Items.Add(row);
            }
           
        }
        
        // Load the modules for a specific process by PID
        //
        //
        //
        private void module_Click(object sender, EventArgs e)
        {
            Process m_process = Process.GetCurrentProcess();
            ProcessModuleCollection moduleCollection = m_process.Modules;

            string modules = string.Empty;

            foreach( ProcessModule m in moduleCollection)
            {
                modules = string.Format("Module Name: {0}", m.ModuleName);
                list_Box_L.Items.Add(modules);
            }

           
          //  MessageBox.Show(modules);

        }



        private void button1_Click(object sender, EventArgs e)
        {
            Process procces = Process.GetCurrentProcess();
            ProcessThreadCollection threadCollection = procces.Threads;

            string threads = string.Empty;

            foreach (ProcessThread proccessThread in threadCollection)
            {
                threads += string.Format("Thread Id: {0}, ThreadState: {1}\r\n", proccessThread.Id, proccessThread.ThreadState);
            }

            MessageBox.Show(threads);
        }




        private void thread_Click(object sender, EventArgs e)
        {
            Process procces = Process.GetCurrentProcess();
            ProcessThreadCollection threadCollection = procces.Threads;

            string threads = string.Empty;

            foreach (System.Diagnostics.ProcessThread proccessThread in threadCollection)
            {
                threads = string.Format("Thread Id: {0}, ThreadState: {1}\r\n", proccessThread.Id, proccessThread.ThreadState);
                list_Box_R.Items.Add(threads);
            }

        
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ListProcess_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

