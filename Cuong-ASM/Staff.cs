using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuong_ASM
{
    internal class Staff:Employee,IShowInfo
    {
        private List<Staff> staffs= new List<Staff>();
        private string carrer;
        public string Carrer {  get { return carrer; } private set {  carrer = value; } }
        public Staff() { }
        public Staff(string id,string name,int age,int phone,string homeTown,double salary,string carrer) :base(id,name,age,phone,homeTown,salary)
        {
            Carrer = carrer;
        }
        public void add(Staff staff)
        {
            staffs.Add(staff);
        }
        public void addStaff()
        {
            try
            {
                Console.WriteLine("Enter ID: ");
                string id = Console.ReadLine();
                if (staffs.Any(staff => staff.Id == id))
                {
                    throw new Exception("Staff with this ID already exists in the list. Please enter a unique ID.");
                }
                Console.WriteLine("Enter Name: ");
                string name = Console.ReadLine();
                Console.WriteLine("Enter Age: ");
                int age = int.Parse(Console.ReadLine());
                if (age < 20 || age > 40)
                {
                    throw new Exception("Age must be greater than 20 and less than 40.");
                }
                Console.WriteLine("Enter Phone Number: ");
                int phone = int.Parse(Console.ReadLine());
                if (phone.ToString().Length == 10 || phone.ToString().Length == 11)
                {
                    throw new Exception("Invalid phone number. Phone number must be 10 or 11 digits.");
                }
                Console.WriteLine("Enter Home Town: ");
                string homeTown = Console.ReadLine();
                Console.WriteLine("Enter Salary: ");
                double salary = double.Parse(Console.ReadLine());
                if (salary <= 0)
                {
                    throw new Exception("Salary must be non-negative.");
                }
                Console.WriteLine("Enter Carrer: ");
                string carrer = Console.ReadLine();
                Staff staff = new Staff(id, name, age, phone, homeTown, salary, carrer);
                add(staff);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Add completed.");
                Console.ResetColor();
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{e.Message}");
                Console.ResetColor();
            }


        }
        public void removeStaff()
        {
            try
            {
                Console.WriteLine("Enter ID: ");
                string id = Console.ReadLine();
                if (id != null)
                {
                    int idClear = staffs.FindIndex(staff => staff.Id == id);
                    if (idClear != -1)
                    {
                        staffs.RemoveAt(idClear);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Remove completed.");
                        Console.ResetColor();
                    }
                    else
                    {
                        throw new Exception("Staff with this ID does not exist in the list.");
                    }
                }
                else
                {
                    throw new Exception("ID cannot be null.");
                }
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{e.Message}");
                Console.ResetColor();
            }

        }

        public void menuStaff()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("========Menu========");
            Console.WriteLine("1: Display staff");
            Console.WriteLine("2: Log out");
            Console.WriteLine("====================");
            Console.ResetColor();
        }

        public void showInfo() 
        {
            foreach (Staff staff in staffs) 
            {
                Console.WriteLine($"ID: {staff.Id}, Name: {staff.Name} is {staff.Age} years old, phone number: {staff.Phone}, He/She live in {staff.HomeTown}, Salary: {staff.Salary}, Carrer: {staff.Carrer}");
            }
        }
    }
}
