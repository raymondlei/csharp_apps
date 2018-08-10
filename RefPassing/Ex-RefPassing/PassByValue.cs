using System;

namespace Ex_RefPassing
{
    public static class PassByValue
    {
        public static void Run()
        {
            int tempInt;
            int container2;

            tempInt = 1;  //Assign value 1 to _tempInt
            {
                Console.WriteLine("----- container1 value -----");
                Console.WriteLine("Int: {0}", tempInt);
            }

            //Making a copy of Container Obj_1
            container2 = tempInt;

            //Assign new value
            container2 = -9;
            {
                Console.WriteLine("\n----- container1 content -----");
                Console.WriteLine("Int: {0}", tempInt);
            }

            Console.ReadLine();  //pause
        }
    }
}
