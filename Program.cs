using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPP1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>
{
    new Student { Id = 1, Name = "An", Age = 16 },
    new Student { Id = 2, Name = "Binh", Age = 18 },
    new Student { Id = 3, Name = "Cuc", Age = 15 },
    new Student { Id = 4, Name = "Dung", Age = 17 },
    new Student { Id = 5, Name = "Hoa", Age = 19 }
};
            // a. In danh sách toàn bộ học sinh
            Console.WriteLine("a.Danh sach toan bo hoc sinh:");
            foreach (var student in students)
            {
                Console.WriteLine($"ID: {student.Id}, Ten: {student.Name}, Tuoi: {student.Age}");
            }

            // b. Tìm học sinh có tuổi từ 15 đến 18
            Console.WriteLine("\nb.Danh sach hoc sinh có tuoi tu 15 đen 18:");
            var studentsAge15To18 = students.Where(s => s.Age >= 15 && s.Age <= 18);
            foreach (var student in studentsAge15To18)
            {
                Console.WriteLine($"ID: {student.Id}, Ten: {student.Name}, Tuoi: {student.Age}");
            }

            // c. Tìm học sinh có tên bắt đầu bằng chữ "A"
            Console.WriteLine("\nc.Danh sach hoc sinh co ten bat đau bang chu 'A':");
            var studentsStartWithA = students.Where(s => s.Name.StartsWith("A"));
            foreach (var student in studentsStartWithA)
            {
                Console.WriteLine($"ID: {student.Id}, Ten: {student.Name}, Tuoi: {student.Age}");
            }

            // d. Tính tổng tuổi của tất cả học sinh
            int totalAge = students.Sum(s => s.Age);
            Console.WriteLine($"\nd.Tong tuoi cua tat ca hoc sinh: {totalAge}");

            // e. Tìm học sinh có tuổi lớn nhất
            var oldestStudent = students.OrderByDescending(s => s.Age).FirstOrDefault();
            Console.WriteLine($"\ne.Hoc sinh co tuoi lon nhat: ID: {oldestStudent.Id}, Ten: {oldestStudent.Name}, Tuoi: {oldestStudent.Age}");

            // f. Sắp xếp danh sách học sinh theo tuổi tăng dần
            var sortedStudents = students.OrderBy(s => s.Age);
            Console.WriteLine("\nf.Danh sach hoc sinh sau khi sap xep theo tuoi tang dan:");
            foreach (var student in sortedStudents)
            {
                Console.WriteLine($"ID: {student.Id}, Ten: {student.Name}, Tuoi: {student.Age}");
            }
        }
    }
}
