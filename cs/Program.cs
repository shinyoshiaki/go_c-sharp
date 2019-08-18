using System;
using System.Runtime.InteropServices;
using System.Text;

namespace cs
{
    class Program
    {
        struct GoString
        {
            public IntPtr p;
            public int n;
        }

        struct GoSlice
        {
            public IntPtr data;
            public int len;
            public int cap;
        }

        [DllImport("../plugin/go", CallingConvention = CallingConvention.Cdecl)]
        static extern int Sum(int a, int b);

        [DllImport("../plugin/go", CallingConvention = CallingConvention.Cdecl)]
        static extern GoString GetStr(string str);

        [DllImport("../plugin/go", CallingConvention = CallingConvention.Cdecl)]
        static extern GoSlice GetBytes();

        static void Main(string[] args)
        {
            Environment.SetEnvironmentVariable("GODEBUG", "cgocheck=0");

            Console.WriteLine(Sum(5, 15));

            GoString str = GetStr("C#");
            byte[] bytes = new byte[str.n];
            for (int i = 0; i < str.n; i++)
                bytes[i] = Marshal.ReadByte(str.p, i);
            string s = Encoding.UTF8.GetString(bytes);
            Console.WriteLine(s);

            GoSlice arr = GetBytes();

            bytes = new byte[arr.len];
            for (int i = 0; i < arr.len; i++)
                bytes[i] = Marshal.ReadByte(arr.data, i);

            s = Encoding.UTF8.GetString(bytes);
            Console.WriteLine(s);
        }
    }
}
