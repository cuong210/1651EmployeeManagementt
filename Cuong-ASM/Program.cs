using System.ComponentModel;
using Cuong_ASM;

namespace Company
{
    class Company
    {
        static void Main(string[] args)
        {
            Manager manger = new Manager();
            Staff staff = new Staff();
            Manager manager1 = new Manager("1", "nam", 25, 0909090909, "Da Nang", 12000000, 3);
            manger.add(manager1);


            Staff staff1 = new Staff("101", "trung", 20, 0907060509, "Ha Tinh", 123132123, "IT");
            staff.add(staff1);
            int choose;
            int menumain = 0;
            IShowInfo showinfo;
            do
            {
                try
                {
                    Console.WriteLine("------Welcome to my program------");
                    Console.WriteLine("            1. Login             ");
                    Console.WriteLine("            2. Exit              ");
                    Console.WriteLine("---------------------------------");
                    Console.WriteLine("Enter your choose: ");
                    menumain = int.Parse(Console.ReadLine());
                    if (menumain == 1)
                    {

                        Console.WriteLine("User Name: ");
                        string userName = Console.ReadLine();
                        Console.WriteLine("Password: ");
                        string passWord = Console.ReadLine();
                        if (userName == "manager" && passWord == "manager")
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Login successfull");
                            Console.ResetColor();
                            do
                            {
                                manger.menuManager();
                                showinfo = manger;

                                Console.WriteLine("Enter your choose: ");
                                choose = int.Parse(Console.ReadLine());
                                switch (choose)
                                {
                                    case 1:
                                        manger.addManager();
                                        
                                        break;
                                    case 2:
                                        staff.addStaff();
                                        break;
                                    case 3:
                                        manger.removeManager();
                                        break;
                                    case 4:
                                        staff.removeStaff();
                                        break;
                                    case 5:
                                        showinfo.showInfo();
                                        break;
                                    case 6:
                                        showinfo = staff;
                                        showinfo.showInfo();
                                        break;
                                    case 7:
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        Console.WriteLine("Bye!!!");
                                        Console.ResetColor();
                                        break;
                                    default: break;
                                }

                            } while (choose != 7);
                        }
                        else if (userName == "staff" && passWord == "staff")
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Login successfull");
                            Console.ResetColor();
                            do
                            {
                                staff.menuStaff();
                                Console.WriteLine("Enter your choose: ");
                                choose = int.Parse(Console.ReadLine());
                                switch (choose)
                                {
                                    case 1:
                                        staff.showInfo();
                                        break;
                                    case 2:
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        Console.WriteLine("Bye!!!");
                                        Console.ResetColor();
                                        break;
                                    default: break;
                                }
                            } while (choose != 2);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid username or password. \n" +
                                              "     Please try again.");
                            Console.ResetColor();
                        }
                    }
                    else if (menumain == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Good Bye!!!");
                        Console.ResetColor();
                    }
                    else
                    {
                        throw new Exception("    Invalid number \n" +
                                        "please enter 1 or 2 option");
                    }
                }
                catch (Exception e)
                {
                    Console.ForegroundColor= ConsoleColor.Red;
                    Console.WriteLine(e.Message);
                    Console.ResetColor();
                }


            } while (menumain != 2);
            

            
        }
    }
}