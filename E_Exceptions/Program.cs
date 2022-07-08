using System.Text;

namespace E_Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            Stream fs = new FileStream("test.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            try
            {
                string str = "Hello world";
                byte[] strInBytes = Encoding.ASCII.GetBytes(str);

                if (fs.CanWrite)
                {
                    fs.Write(strInBytes, 0, strInBytes.Length); 
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error: {ex.ToString()}");
            }
            finally
            {
                fs.Close();
            }

            using(Stream readingStream = new FileStream("test.txt", FileMode.Open, FileAccess.Read))
            {

            }
        }

        static void Exc()
        {
            string result = Console.ReadLine();

            int number;
            try
            {
                number = int.Parse(result);
                Console.WriteLine(number);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("A format ex occured");  // ex.Message
            }

        }
    }
}