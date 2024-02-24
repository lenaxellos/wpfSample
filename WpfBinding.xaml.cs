using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
using System.Windows.Shapes;
using static System.Net.WebRequestMethods;

namespace wpfSample
{
    /// <summary>
    /// Binding.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class WpfBinding : Window
    {
        MyFile myFile = new MyFile();
        string[] files = { };

        public WpfBinding()
        {
            InitializeComponent();                       

            //2.ElemnetName C# code Binding
            codeBinding();

            //3.Property binding
            this.DataContext = myFile;            
        }

        //2.ElemnetName C# code Binding
        private void codeBinding()
        {
            Binding binding = new Binding();
            binding.Source = txtBox2;                               //원본소스 지정
            binding.Path = new PropertyPath(TextBox.TextProperty);  //원본소스의 Property지정
            txtBL2.SetBinding(TextBlock.TextProperty, binding);     //타겟에 binding       
        }

        private void GetfolderFilesName(string folderName)
        {
            files = Directory.GetFiles(folderName);

            foreach (string file in files)
            {
                myFile.MyFileName = file;
                cbofiles.Items.Add(file);
            }

            cbofiles.SelectedIndex = 0;            
        }

        private void BTNComboSelect_Click(object sender, RoutedEventArgs e)
        {
            GetfolderFilesName(@"C:\Users\lenax\Downloads\PC-20240223T133738Z-001\PC");
        }
    }

    //3.Property binding - 알림 통보
    class Notifier : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    //3.Property binding - 파일명 설정
    class MyFile : Notifier
    {
        private string _fileName;

        public string MyFileName
        {
            get { return _fileName; }
            set
            {
                _fileName = value;
                OnPropertyChanged("MyFileName");
            }
        }
    }
}
