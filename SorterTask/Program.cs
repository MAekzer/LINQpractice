namespace SorterTask
{
    class Program
    {
        static void Main(string[] args)
        {
            //  создаём пустой список с типом данных Contact
            var phoneBook = new List<Contact>
            {
                // добавляем контакты
                new Contact("Игорь", "Николаев", 79990000001, "igor@example.com"),
                new Contact("Сергей", "Довлатов", 79990000010, "serge@example.com"),
                new Contact("Анатолий", "Карпов", 79990000011, "anatoly@example.com"),
                new Contact("Валерий", "Леонтьев", 79990000012, "valera@example.com"),
                new Contact("Сергей", "Брин", 799900000013, "serg@example.com"),
                new Contact("Иннокентий", "Смоктуновский", 799900000013, "innokentii@example.com")
            };

            var sortedPhoneBook = from contact in phoneBook
                                  orderby contact.Name, contact.LastName
                                  select contact;

            int l = sortedPhoneBook.Count();
            Console.WriteLine($"Введите число от 1 до {l / 2}"); // так как у нас есть два контакта на страницу, будет такое кол-во страниц

            while (true)
            {
                var isNum = Int32.TryParse(Console.ReadKey().KeyChar.ToString(), out int keyChar); // получаем символ с консоли
                Console.Clear();  //  очистка консоли от введенного текста

                if (isNum) // проверка на число
                {
                    foreach (var contact in sortedPhoneBook.Skip((keyChar - 1) * 2).Take(2)) // пропускаем страницы в зависимости от введенного числа
                        Console.WriteLine($"{contact.Name} {contact.LastName} - тел. номер {contact.PhoneNumber}, email {contact.Email}");

                    if (keyChar == 0 || keyChar * 2 > l) // проверка на случай, если пользователь выбирает пустую страницу
                        Console.WriteLine($"Введено число 0 или число, превышающее кол-во страниц в книге. Введите число от 1 до {l / 2}.");
                }
                else
                {
                    Console.WriteLine($"Неверный формат ввода. Введите число от 1 до {l / 2}.");
                }
            }
        }
    }
}