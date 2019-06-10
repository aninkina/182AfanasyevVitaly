using System;

namespace Task04
{
    class ConsoleUI
    {
        event NewStringValue NewStringValueHappened;
        
        UIString s = new UIString(); // специальная строка
        public UIString S { get { return s; } set { s = value; } }
        
        public void GetStringFromUI()
        {
            Console.WriteLine("Введите новое значение строки");
            string str = Console.ReadLine();
            NewStringValueHappened(str);
            RefreshUI();
        }
        
        public void CreateUI()
        {
            NewStringValueHappened += s.NewStringValueHappenedHandler;
            RefreshUI();
        }
        
        public void RefreshUI()
        {      // обновление строки     
            Console.Clear();
            Console.WriteLine("Текст строки: " + s.Str);
        }
    }
}
