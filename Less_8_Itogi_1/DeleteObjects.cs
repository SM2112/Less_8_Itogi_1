using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Less_8_Itogi_1
{
    internal class DeleteObjects
    {
        // класс для удаления папок и / или файлов
        // поля класса
        private string strPathInMet;

        // меетод класса
        public void delObj(string strPath)
        {
            strPathInMet = strPath;

            // проверяем есть ли по такому пути исходная папка
            if (Directory.Exists(strPathInMet))
            {
                DirectoryInfo dirInfo = new DirectoryInfo(strPathInMet);
                
                // работа по удалению папок
                DirectoryInfo[] dirs = dirInfo.GetDirectories();

                if (dirs.Length > 0)
                {
                    DateTime timeLastUse;
                    DateTime timeNow = DateTime.Now;
                    int i = 0;
                    foreach (DirectoryInfo dir in dirs)
                    {
                        timeLastUse = dir.LastAccessTime;
                        if ((timeNow - timeLastUse) > TimeSpan.FromMinutes(30))
                        {
                            dir.Delete(true);
                            i++;
                        }
                    }
                    Console.WriteLine("Удалено {0} пап(ки/ок)", i);
                }
                else 
                {
                    Console.WriteLine("В выбраной директории ни одной папки не обнаружено!");
                }

                // работа по удалению файлов
                FileInfo[] files = dirInfo.GetFiles();
                if (files.Length > 0)
                {
                    DateTime timeLastUse;
                    DateTime timeNow = DateTime.Now;
                    int i = 0;

                    foreach (FileInfo file in files)
                    {
                        timeLastUse = file.LastAccessTime;
                        if ((timeNow - timeLastUse) > TimeSpan.FromMinutes(30))
                        {
                            file.Delete();
                            i++;
                        }
                    }
                    Console.WriteLine("Удалено {0} фай(л/ов)", i);
                }
                else
                {
                    Console.WriteLine("В выбраной директории ни одного файла не обнаружено!");
                }
            }
            else
            {
                Console.WriteLine("По исходному пути нужная директория не  найдена! Для завершения программы нажмите любую клавишу!");
                Console.ReadKey();
            }
        }
    }
}
