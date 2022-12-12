using everyday.Saves;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace everyday.Servises;

internal class FileIOService
{
    private readonly string PATH;

    public FileIOService(string path)
    {
        PATH = path;
    }
    public BindingList<Todo> LoadData()
    {
        var fileExists = File.Exists(PATH);
        //Check
        if (!fileExists)
        {
            File.CreateText(PATH).Dispose();
            return new BindingList<Todo>();
        }
        using (var reader = File.OpenText(PATH))
        {
        var FileText = reader.ReadToEnd();
        return JsonConvert.DeserializeObject<BindingList<Todo>>(FileText);
        }
    }
    

    public void SaveData(object TodoList)
    {
        using (StreamWriter writer = File.CreateText(PATH))
        {

            string output = JsonConvert.SerializeObject(TodoList);
            writer.Write(output);
        }
    }
}
