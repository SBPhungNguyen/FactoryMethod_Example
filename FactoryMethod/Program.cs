using System;

namespace FactoryMethod
{
    //1. Giao dien chung cho cac nv
    public interface IEmployee
    {
        void JobDescription();
    }

    //2. Cac loai nhan vien cu the
    public class Cashier : IEmployee 
    { 
        public void JobDescription() 
        {
            Console.WriteLine("Cashier: Ehm do something that a cashier does");
        }
    }
    public class Salesperson : IEmployee
    {
        public void JobDescription()
        {
            Console.WriteLine("Salesperson: Do something that a salesperson does idk");
        }
    }

    //3. Lop truu tuong voi factory method
    public abstract class EmployeeCreator
    {
        public abstract IEmployee CreateEmployee();
        public void ShowJobDes()
        {
            IEmployee employee = CreateEmployee();
            Console.Write("Job Description: ");
            employee.JobDescription();
        }
    }

    //4. Cai dat factory method cho tung loai nhan vien
    public class CashierCreator : EmployeeCreator
    {
        public override IEmployee CreateEmployee() => new Cashier();
    }

    public class SalespersonCreator : EmployeeCreator
    {
        public override IEmployee CreateEmployee() => new Salesperson();
    }

    //5. Client su dung 
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeCreator creator;
            Console.WriteLine("Choose a position:\t1.Cashier\t2.Salesperson");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    creator = new CashierCreator();
                    break;
                case "2":
                    creator = new SalespersonCreator();
                    break;
                default:
                    throw new ArgumentException("Invalid choice");
            }
            creator.ShowJobDes();
        }
    }
}
