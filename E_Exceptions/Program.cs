using System.Text;

namespace E_Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            try  // Files operations !
            {
                File.Copy("test.txt", "test_copy.txt", overwrite: true);
                // .Move - for rename
                // .Delete
                // .Exists
                // .Replace - content from file to file

                bool existsDir = Directory.Exists("tmp");
                if (existsDir)
                {
                    var files = Directory.EnumerateFiles("file_1", "*.txt", SearchOption.AllDirectories);
                }

                Path.GetExtension("my_file.txt");
                Path.Combine("sd", "asfd", "dfgf");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        static void FilesOperations()
        {
            string[] allLines = File.ReadAllLines("test.txt");
            string alltext = File.ReadAllText("test.txt");
            IEnumerable<string> lines = File.ReadLines("test.txt");  // lazy

            File.WriteAllText("test_2.txt", "My name is john");
            File.WriteAllLines("test_3.txt", new string[] { "My name", "is john" });
            File.WriteAllBytes("test_4.txt", new byte[] { 72, 101, 108, 108, 111 });

            Console.WriteLine(alltext);

            Console.ReadLine();

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
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.ToString()}");
            }
            finally
            {
                fs.Close();
            }

            Console.WriteLine("Write success");

            using (Stream readingStream = new FileStream("test.txt", FileMode.Open, FileAccess.Read))
            {
                byte[] temp = new byte[readingStream.Length];
                int bytesToRead = (int)readingStream.Length;
                int bytesRead = 0;
                while (bytesToRead > 0)
                {
                    int n = readingStream.Read(temp, bytesRead, bytesToRead);
                    if (n == 0)
                        break;

                    bytesRead += n;
                    bytesToRead -= n;
                }
                string str = Encoding.ASCII.GetString(temp, 0, temp.Length);
                Console.WriteLine(str);
            }

            Console.WriteLine("Read success");

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