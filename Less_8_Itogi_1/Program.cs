namespace Less_8_Itogi_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // объявляем переменную с путем до нужного ресурса
            string strPath = "D:\\Модуль_8";
            string answerUser;

            Console.WriteLine("Вы находитесь в программе по очистке места на диске!");
            Console.WriteLine("Программа удаляет папки и файлы по следующему пути: {0}", strPath);
            Console.WriteLine("По указанному пути будут удалены все файлы и папки, которые");
            Console.WriteLine("не использлвались в течение последних 30 минут!");
            Console.WriteLine();

            Console.Write("Вы хотите продолжить? Ответте ДА / НЕТ: ");
            answerUser = Console.ReadLine();

            if (answerUser == "ДА")
            {
                // вызываем метод для очистки указанной папки
                // в метод будем передавать путь до папки
                DeleteObjects deleteObjects = new DeleteObjects();
                deleteObjects.delObj(strPath);
            }
            else
            {
                Console.WriteLine("Нажмите любую клавишу для закрытия данной программы!");
                Console.ReadKey();
            }



        }
    }
}