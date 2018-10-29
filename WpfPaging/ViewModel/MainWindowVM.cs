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
        private int _Total;


        public List<DataGridListModel> List { get; set; }
        public List<DataGridListModel> ItemsSourceList { get => _ItemsSourceList; set { _ItemsSourceList = value; RaisePropertyChanged("ItemsSourceList"); } }
        //public int PageCount { get ; set ; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int Total { get => _Total; set { _Total = value; RaisePropertyChanged("Total"); } }
        //public int GotoPageNum { get ; set ; }

        public DelegateCommand PageChangedCommand { get; set; }
        //public DelegateCommand PageSizeChangedCommand { get; set; }

        private void InitCommand()
        {
            PageChangedCommand = new DelegateCommand(OnPageChangedCommand);
            //PageSizeChangedCommand = new DelegateCommand(OnPageSizeChangedCommand);
        }

        private void InitData()
        {
            List = new List<DataGridListModel>();
            for (int i = 0; i < 1000; i++)
            {
                List.Add(new DataGridListModel { ID = i, Name = i.ToString() });
            }
            Total = List.Count;
        }
        private void OnPageChangedCommand()
        {
            RefreshPage();
        }
        //private void OnPageSizeChangedCommand()
        //{
        //    RefreshPage();
        //}
        private void RefreshPage()
        {
            if (List != null)
            {
                ItemsSourceList = List.Where(x => x.ID >= (CurrentPage - 1) * PageSize && x.ID < CurrentPage * PageSize).ToList();
            }
        }

    }
    public class DataGridListModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
