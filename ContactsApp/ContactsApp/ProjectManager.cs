using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace ContactsApp
{
    /// <summary>
    /// Класс, реализующий сохранение данных в файл и загрузки из него.
    /// </summary>
    public class ProjectManager
    {
        /// <summary>
        /// Стандартный путь к файлу.
        /// </summary>
        public static readonly string stringMyDocumentsPath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\ContactsApp\";//переместить ссылку на сохранение в myDocuments или APPDATA

        /// <summary>
        /// Метод, выполняющий запись в файл 
        /// </summary>
        /// <param name="contact">Экземпляр проекта для сериализации</param>
        /// <param name="fileContactAppPath">Путь к файлу</param>
        public static void SaveToFile(Project contact)
        {
            // Экземпляр сериалиатора
            JsonSerializer serializer = new JsonSerializer();

            var directoryFileContactApp = System.IO.Path.GetDirectoryName(stringMyDocumentsPath);

            //Проверка на папку. Если нет папки ContactsApp, то создаем ее.
            if (!System.IO.Directory.Exists(directoryFileContactApp))
            {
                Directory.CreateDirectory(directoryFileContactApp);
            }

            //Проверка на файл. Еси нет файла, то создаем его.
            if (!System.IO.File.Exists(stringMyDocumentsPath))
            {
                File.Create(stringMyDocumentsPath).Close();
            }

            using (StreamWriter sw = new StreamWriter(stringMyDocumentsPath))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                // Вызов сериализатора и передача объекта сериализации
                serializer.Serialize(writer, contact);
            }
        }

        /// <summary>
        /// Метод, выполняющий чтение из файла 
        /// </summary>
        /// <param name="fileContactAppPath">Путь к файлу</param>
        /// <returns>Экземпляр проекта, считанный из файла</returns>
        public static Project LoadFromFile()
        {
            //Проверка на наличие файла
            if (System.IO.File.Exists(stringMyDocumentsPath))
            {
                return new Project();
            }
            try
            {
                using (StreamReader sr = new StreamReader(stringMyDocumentsPath))
                using (JsonReader reader = new JsonTextReader(sr))
                {
                    var serializer = new JsonSerializer();
                    var project = serializer.Deserialize<Project>(reader);

                    if (project == null)
                    {
                        project = new Project();
                    }
                    return project;
                }
            }
            catch (Exception exception)
            {
                return new Project();
            }
        }
    }
}
