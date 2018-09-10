using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using Prism.Commands;

namespace WpfPaging.ViewModel
{
    public class MainWindowVM : BindableBase
    {
        public MainWindowVM()
        {
            InitCommand();
            InitData();
        }


        private List<DataGridListModel> _ItemsSourceList;
        private int _PageCount = 1;      
        private int _CurrentPage = 1;   
        private int _TotalNum = 0;     
        private int _GotoPageNum = 1;  


        public List<DataGridListModel> List { get; set; }
        public List<DataGridListModel> ItemsSourceList { get => _ItemsSourceList; set { _ItemsSourceList = value; RaisePropertyChanged("ItemsSourceList"); } }
        public int PageCount { get => _PageCount; set { _PageCount = value; RaisePropertyChanged("PageCount"); } }
        public int PageSize { get; set; }
        public int CurrentPage { get => _CurrentPage; set { _CurrentPage = value; RaisePropertyChanged("CurrentPage"); } }
        public int TotalNum { get => _TotalNum; set { _TotalNum = value; RaisePropertyChanged("TotalNum"); } }
        public int GotoPageNum { get => _GotoPageNum; set { _GotoPageNum = value; RaisePropertyChanged("GotoPageNum"); } }

         
        public DelegateCommand FirstPageCommand { get; set; }
        public DelegateCommand PreviousPageCommand { get; set; }
        public DelegateCommand NextPageCommand { get; set; }
        public DelegateCommand LastPageCommand { get; set; }
        public DelegateCommand GotoPageCommand { get; set; }
        public DelegateCommand PageChangedCommand { get; set; }
        public DelegateCommand PageSizeChangedCommand { get; set; }

        private void InitCommand()
        {
            FirstPageCommand = new DelegateCommand(OnFirstPageCommand);
            PreviousPageCommand = new DelegateCommand(OnPreviousPageCommand);
            NextPageCommand = new DelegateCommand(OnNextPageCommand);
            LastPageCommand = new DelegateCommand(OnLastPageCommand);
            GotoPageCommand = new DelegateCommand(OnGotoPageCommand);
            PageChangedCommand = new DelegateCommand(OnPageChangedCommand);
            PageSizeChangedCommand = new DelegateCommand(OnPageSizeChangedCommand);
        }

        private void InitData()
        {
            List = new List<DataGridListModel>();
            for (int i = 0; i < 1000; i++)
            {
                List.Add(new DataGridListModel { ID = i, Name = i.ToString() });
            }
            TotalNum = List.Count;
        }

        private void OnFirstPageCommand()
        {
            RefreshPage();
        }
        private void OnPreviousPageCommand()
        {
            RefreshPage();
        }
        private void OnNextPageCommand()
        {
            RefreshPage();
        }
        private void OnLastPageCommand()
        {
            RefreshPage();
        }
        private void OnGotoPageCommand()
        {
            RefreshPage();
        }
        private void OnPageChangedCommand()
        {
            RefreshPage();
        }
        private void RefreshPage()
        {
            ItemsSourceList = List.Where(x => x.ID >= (CurrentPage - 1) * PageSize && x.ID < CurrentPage * PageSize).ToList();
        }
        private void OnPageSizeChangedCommand()
        {
            if (List.Count % PageSize == 0)
            {
                PageCount = List.Count / PageSize;
            }
            else
            {
                PageCount = List.Count / PageSize + 1;
            }
            RefreshPage();
        }
    }
    public class DataGridListModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
