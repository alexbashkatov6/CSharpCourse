

namespace D_OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            //Character c = new Character();
            //c.Hit(10);
            //Console.WriteLine(c.Health);

            //Calculator calc = new Calculator();
            //Console.WriteLine(calc.CalcTriangleSquare(10, 20));
            //Console.WriteLine(calc.CalcTriangleSquare(3, 4, 5));
            //Console.WriteLine(calc.Average(new int[] { 3, 4, 5}));
            //Console.WriteLine(calc.Average2(3, 4, 5));
            //Console.WriteLine(calc.CalcTriangleSquare(ab: 3, bc: 4, ac: 5));

            //Console.WriteLine(calc.TryDivide(1, 2, out double result));
            //Console.WriteLine(result);
            //Console.WriteLine(calc.TryDivide(1, 0, out double result2));
            //Console.WriteLine(result2);



            //PointVal a; // same as PointVal a =  new PointVal();
            //a.X = 3;
            //a.Y = 5;

            //PointVal b = a;
            //b.X = 7;
            //b.Y = 10;

            //a.LogValues();
            //b.LogValues();

            //Console.WriteLine();
            //Console.WriteLine();

            //PointRef a2 = new PointRef();
            //a2.X = 3;
            //a2.Y = 5;

            //PointRef b2 = a2;
            //b2.X = 7;
            //b2.Y = 10;

            //a2.LogValues();
            //b2.LogValues();


            //var list = new List<int>();
            //AddNumbers(list);

            //foreach (int i in list)
            //{
            //    Console.WriteLine(i);
            //}
            //int a = 5;
            //int b = 11;

            //Console.WriteLine($"a={a}, b={b}");
            //Swap(ref a, ref b);
            //Console.WriteLine($"a={a}, b={b}");



            //PointRef c;  // = null
            ////Console.WriteLine(c.X);  // NullReferenceException

            ////PointVal r = null;
            //PointVal? r = null;

            //if (r.HasValue)
            //{
            //    Console.WriteLine(r.Value);
            //}
            //else
            //{
            //    Console.WriteLine("No value");
            //}

            //PointVal r2 = r.GetValueOrDefault();



            //int x = 1;
            //object obj = x;
            //int y = (int)obj;

            //bool isInt = obj is int;
            //PointRef z = obj as PointRef;
            //if (z != null)
            //{
            //    Console.WriteLine("Success cast");
            //}
            //else
            //{
            //    Console.WriteLine("Not success cast");
            //}



            //Character elf = new Character("elf");
            //Console.WriteLine(elf.Race);

            //Character elf = new Character(Race.Elf);
            //Console.WriteLine(elf.Race);
            //Console.WriteLine((int)elf.Race);

            //Character no_name = null;
            //int a = null;



            //ModelXTerminal x_term = new ModelXTerminal("id_X");
            //ModelYTerminal y_term = new ModelYTerminal("id_Y");
            //x_term.Connect();
            //y_term.Connect();



            //Shape[] shapes = new Shape[2];  // shapes[0] = null
            //shapes[0] = new Triangle(3, 4, 5);
            //shapes[1] = new Rectangle(2, 3);
            //foreach (Shape sh in shapes)
            //{
            //    sh.Draw();
            //    Console.WriteLine(sh.Area());
            //    Console.WriteLine(sh.Perimeter());
            //}



            //IBaseCollection collection = new BaseList(4);
            //collection.Add(1);

            //List<object> list = new List<object>() { 1, 2, 3 };
            //collection.AddRange(list);



            MyStack<int> ms_int = new MyStack<int>();
            ms_int.Push(1);
            ms_int.Push(2);
            ms_int.Push(3);
            Console.WriteLine(ms_int.Peek());
            ms_int.Pop();
            Console.WriteLine(ms_int.Peek());
            ms_int.Push(3);
            ms_int.Push(4);
            ms_int.Push(5);
            Console.WriteLine(ms_int.Peek());

            Console.WriteLine();

            foreach(int i in ms_int)
            {
                Console.WriteLine(i);
            }

            //System.Collections.IEnumerable enumer = (System.Collections.IEnumerable)ms_int;
            
            //MyStack<string> ms_str = new MyStack<string>();
            //ms_str.Push("1");
            //ms_str.Push("2");
            //ms_str.Push("3");
            //Console.WriteLine(ms_str.Peek());
            //ms_str.Pop();
            //Console.WriteLine(ms_str.Peek());
            //ms_str.Push("3");
            //ms_str.Push("4");
            //ms_str.Push("5");
            //Console.WriteLine(ms_str.Peek());



        }

        static void Swap(ref int a, ref int b)
        {
            int tmp = a;
            a = b;
            b = tmp;
        }

        static void AddNumbers(List<int> numbers)
        {
            numbers.Add(1);
            numbers.Add(2);
            numbers.Add(3);
        }
    }
}
