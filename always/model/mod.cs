using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace always.model
{
    internal class mod: INotifyPropertyChanged
    {
        private bool trf;
        private string text;
        private string cmdt;

        public DateTime CretiveDate { get; set; } = DateTime.Now;
        public string CompletionDate
        {
            get { return cmdt; }
            set
            {
                if (cmdt == value) return;
                cmdt = value;
                on_prop("TF");
            }
        }
        public bool TF
        {
            get { return trf; }
            set 
            { 
                if (trf == value)  return; 
                trf = value;
                on_prop("TF");
            }
        }
        public string Plans
        {
            get { return text; }
            set 
            {
                if (text == value)  return; 
                text = value;
                on_prop("Plans");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void on_prop(string propName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
