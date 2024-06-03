using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using SetApp.Models;

namespace SetApp.ViewModels
{
    public class SetViewModel<T> : INotifyPropertyChanged
    {
        private Set<T> _set;
        private ObservableCollection<T> _items;
        private T? _currentItem;
        private string _containsResult; // Новое свойство для результата проверки
        private ICommand _addCommand;
        private ICommand _removeCommand;
        private ICommand _clearCommand;
        private ICommand _containsCommand;

        public SetViewModel()
        {
            _set = new Set<T>();
            _items = new ObservableCollection<T>(_set.ToArray());
            _currentItem = default(T);
            _containsResult = string.Empty;
            _addCommand = new RelayCommand(AddItem);
            _removeCommand = new RelayCommand(RemoveItem);
            _clearCommand = new RelayCommand(ClearItems);
            _containsCommand = new RelayCommand(ContainsItem);
        }

        public ObservableCollection<T> Items
        {
            get => _items;
            set
            {
                _items = value;
                OnPropertyChanged();
            }
        }

        public T? CurrentItem
        {
            get => _currentItem;
            set
            {
                _currentItem = value;
                OnPropertyChanged();
            }
        }

        public string ContainsResult
        {
            get => _containsResult;
            set
            {
                _containsResult = value;
                OnPropertyChanged();
            }
        }

        public int Count => _set.Count;

        public bool IsEmpty => _set.IsEmpty;

        public ICommand AddCommand => _addCommand;
        public ICommand RemoveCommand => _removeCommand;
        public ICommand ClearCommand => _clearCommand;
        public ICommand ContainsCommand => _containsCommand;

        private void AddItem(object? parameter)
        {
            if (parameter is T item)
            {
                _set.Add(item);
                UpdateItems();
            }
        }

        private void RemoveItem(object? parameter)
        {
            if (parameter is T item)
            {
                _set.Remove(item);
                UpdateItems();
            }
        }

        private void ClearItems(object? parameter)
        {
            _set.Clear();
            UpdateItems();
        }

        private void ContainsItem(object? parameter)
        {
            if (parameter is T item)
            {
                bool result = _set.Contains(item);
                ContainsResult = result ? "Item exists in the set" : "Item does not exist in the set";
            }
            else
            {
                ContainsResult = "Invalid item";
            }
        }

        private void UpdateItems()
        {
            Items = new ObservableCollection<T>(_set.ToArray());
            OnPropertyChanged(nameof(Count));
            OnPropertyChanged(nameof(IsEmpty));
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}