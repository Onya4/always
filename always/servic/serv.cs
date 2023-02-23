using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using always.model;
using Newtonsoft.Json;

namespace always.servic
{
    internal class serv
    {
        private readonly string Fi1e;
        public serv(string file)
        {
            Fi1e = file;
        }
        public BindingList<mod> load()
        {
            var fileExists = File.Exists(Fi1e);
            if (!fileExists) 
            {
                File.CreateText(Fi1e).Dispose();
                return new BindingList<mod>();
            }
            using (var reader = File.OpenText(Fi1e))
            {
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<BindingList<mod>>(fileText);
            }
        }
        public void saved(object isdate) 
        {
            using (StreamWriter write = File.CreateText(Fi1e))
            {
                string output = JsonConvert.SerializeObject(isdate);
                write.WriteLine(output);
            }
        }
    }
}
