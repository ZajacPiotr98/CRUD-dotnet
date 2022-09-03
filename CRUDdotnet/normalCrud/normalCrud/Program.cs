using System;

namespace normalCrud
{
    class Program
    {
        static void Main(string[] args)
        {
            int opt = 1;
            while (opt == 1 || opt == 2 || opt == 3 || opt == 4)
            {
                Console.WriteLine("\nWpisz cyfrę i wciśnij enter:");
                Console.WriteLine("1. Dodaj");
                Console.WriteLine("2. Pobierz");
                Console.WriteLine("3. Zaktualizuj");
                Console.WriteLine("4. Usuń");
                Console.WriteLine("Inny przycisk - wyjście");
                try
                {
                    opt = Convert.ToInt32(Console.ReadLine());
                    switch (opt)
                    {
                        case 1:
                            Save();
                            break;
                        case 2:
                            GetById();
                            break;
                        case 3:
                            Update();
                            break;
                        case 4:
                            Delete();
                            break;
                        default:
                            break;
                    }
                }
                catch(Exception)
                {
                    Console.WriteLine("Wpisano niepoprawne dane");
                }
            }
        }

        private static void Save()
        {
            ExampleModelRepository repository = new();
            Console.WriteLine("Podaj id");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Podaj nazwę");
            string name = Console.ReadLine();
            Console.WriteLine("Podaj wartość");
            int val = Convert.ToInt32(Console.ReadLine());
            if(repository.GetById(id) is null)
            {
                repository.Save(new ExampleModel() { Id = id, Name = name, Value = val });
                Console.WriteLine($"Pomyślnie dodano model id: {id}, nazwa: {name}, wartość: {val}");
            }
            else
            {
                Console.WriteLine($"Model o danym id już został dodany");
            }
        }
        private static void GetById()
        {
            ExampleModelRepository repository = new();
            Console.WriteLine("Podaj id");
            int id = Convert.ToInt32(Console.ReadLine());
            ExampleModel model = repository.GetById(id);
            if(model is not null)
            {
                Console.WriteLine(
                    $"Pomyślnie pobrano model id: {model.Id}, " +
                    $"nazwa: {model.Name}, wartość: {model.Value}");
            }
            else
            {
                Console.WriteLine($"Nie odnaleziono modelu o podanym id");
            }
        }
        private static void Update()
        {
            ExampleModelRepository repository = new();
            Console.WriteLine("Podaj id");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Podaj nową nazwę");
            string name = Console.ReadLine();
            ExampleModel model = repository.GetById(id);
            if (model is not null)
            {
                model.Name = name;
                repository.Update(model);
                Console.WriteLine(
                    $"Pomyślnie zaktualizowano model id: {model.Id}, nazwa: {model.Name}, wartość: {model.Value}");
            }
            else
            {
                Console.WriteLine($"Model o danym id nie istnieje");
            }
        }
        private static void Delete()
        {
            ExampleModelRepository repository = new();
            Console.WriteLine("Podaj id");
            int id = Convert.ToInt32(Console.ReadLine());
            repository.Delete(id);
            Console.WriteLine($"Pomyślnie usunięto model id: {id}");
        }
    }
}
