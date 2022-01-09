﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.IO;
using System.Reflection;


namespace ContactsApp.UnitTest
{
    class ProjectManagerTest
    {
        public Project PrepareProject()
        {
            var sourceProject = new Project();

            sourceProject.Contacts.Add(new Contact()
            {
                Surname = "Пчелкин",
                Name = "Иван",
                DateOfBirth = new DateTime(2020, 12, 7, 23, 55, 17),
                PhoneNumber = new PhoneNumber()
                {
                    Number = 78901234567
                },
                IdVk = "qwerty",
                Email = "123@gmail.com"
            }
            );

            sourceProject.Contacts.Add(new Contact()
            {
                Surname = "Пупкин",
                Name = "Вася",
                DateOfBirth = new DateTime(2020, 12, 7, 23, 55, 17),
                PhoneNumber = new PhoneNumber()
                {
                    Number = 78891234321
                },
                IdVk = "qwerty",
                Email = "123@gmail.com"
            }
            );
            return sourceProject;
        }
        /// <summary>
        /// Тест на сериализацию 
        /// </summary>
       
        
        /// <summary>
        /// Когда неправильный файл (путь), возвращаем пустой проджект
        /// </summary>
        [Test]
        public void LoadFromFile_UnCorrectFile_ReturnEmptyProject()
        {
            //Setup
            var location = Assembly.GetExecutingAssembly().Location;
            var testDataFolder = Path.GetDirectoryName(location) + @"\wrong\";

            //Act
            var actualProject = ProjectManager.LoadFromFile(testDataFolder);

            //Assert
            Assert.IsEmpty(actualProject.Contacts);
        }
        [Test]
        public void SaveToFile_CorrectProject_FileSavedCorrectly()
        {
            //Setup
            var sourceProject = PrepareProject();
            var testDataFolder = Common.DataFolderForTest();
            var actualFileName = testDataFolder + @"\actualProject.json";
            var expectedFileName = testDataFolder + @"\expectedProject.json";
            if (File.Exists(actualFileName))
            {
                File.Delete(actualFileName);
            }

            //Act
            ProjectManager.SaveToFile(sourceProject, expectedFileName, testDataFolder);
            ProjectManager.SaveToFile(sourceProject, actualFileName, testDataFolder);

            var isFileExist = File.Exists(actualFileName);
            Assert.AreEqual(true, isFileExist);

            //Assert
            var actualFileContent = File.ReadAllText(actualFileName);
            var expectedFileContent = File.ReadAllText(expectedFileName);
            Assert.AreEqual(expectedFileContent, actualFileContent);
        }

        [Test]
        public void SaveToFile_CreateFolder_FolderIsExist()
        {
            //Setup
            var project = PrepareProject();

            var testDataFolder = Common.DataFolderForTest() + "CreateTest";
            var testFileName = testDataFolder + @"CreateFolderTest";
            if (Directory.Exists(testDataFolder))
            {
                Directory.Delete(testDataFolder);
            }

            //Act
            ProjectManager.SaveToFile(project, testFileName, testDataFolder);

            //Assert
            Assert.IsTrue(Directory.Exists(testDataFolder));
        }

        [Test]
        public void LoadFromFile_CorrectProject_FileLoadedCorrectly()
        {
            //Setup
            var expectedProject = PrepareProject();
            var testDataFolder = Common.DataFolderForTest();
            var testFileName = testDataFolder + @"\expectedProject.json";

            //Act
            var actualProject = ProjectManager.LoadFromFile(testFileName);

            //Assert
            Assert.AreEqual(expectedProject.Contacts, actualProject.Contacts);
        }

        [Test]
        public void LoadFromFile_UnCorrectPath_ReturnEmptyProject()
        {
            //Setup
            var testFileName = Common.DataFolderForTest() + "wrong";

            //Act
            var actualProject = ProjectManager.LoadFromFile(testFileName);

            //Assert
            Assert.IsEmpty(actualProject.Contacts);
        }

        [Test]
        public void FilePath_GoodFilePath_ReturnSamePath()
        {
            //Setup
            var expectedPath = Common.FilePath();

            //Act
            var actualPath = ProjectManager.FilePath();

            //Assert
            Assert.AreEqual(expectedPath, actualPath);
        }

        [Test]
        public void DirectoryPath_GoodDirectoryPath_ReturnSameDirectory()
        {
            //Setup
            var expectedPath = Common.DirectoryPath();

            //Act
            var actualPath = ProjectManager.DirectoryPath();

            //Assert
            Assert.AreEqual(expectedPath, actualPath);
        }
    }
}
