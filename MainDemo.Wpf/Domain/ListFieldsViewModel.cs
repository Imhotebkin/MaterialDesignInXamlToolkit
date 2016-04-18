using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Input;

namespace MaterialDesignColors.WpfExample.Domain
{
    public class TestClass
    {
        string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public TestClass(string s)
        {
            Name = s;
        }
    }

    public class ListsAndGridsViewModel : INotifyPropertyChanged
    {
        private readonly ObservableCollection<SelectableViewModel> _items1;
        private readonly ObservableCollection<SelectableViewModel> _items2;
        private readonly ObservableCollection<SelectableViewModel> _items3;
        private bool? _isAllItems3Selected;
        

        public ListsAndGridsViewModel()
        {
            _items1 = CreateData();
            _items2 = CreateData();
            _items3 = CreateData();
            collectionA = new ObservableCollection<TestClass>();
            collectionB = new ObservableCollection<TestClass>();
            collectionA.Add(new TestClass("one"));
            collectionA.Add(new TestClass("two"));
            collectionA.Add(new TestClass("three"));
            collectionB.Add(new TestClass("one"));
            collectionB.Add(new TestClass("two"));
            collectionB.Add(new TestClass("three"));
            Click = new AnotherCommandImplementation(Clear);
        }

        public bool? IsAllItems3Selected
        {
            get { return _isAllItems3Selected; }
            set
            {
                if (_isAllItems3Selected == value) return;

                _isAllItems3Selected = value;

                if (_isAllItems3Selected.HasValue)
                    SelectAll(_isAllItems3Selected.Value, Items3);

                OnPropertyChanged();
            }
        }

        private void SelectAll(bool select, IEnumerable<SelectableViewModel> models)
        {
            foreach (var model in models)
            {
                model.IsSelected = select;
            }
        }

        private static ObservableCollection<SelectableViewModel> CreateData()
        {
            return new ObservableCollection<SelectableViewModel>
            {
                new SelectableViewModel
                {
                    Code = 'M',
                    Name = "Material Design",
                    Description = "Material Design in XAML Toolkit"
                },
                new SelectableViewModel
                {
                    Code = 'D',
                    Name = "Dragablz",
                    Description = "Dragablz Tab Control",
                    Food = "Fries"
                },
                new SelectableViewModel
                {
                    Code = 'P',
                    Name = "Predator",
                    Description = "If it bleeds, we can kill it"
                }
            };
        }

        public ObservableCollection<SelectableViewModel> Items1
        {
            get { return _items1; }
        }

        public ObservableCollection<TestClass> collectionA { get; set; }

        public ObservableCollection<TestClass> collectionB { get; set; }

        public ObservableCollection<SelectableViewModel> Items2
        {
            get { return _items2; }
        }

        public ObservableCollection<SelectableViewModel> Items3
        {
            get { return _items3; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public IEnumerable<string> Foods
        {
            get
            {
                yield return "Burger";
                yield return "Fries";
                yield return "Shake";
                yield return "Lettuce";
            }            
        }

        public ICommand Click
        {
            get;set;
        }

        void Clear(object obj)
        {
            collectionA.Clear();
            collectionB.Clear();
        }
    }
}