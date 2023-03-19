using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Events
{
    public delegate void Job(string profession_name, int employee_age);
    class Employee
    {
        public string name { get; set; }
        public string surname { get; set; }
        public int age { get; set; }
        public Employee(string name, string surname, int age)
        {
            this.name = name;
            this.surname = surname;
            this.age = age;
        }

        public override string ToString() { return ($"{surname} {name} {age} years"); }
        public void Check_age(string profession_name, int employee_age)
        {
            if (age >= employee_age)
                WriteLine($"{surname} {name} is eligible to work as {profession_name}");
            else
                WriteLine($"{surname} {name} is under aged to work as {profession_name}");
        }

    }

    class Employer
    {
        public event Job job;
        public void Job(string profession_name, int employee_age) { job(profession_name, employee_age); }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            List<Employee> employees = new List<Employee>
            {

                new Employee ("Oleg", "Ivanov", random.Next(14, 50)),
                new Employee ("Ivan", "Grachev", random.Next(14, 50)),
                new Employee ("Roman", "Efimov", random.Next(14,50)),
                new Employee ("Elina", "Fomina", random.Next(14, 50)),
                new Employee ("Elena", "Lapshina", random.Next(14, 50)),
                new Employee ("Dmitriy", "Maksimov", random.Next(14, 50)),
            };
            WriteLine("List of candidates:\n");
            foreach (var item in employees)
            {
                WriteLine(item);
            }
            
            Employer comp = new Employer();
            foreach (var item in employees) { comp.job += item.Check_age; }
            WriteLine("\n\n");
            WriteLine("************************JOBS AT HOSPITAL*****************************");
            WriteLine("\n1) Nurse:\n");
            comp.Job("nurse", 18);
            WriteLine("\n2) Surgeon:\n");
            comp.Job("surgeon", 30);
            WriteLine("\n3) Head of hospital:\n");
            comp.Job("head of hospital", 35);
           


        }
    }
}