using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuong_ASM
{
    internal abstract class Employee
    {
        private string id;
        private string name;
        private int age;
        private int phone;
        private string homeTown;
        private double salary;
        public string Id { get { return id; } private set {  id = value; } }
        public string Name { get { return name; } private set { name = value; } }
        public int Age { get { return age; } private set { age = value; } }
        public int Phone { get { return phone; } private set { phone = value; } }
        public string HomeTown { get {  return homeTown; } private set {  homeTown = value; } }
        public double Salary { get {  return salary; } private set {  salary = value; } }
        public Employee() { }
        public Employee(string id, string name, int age, int phone,string homeTown,double salary ) 
        {
            Id = id;
            Name = name;
            Age = age;
            Phone = phone;
            HomeTown = homeTown;
            Salary = salary;
        }
    }
}
