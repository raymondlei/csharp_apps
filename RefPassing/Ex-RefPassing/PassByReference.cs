using System;

namespace Ex_RefPassing
{
    public static class PassByReference
    {
        public static void Run()
        {
            Container _obj1;
            Container _obj2;

            float tempFloat;
            int tempInt;
            string tempStr;

            _obj1 = new Container();
            _obj1.FloatData = 0.01F;
            _obj1.IntData = 1;
            _obj1.StrData = "_obj1 ID: 12345";

            {
                Console.WriteLine("----- _obj1 content -----");
                Console.WriteLine("Float: {0}", _obj1.FloatData);
                Console.WriteLine("Int: {0}", _obj1.IntData);
                Console.WriteLine("String: {0}", _obj1.StrData);
                tempFloat = _obj1.FloatData;
                tempInt = _obj1.IntData;
                tempStr = _obj1.StrData;
            }

            //Making a "copy" of Container Obj_1
            _obj2 = _obj1;

            //Assign new contents
            _obj2.FloatData = 999.9F;
            _obj2.IntData = -9;
            _obj2.StrData = "This is _obj2";

            {
                Console.WriteLine("\n----- _obj1 content -----");
                tempFloat = _obj1.FloatData;
                tempInt = _obj1.IntData;
                tempStr = _obj1.StrData;
                Console.WriteLine("Float: {0}", _obj1.FloatData);
                Console.WriteLine("Int: {0}", _obj1.IntData);
                Console.WriteLine("String: {0}", _obj1.StrData);
            }

            Console.ReadLine();  //pause
        }

        class Modifier
        {
            private Container data;
            public Modifier(Container input)
            {
                data = input;
            }

            public void modifiedValue()
            {
                data.FloatData = 4.0F;
                data.IntData = 99;
                data.StrData = "modified";
            }
        }

        //struct Container, "POCO", Plain-Old-CLR-Object
        class Container
        {
            private int intData;
            public int IntData
            {
                get { return intData; }
                set { intData = value; }
            }

            private float floatData;
            public float FloatData
            {
                get { return floatData; }
                set { floatData = value; }
            }

            private string strData;
            public string StrData
            {
                get { return strData; }
                set { strData = value; }
            }
        }
    }
}
