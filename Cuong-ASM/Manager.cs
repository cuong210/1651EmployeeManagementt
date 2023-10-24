using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuong_ASM
{
    internal class Manager:Employee,IShowInfo
    {
        private int teamSize;
        private List<Manager> managers = new List<Manager>();
        public int TeamSize {  get { return teamSize; } private set {  teamSize = value; } }
        public Manager(string id, string name, int age, int phone, string homeTown, double salary, int teamSize) : base(id, name, age, phone, homeTown, salary)
        {
            TeamSize = teamSize;
        }
        public Manager() { }
       
        public void add(Manager manager)
        {
            managers.Add(manager);
        }
        public void addManager()
        {
            try
            {
                Console.WriteLine("Enter ID: ");
                string id = Console.ReadLine();
                if (managers.Any(manager => manager.Id == id))
                {
                    throw new Exception("Manager with this ID already exists in the list. Please enter a unique ID.");
                }
                Console.WriteLine("Enter Name: ");
                string name = Console.ReadLine();
                Console.WriteLine("Enter Age: ");
                int age = int.Parse(Console.ReadLine());
                if (age < 18 || age > 40)
                {
                    throw new Exception("Age must be greater than 18 and less than 40.");
                }
                Console.WriteLine("Enter Phone Number: ");
                //string phoneString = Console.ReadLine();
                //if (phoneString.Length != 10 && phoneString.Length != 11 || !phoneString.All(char.IsDigit))
                //{
                //    throw new Exception("Invalid phone number. Phone number must be 10 or 11 digits and contain only numeric characters.");
                //}
                //int phone = int.Parse(phoneString);
                //if (managers.Any(manager => manager.Phone == phone))
                //{
                //    throw new Exception("Manager with this phone number already exists in the list.");
                //}
                int phone = int.Parse(Console.ReadLine());
                if (phone.ToString().Length == 10 || phone.ToString().Length == 11)
                {
                    throw new Exception("Invalid phone number. Phone number must be 10 digits.");
                }
                else if (managers.Any(manager => manager.Phone == phone))
                {
                    throw new Exception("Manager with this phone number already exists in the list. Please enter a unique phone number.");
                }
                Console.WriteLine("Enter Home Town: ");
                string homeTown = Console.ReadLine();
                Console.WriteLine("Enter Salary: ");
                double salary = double.Parse(Console.ReadLine());
                if (salary <= 0)
                {
                    throw new Exception("Salary must be non-negative.");
                }
                Console.WriteLine("Enter Team Size: ");
                int teamSize = int.Parse(Console.ReadLine());
                Manager manager = new Manager(id, name, age, phone, homeTown, salary, teamSize);
                add(manager);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Add completed.");
                 Console.ResetColor();
            }
            catch (Exception e)
            {
                Console.ForegroundColor= ConsoleColor.Red;
                Console.WriteLine($"{e.Message}");
                Console.ResetColor();
            }
            
        }

        public void removeManager()
        {
            try
            {
                Console.WriteLine("Enter ID: ");
                string id = Console.ReadLine();
                if (id != null)
                {
                    int idClear = managers.FindIndex(manager => manager.Id == id);
                    if (idClear != -1)
                    {
                        managers.RemoveAt(idClear);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Remove completed.");
                        Console.ResetColor();
                    }
                    else
                    {
                        throw new Exception("Manager with this ID does not exist in the list.");
                    }
                }
                else
                {
                    throw new Exception("ID cannot be null.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}");
            }
        }

        public void menuManager()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("========Menu========");
            Console.WriteLine("1. Add manager");
            Console.WriteLine("2. Add staff");
            Console.WriteLine("3. Remove manager");
            Console.WriteLine("4. Remove staff");
            Console.WriteLine("5. Display manager");
            Console.WriteLine("6. Display staff");
            Console.WriteLine("7. Log out");
            Console.WriteLine("====================");
            Console.ResetColor();
        }
      
        public void showInfo()
        {
            foreach(Manager m in managers)
            {
                Console.WriteLine($"ID: {m.Id}, Name: {m.Name} is {m.Age} years old, has phone number {m.Phone} \n he/she live in {m.HomeTown}, Salary: {m.Salary}, he/she management team {m.TeamSize} people.");
            }
        }

    }
}
