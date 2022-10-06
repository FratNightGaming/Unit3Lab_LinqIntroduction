namespace Linq_Objects_Introduction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 10, 2330, 112233, 10, 949, 3754, 2942 };
            
            List<Student> students = new List<Student>();
            students.Add(new Student("Jimmy", 13));
            students.Add(new Student("Hannah Banana", 21));
            students.Add(new Student("Justin", 30));
            students.Add(new Student("Sarah", 53));
            students.Add(new Student("Hannibal", 15));
            students.Add(new Student("Phillip", 16));
            students.Add(new Student("Maria", 63));
            students.Add(new Student("Abe", 33));
            students.Add(new Student("Curtis", 10));

            int maxValue = nums.Max();
            Console.WriteLine($"Maximum value is {maxValue}");

            int minValue = nums.Min();
            Console.WriteLine($"Minimum value is {minValue}");

            int maxValueLess1000 = nums.Where(x => x < 1000).ToList().Max();
            Console.WriteLine($"Max value under 1000 is {maxValueLess1000}");

            Console.WriteLine();

            List<int> valuesBetween10And100 = nums.Where(x => x >= 10 && x <= 100).ToList();
            DisplayData(valuesBetween10And100);

            Console.WriteLine();

            List<int> valuesBetween100000And999999 = nums.Where(x => x >= 100000 && x <= 999999).ToList();
            DisplayData(valuesBetween100000And999999);

            Console.WriteLine();

            List<int> evenNumbers = nums.Where(x => x % 2 == 0).ToList();
            Console.WriteLine("EvenNumbersList:");
            DisplayData(evenNumbers);

            Console.WriteLine();

            List<Student> studentsOver21 = students.Where(x => x.Age >= 21).ToList();
            DisplayStudentData(studentsOver21);//how to make generic data type to pass into displaydata function

            Console.WriteLine();

            Student oldestStudent = students.OrderByDescending(s => s.Age).First();
            Console.WriteLine($"The oldest student is {oldestStudent.Name} - Age: {oldestStudent.Age}");
            //int oldestStudent = students.Max(s => s.Age)
            //students.Where(s => s.Age == oldestStudent).First();
            //above: create list of students, sort by age, then cw list[0].age

            Console.WriteLine();

            int minAge = students.Min(s => s.Age);
            Student youngestStudent = students.Where(x => x.Age == minAge).First();
            Console.WriteLine($"The youngest student is {youngestStudent.Name} - Age: {youngestStudent.Age}");

            Console.WriteLine();

            //Student studentsOver25 = students.Where(x => x.Age <= 25).ToList().Max();//why does this one line code not work?
            List<Student> studentsUnder25 = students.Where(x => x.Age <= 25).ToList();
            int oldestUnder25 = studentsUnder25.Max(s => s.Age);
            Student oldestStudentUnder25 = studentsUnder25.Where(s => s.Age == oldestUnder25).First();
            Console.WriteLine($"The oldest student under 25 is {oldestStudentUnder25.Name} - Age: {oldestStudentUnder25.Age}");

            Console.WriteLine();

            List<Student> studentsOver21Even = students.Where(s => s.Age >= 25 && s.Age % 2 == 0).ToList();
            Console.WriteLine("Students over 21 with even ages:");
            DisplayStudentData(studentsOver21Even);

            Console.WriteLine();

            List<Student> teenageStudents = students.Where(s => s.Age <= 19 && s.Age >= 13).ToList();
            Console.WriteLine("Teenagers (ages 13-19):");
            DisplayStudentData(teenageStudents);

            Console.WriteLine();

            string vowels = "AaEeIiOoUu";

            List<Student> studentNamesBeginWithVowel = new List<Student>();

            foreach (Student s in students)
            {
                if (vowels.Contains(s.Name[0]))
                {
                    studentNamesBeginWithVowel.Add(s);
                }
            }

            Console.WriteLine("Students whose names begins with a vowel.");
            DisplayStudentData(studentNamesBeginWithVowel);//how to solve using Linq???

            Console.WriteLine();

            List<Student> studentVowelNames = students.Where(s => vowels.Contains(s.Name[0])).ToList();
            Console.WriteLine("Students whose names begins with a vowel.");
            DisplayStudentData(studentVowelNames);
        }

        public static void DisplayData(List<int> data)//how to combine with 2 params//for example, if "" = type int, do for loop below. if "" = type Student, do displaystudentdata for loop instead
        {
            for (int i = 0; i < data.Count; i++)
            {
                Console.WriteLine($"{i}: {data[i]}");
            }
        }

        public static void DisplayStudentData(List<Student> data)
        {
            for (int i = 0; i < data.Count; i++)
            {
                Console.WriteLine($"{i}: {data[i].Name}, {data[i].Age}");
            }
        }
    }
}