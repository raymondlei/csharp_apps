/*
 *  This example shows the difference between class and struct, and the effect of reference type and value type.
 *  Change Container from class to struct, then watch the properties of the Container.
 *  Method modifiedValue() has effect on class (passed by reference), but does not have effect on struct (passed by value).
 *  
 *  Reference URL:
 *  http://www.leerichardson.com/2007/01/parameter-passing-in-c.html
 *  http://jonskeet.uk/csharp/parameters.html
 */

namespace Ex_RefPassing
{
    class Program
    {
        static void Main(string[] args)
        {
            PassByValue.Run();
            PassByReference.Run();
        }
    }
}
