using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace TreeViewCustomized
{
    public class MyDataContext : INotifyPropertyChanged
    {
        public MyDataContext()
        {
            Persons = new List<Person>()
            {
                new Person
                {
                    Name = "テスト１",
                    Children = new List<Person>()
                    {
                        new Person{ Name = "てすと２"},
                        new Person{ Name = "てすと３"},
                    }
                },
                new Person
                {
                    Name = "ほげ",
                    Children = new List<Person>()
                    {
                        new Person{ Name = "foo" },
                        new Person{
                            Name = "bar",
                            Children = new List<Person>
                            {
                                new Person{ Name = "test" }
                            }
                        }
                    }
                }
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged( [CallerMemberName] string name = null )
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        private bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null )
        {
            if (object.Equals(storage, value))
                return false;
            storage = value;
            this.RaisePropertyChanged(propertyName);
            return true;
        }

        private IEnumerable<Person> _persons;
        public IEnumerable<Person> Persons
        {
            get { return _persons; }
            private set {
                SetProperty(ref _persons, value);
            }
        }

        private string _testName = "ほげほげ";
        public string TestName { get { return _testName; } }
    }

    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

    }

    public class Person
    {
        public string Name { get; set; }
        public List<Person> Children { get; set; }
    }
}
