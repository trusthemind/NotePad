using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace everyday.Saves
{
    internal class Todo: INotifyPropertyChanged
    {
        //зараз
        public DateTime CreationDate { get; set; } = DateTime.Now;

        private bool _IsDone;
        private string _text;

        public  bool IsDone 
        {
            get { return _IsDone; }
            set 
            { 
                _IsDone = value;
                OnPropertyChanged("IsDone");
            }
        }

        public string Text {
            get { return _text; }
            set 
            {
                
                _text = value;
                OnPropertyChanged("Text");
            } 
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName = "")
        {
            if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
