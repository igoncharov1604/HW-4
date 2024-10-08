namespace ConsoleApp9
{
    using System;

    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Role { get; set; }

        public Person(string name, string role, int age)
        {
            Name = name;
            Age = age;
            Role = role;
        }

        public string GetName() { return Name; }
        public virtual void MyRating() { return; }
    }

    // Клас для оцінювання студента
    class StudentAssesment
    {
        private readonly string[] subject = { "C#", "ООП", "Основи SE", "Алгоритми", "Математика", "Фізика", "Англійська", "Філософія", "Економіка", "Право" };
        private readonly double[] assessment = new double[10];

        public StudentAssesment()
        {
            // Заповнюємо випадковими числами від 56 до 100
            Random rnd = new Random();
            for (int i = 0; i < assessment.Length; i++)
            {
                assessment[i] = rnd.Next(56, 101);
            }
        }

        public double StudentRating()
        {
            double rating = 0;
            for (int i = 0; i < assessment.Length; i++)
            {
                rating += assessment[i];
            }

            return rating / assessment.Length; // Середній рейтинг за всі дисципліни
        }
    }

    // Клас студент
    class Student : Person
    {
        public string Faculty { get; set; }
        public string Group { get; set; }
        public int Course { get; set; }

        public Student(string name, string role, int age, string faculty, string group, int course)
            : base(name, role, age)
        {
            Name = name;
            Age = age;
            Role = role;
            Faculty = faculty;
            Group = group;
            Course = course;
        }

        // Створюємо два екземпляри класу StudentAssesment для двох модулів
        StudentAssesment stRating1 = new StudentAssesment();
        StudentAssesment stRating2 = new StudentAssesment();

        public override void MyRating()
        {
            // Обчислення рейтингу за кожний модуль
            double rating1 = stRating1.StudentRating();
            double rating2 = stRating2.StudentRating();

            // Середній рейтинг за семестр
            double averageRating = (rating1 + rating2) / 2;

            Console.WriteLine($"Рейтинг студента за 1 модуль = {rating1}");
            Console.WriteLine($"Рейтинг студента за 2 модуль = {rating2}");
            Console.WriteLine($"Середній рейтинг за семестр = {averageRating}");

            // Оцінка на основі середнього рейтингу
            switch (averageRating)
            {
                case >= 82:
                    Console.WriteLine("Привіт відмінникам");
                    break;
                case <= 60:
                    Console.WriteLine("Перездача! Треба краще вчитися!");
                    break;
                default:
                    Console.WriteLine("Можна вчитися ще краще!");
                    break;
            }
        }
    }

    // Головний клас програми
    class Program
    {
        static void Main(string[] args)
        {
            // Створення екземпляра студента
            var newSt = new Student("Гончаров", "студент", 17, "МНТУ", "I-31", 3);

            Console.WriteLine($"Прізвище = {newSt.Name}");
            Console.WriteLine($"Вік = {newSt.Age}");
            Console.WriteLine($"Факультет = {newSt.Faculty}");
            Console.WriteLine($"Група = {newSt.Group}");
            Console.WriteLine($"Курс = {newSt.Course}");

            // Виведення рейтингу
            newSt.MyRating();

            Console.ReadKey();
        }
    }

}
