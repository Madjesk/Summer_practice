namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Student student1 = new Student("Klim", "Barabanov", "Alex:","М8О-211Б-2021", "C#");
                Student student2 = new Student("Alex", "Domoroschenov", "Alex", "M8O-213Б-2021", "C#");
                Student student3 = new Student("Klim", "Barabanov", "Alex", "М8О-211Б-2021", "C#");
                
                Console.WriteLine(student1.ToString());
                
                Console.WriteLine($"Course Number: {student1.getCourseNumberFromGroup}"); // 2
                
                
                
                Console.WriteLine($"Are students equal? {student1.Equals(student3)}"); //true
                Console.WriteLine($"Are students equal? {student1.Equals(student2)}"); //false
                
                Console.WriteLine(student1.GetHashCode()); 
                Console.WriteLine(student2.GetHashCode()); 
                Console.WriteLine(student3.GetHashCode()); 
                
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Wrong args");
            }
            catch (FormatException)
            {
                Console.WriteLine("Wrong format of group");
            }
        }
    }
}