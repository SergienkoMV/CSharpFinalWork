using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FinalTaskV2.FileSystem
{
    // + 2.Сервис должен реализовывать интерфейс ISaveLoadService
    // + 3.	Сервис FileSystemSaveLoadService
    // + a.Реализует интерфейс ISaveLoadService с параметром string
    public class FileSystemSaveLoadService<T> : ISaveLoadService<string>
    {
        //private string ;
        //private string[] profiles;
        //Dictionary<string, int>[] profiles;
        private string _path;
        //b.Публичный конструктор, принимающий строку - путь, куда будут сохраняться данные и откуда они будут загружаться.
        public FileSystemSaveLoadService(string path)
        {
            _path = path;
        }

        public void SaveData(string data, string fileName)
        {
            //Расширение у файла может быть любым, однако рекомендуется использовать .txt
            //var file = Path.Combine(_path, fileName + ".txt");
            if (CheckExist(GetPath(fileName)))
            {
                using (StreamWriter readStream = File.CreateText(GetPath(fileName)))
                {
                    readStream.WriteLine(data);
                }
            } 
            else
            {
                using (StreamWriter readStream = File.CreateText(GetPath(fileName)))
                {
                    readStream.WriteLine(data);
                }
            }
        }


        public string LoadData(string fileName) //пыпытаться переделать в generic, если не получится, убрать generic в интерфейсе
        {
            if (CheckExist(fileName))
            {
                using var writeStreem = File.OpenText(GetPath(fileName));
                return writeStreem.ReadToEnd();
            }
            return "";
        }

        public T1 LoadData<T1>(string path)
        {
            throw new NotImplementedException();
        }

        private bool CheckExist(string fileName)
        {
            return File.Exists(GetPath(fileName));
        }
        private string GetPath(string fileName)
        {
            return Path.Combine(_path, fileName + ".txt");
        }

        //T1 ISaveLoadService<string>.LoadData<T1>(string fileName)
        //{
        //    //Расширение у файла может быть любым, однако рекомендуется использовать .txt
        //    fileName = fileName + ".txt";

        //    try
        //    {
        //        //пытаемся считать файл
        //    }
        //    catch
        //    {
        //        //выдаем что профиля нет, если не получилось считать.
        //    }


        //    return "test";

        //}
    }
}
