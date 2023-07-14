using PersonMvvm.Commands;
using PersonMvvm.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PersonMvvm.ViewModels
{
    public class PersonViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }

        PersonService ObjPersonService;
        public PersonViewModel()
        {
            ObjPersonService = new PersonService();
            Load();

            CurrentPerson = new Person();
            saveCommand = new RelayCommand(Save);
            loadCommand = new RelayCommand(Load);

            SelectedPerson = new Person();
            editCommand = new RelayCommand(Edit);

            deleteCommand = new RelayCommand(Delete);
            searchCommand = new RelayCommand(Search);

            currentPage = 1;
            PageSize = 10;
            previousPageCommand = new RelayCommand(PreviousPage);
            nextPageCommand = new RelayCommand(NextPage);

            clearCommand = new RelayCommand(Clear);
        }

        private int pageSize = 10;
        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value; OnPropertyChanged("PageSize"); }
        }

        private int currentPage = 1;
        public int CurrentPage
        {
            get { return currentPage; }
            set { currentPage = value; OnPropertyChanged("CurrentPage"); }
        }

        private int totalItems;
        public int TotalItems
        {
            get { return totalItems; }
            set { totalItems = value; OnPropertyChanged("TotalItems"); }
        }

        private int totalPages;
        public int TotalPages
        {
            get { return totalPages; }
            set { totalPages = value; OnPropertyChanged("TotalPages"); }
        }

        private ObservableCollection<Person> personList;
        public ObservableCollection<Person> PersonList
        {
            get { return personList; }
            set { personList = value; OnPropertyChanged("PersonList"); }
        }

        private Person currentPerson;
        public Person CurrentPerson
        {
            get { return currentPerson; }
            set { currentPerson = value; OnPropertyChanged("CurrentPerson"); }
        }

        private Person selectedPerson;
        public Person SelectedPerson
        {
            get { return selectedPerson; }
            set { selectedPerson = value; OnPropertyChanged("SelectedPerson"); }
        }

        private bool hasPreviousPage;
        public bool HasPreviousPage
        {
            get { return hasPreviousPage; }
            set
            {
                hasPreviousPage = value;
                OnPropertyChanged("HasPreviousPage");
            }
        }

        private bool hasNextPage;
        public bool HasNextPage
        {
            get { return hasNextPage; }
            set { hasNextPage = value; OnPropertyChanged("HasNextPage"); }
        }
        private async Task LoadData()
        {
            int pageNumber = CurrentPage;
            int pageSize = PageSize;

            List<Person> persons = await ObjPersonService.GetAllAsync(pageNumber, pageSize);
            PersonList = new ObservableCollection<Person>(persons);
            TotalItems = await ObjPersonService.GetTotalCountAsync();
            TotalPages = (int)Math.Ceiling((double)TotalItems / PageSize);
            UpdatePagination();
        }
        private void UpdatePagination()
        {
            HasPreviousPage = CurrentPage > 1;
            HasNextPage = CurrentPage < TotalPages;
            HasData = (PersonList.Count > 0);
        }

        private RelayCommand nextPageCommand;
        public  RelayCommand NextPageCommand
        {
            get { return  nextPageCommand; }
            set {  nextPageCommand = value; }
        }

        public void NextPage()
        {
            if(CurrentPage < TotalPages)
            {
                CurrentPage++;
                Load();
            }
        }

        private RelayCommand previousPageCommand;
        public RelayCommand PreviousPageCommand
        {
            get { return previousPageCommand; }
            set { previousPageCommand = value; }
        }

        public void PreviousPage()
        {
            if(CurrentPage>1)
            {
                CurrentPage--;
                Load();
            }
        }

        private RelayCommand saveCommand;
        public RelayCommand SaveCommand
        {
            get { return saveCommand; }
        }
        private void Save()
        {
            if (currentPerson.PersonId == 0)
            {
                var IsSaved = ObjPersonService.Add(CurrentPerson);
                if (IsSaved)
                {
                    MessageBox.Show("Person details saved", "Success", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
                else
                {
                    MessageBox.Show("Person details failed to save", "Failed", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
            }
            else
            {
                var IsUpdated = ObjPersonService.Update(CurrentPerson);
                if (IsUpdated)
                {
                    MessageBox.Show("Person details updated", "Success", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
                else
                {
                    MessageBox.Show("Person details failed to update", "Failed", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
            }
        }
        private bool hasData;
        public bool HasData
        {
            get { return hasData; }
            set { hasData = value; OnPropertyChanged("HasData"); }
        }

        private RelayCommand clearCommand;
        public RelayCommand ClearCommand
        {
            get { return clearCommand; }
            set { clearCommand = value;}
        }
        private void Clear()
        {
            PersonList.Clear();
            TotalItems = 0;
            TotalPages = 0;
            CurrentPage = 1;
            UpdatePagination();
        }

        private RelayCommand loadCommand;
        public RelayCommand LoadCommand
        {
            get { return loadCommand; }
        }
        public void Load()
        {
            Task task = LoadData();
        }

        private RelayCommand editCommand;
        public RelayCommand EditCommand
        {
            get { return editCommand; }
            set { editCommand = value; OnPropertyChanged("EditCommand"); }
        }
        public void Edit()
        {
            if (SelectedPerson != null)
            {
                CurrentPerson = SelectedPerson;
            }
        }

        private RelayCommand deleteCommand;
        public RelayCommand DeleteCommand
        {
            get { return deleteCommand; }
            set { deleteCommand = value; OnPropertyChanged("DeleteCommand"); }
        }

        public void Delete()
        {
            if (MessageBox.Show("Confirm Delete of this Record ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                var IsDeleted = ObjPersonService.Delete(SelectedPerson.PersonId);
                if (IsDeleted)
                {
                    MessageBox.Show("Details deleted", "Success", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    Load();
                }
                else
                {
                    MessageBox.Show("Details failed to delete", "Failed", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
            }
        }

        private RelayCommand searchCommand;
        public RelayCommand SearchCommand
        {
            get { return searchCommand; }
            set { searchCommand = value; }
        }

        private string searchText;
        public string SearchText
        {
            get { return searchText; }
            set { searchText = value; OnPropertyChanged("SearchText"); }
        }
        private async void Search()
        {
            if (string.IsNullOrEmpty(searchText))
            {
                Load();
                return;
            }
            else if (SearchText.All(char.IsDigit))
            {
                var objPerson = await ObjPersonService.Search(Convert.ToInt32(SearchText));
                if (objPerson != null && objPerson.Count() > 0)
                {
                    PersonList = new ObservableCollection<Person>(objPerson);
                }
                else
                {
                    PersonList = null;
                    MessageBox.Show("Student not found", "Failed", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
            }
        }
    }
}
