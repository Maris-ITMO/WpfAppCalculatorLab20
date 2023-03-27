using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using WpfAppCalculatorLab20.Models;

namespace WpfAppCalculatorLab20.ViewModels
{
    public class CalculatorViewModel : INotifyPropertyChanged
    {
        public CalculatorViewModel()
        {
            NumberButtonCommand = new RelayCommand(OnNumberButtonCommandExecute, null); 
            OperButtonCommand = new RelayCommand(OnOperButtonCommandExecute, null);           
            CalculatorButtonCommand = new RelayCommand(OnCalculatorButtonCommandExecute, null);  
        }

        // Событие
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Поле для вывода
        private string strData = "";
        public string StrData
        {
            get => strData;
            set
            {               
                strData = value;               
                OnPropertyChanged();
            }
        }

        //Команда для цифрового набора
        public ICommand NumberButtonCommand { get; }       

        private void OnNumberButtonCommandExecute(object p)
        {            
            StrData +=  (p as Button).Content.ToString();
        }

        //Команда выбора операций       
        public ICommand OperButtonCommand { get; }
        private void OnOperButtonCommandExecute(object p)
        {
            StrData += (p as Button).Content.ToString();
        }

        //Команда для расчета
        public ICommand CalculatorButtonCommand { get; }
        private void OnCalculatorButtonCommandExecute(object p)
        {
            StrData = new DataTable().Compute(StrData,null).ToString();           
        }
    }
}
