using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        ObservableCollection<MyFile2> myFile2s = new ObservableCollection<MyFile2>();

        string[] files = { };

        public WpfBinding()         //Main함수
        {
            InitializeComponent();                       

            //2.ElemnetName C# code Binding
            codeBinding();

            //3.Property binding - INotifyPropertyChanged 사용 통보알림
            this.DataContext = myFile;
        }

        #region //2.ElemnetName C# code Binding        
        private void codeBinding()
        {
            Binding binding = new Binding();
            binding.Source = txtBox2;                               //원본소스 지정
            binding.Path = new PropertyPath(TextBox.TextProperty);  //원본소스의 Property지정
            txtBL2.SetBinding(TextBlock.TextProperty, binding);     //타겟에 binding                                                                   
        }
        #endregion

        #region//3.Property binding - INotifyPropertyChanged 사용 통보알림
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
        #endregion

        #region //4.ObservableCollection - 컬렉션 타입 통보알림    
        private ObservableCollection<MyFile2> GetFileNames()
        {
            myFile2s.Clear();

            files = Directory.GetFiles(@"E:\Study\Book");

            foreach (string file in files)
            {
                myFile2s.Add(new MyFile2(file));                
            }

            return myFile2s;
        }        

        private void BTNListSelect_Click(object sender, RoutedEventArgs e)
        {            
            listBox4.ItemsSource = GetFileNames();
        }
        #endregion
    }

    #region //3.Property binding - 파일명 설정    
    class Notifier : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    
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
    #endregion

    #region //4.ObservableCollection - 컬렉션 타입 통보알림    
    class MyFile2
    {
        private string _fileName;

        public string MyFileName2
        {
            get { return _fileName; }
            set
            {
                _fileName = value;                
            }
        }
        
        public MyFile2(string fileName)
        {
            this.MyFileName2 = fileName;
        }
    }
    #endregion
}
