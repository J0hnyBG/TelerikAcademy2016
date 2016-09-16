using System;
using System.Linq;
using System.Collections.Generic;

public class Student
{
    private const string NullOrEmptyErrorMessage = "{0} cannot be null or empty!";
    private string firstName;
    private string lastname;
    private IList<Exam> exams;

    public Student(string firstName, string lastName, IList<Exam> exams)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Exams = exams;
    }

    public string FirstName
    {
        get
        {
            return this.firstName;
            
        }

        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(
                    nameof(value),
                    string.Format(NullOrEmptyErrorMessage, nameof(this.FirstName)));
            }

            this.firstName = value;
        }
    }

    public string LastName
    {
        get
        {
            return this.lastname;
            
        }

        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(
                    nameof(value),
                    string.Format(NullOrEmptyErrorMessage, nameof(this.LastName)));
            }

            this.lastname = value;
        }
    }

    public IList<Exam> Exams
    {
        get
        {
            return this.exams;
        }

        set
        {
            if (value == null)
            {
                throw new ArgumentNullException(
                    nameof(this.Exams),
                    "Exams cannot be null!");
            }

            this.exams = value;
        }
    }

    public IList<ExamResult> CheckExams()
    {
        if (this.Exams.Count == 0)
        {
            Console.WriteLine("The student has no exams!");
            return null;
        }

        IList<ExamResult> results = new List<ExamResult>();
        for (int i = 0; i < this.Exams.Count; i++)
        {
            results.Add(this.Exams[i].Check());
        }

        return results;
    }

    public double CalcAverageExamResultInPercents()
    {
        if (this.Exams.Count == 0)
        {
            // No exams --> return -1;
            return -1;
        }

        double[] examScore = new double[this.Exams.Count];
        IList<ExamResult> examResults = this.CheckExams();

        for (int i = 0; i < examResults.Count; i++)
        {
            examScore[i] = 
                ((double)examResults[i].Grade - examResults[i].MinGrade) / 
                (examResults[i].MaxGrade - examResults[i].MinGrade);
        }

        return examScore.Average();
    }
}
