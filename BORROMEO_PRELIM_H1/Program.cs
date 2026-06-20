using System;
//ugyifgfvytf
using System.Collections.Generic;

class Program
{
    static List<string> studentNames = new List<string>();
    static List<double[]> studentGrades = new List<double[]>();

    static void Main()
    {
        int choice;

        do
        {
            Console.WriteLine("\n===== STUDENT SYSTEM =====");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. View All Students");
            Console.WriteLine("3. Compute Average Grade");
            Console.WriteLine("4. Find Highest Grade");
            Console.WriteLine("6. Exit");
            Console.WriteLine("==========================");
            Console.Write("Choose an option: ");

            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input! Please enter a number from 1 to 5.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    AddStudent();
                    break;

                case 2:
                    ViewStudents();
                    break;

                case 3:
                    ComputeClassAverage();
                    break;

                case 4:
                    FindHighestGrade();
                    break;

                case 5:
                    Console.WriteLine("\nExiting program...");
                    Console.WriteLine("Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid option! Please choose from 1 to 5.");
                    break;
            }

        } while (choice != 5);
    }

    static void AddStudent()
    {
        Console.WriteLine("\nADD STUDENT");

        Console.Write("Enter student name: ");
        string name = Console.ReadLine();

        double[] grades = new double[3];

        for (int i = 0; i < 3; i++)
        {
            Console.Write($"Enter grade {i + 1}: ");

            while (!double.TryParse(Console.ReadLine(), out grades[i]))
            {
                Console.Write("Invalid input. Enter a numeric grade: ");
            }
        }

        studentNames.Add(name);
        studentGrades.Add(grades);

        Console.WriteLine("Student added successfully!");
    }

    static void ViewStudents()
    {
        Console.WriteLine("\nVIEW STUDENTS");

        if (studentNames.Count == 0)
        {
            Console.WriteLine("No students found.");
            return;
        }

        for (int i = 0; i < studentNames.Count; i++)
        {
            double average = GetStudentAverage(studentGrades[i]);

            Console.WriteLine($"\nName: {studentNames[i]}");
            Console.WriteLine($"Grades: {studentGrades[i][0]}, {studentGrades[i][1]}, {studentGrades[i][2]}");
            Console.WriteLine($"Average: {average:F2}");
        }
    }

    static void ComputeClassAverage()
    {
        Console.WriteLine("\n===== CLASS AVERAGE =====");

        if (studentNames.Count == 0)
        {
            Console.WriteLine("No students found.");
            return;
        }

        double totalAverage = 0;

        for (int i = 0; i < studentGrades.Count; i++)
        {
            totalAverage += GetStudentAverage(studentGrades[i]);
        }

        double classAverage = totalAverage / studentGrades.Count;

        Console.WriteLine($"Overall Average Grade: {classAverage:F2}");
    }

    static void FindHighestGrade()
    {
        Console.WriteLine("\n===== HIGHEST GRADE =====");

        if (studentNames.Count == 0)
        {
            Console.WriteLine("No students found.");
            return;
        }

        // Find the highest grade in the class
        double highestGrade = studentGrades[0][0];

        for (int i = 0; i < studentGrades.Count; i++)
        {
            foreach (double grade in studentGrades[i])
            {
                if (grade > highestGrade)
                {
                    highestGrade = grade;
                }
            }
        }

        Console.WriteLine($"Highest Grade: {highestGrade}");
        Console.WriteLine("Top Student(s):");

        // Display all students who have the highest grade
        for (int i = 0; i < studentGrades.Count; i++)
        {
            bool hasHighestGrade = false;

            foreach (double grade in studentGrades[i])
            {
                if (grade == highestGrade)
                {
                    hasHighestGrade = true;
                    break;
                }
            }

            if (hasHighestGrade)
            {
                Console.WriteLine(studentNames[i]);
            }
        }
    }

    static double GetStudentAverage(double[] grades)
    {
        double sum = 0;

        foreach (double grade in grades)
        {
            sum += grade;
        }

        return sum / grades.Length;
    }
}