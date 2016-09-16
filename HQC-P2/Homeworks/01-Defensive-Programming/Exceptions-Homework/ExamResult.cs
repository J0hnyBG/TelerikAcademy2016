using System;

public class ExamResult
{
    private const string GreaterThanOrEqualToZeroErrorMessage = "{0} must be greater than or equal to 0.";

    private int grade;
    private int minGrade;
    private int maxGrade;
    private string comments;

    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        this.Grade = grade;
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Comments = comments;
    }

    public int Grade
    {
        get
        {
            return this.grade;
        }

        private set
        {
            if (value < 0)
            {
                throw new ArgumentException(string.Format(GreaterThanOrEqualToZeroErrorMessage, "Grade"));
            }

            this.grade = value;
        }
    }

    public int MinGrade
    {
        get
        {
            return this.minGrade;
        }

        private set
        {
            if (value < 0)
            {
                throw new ArgumentException(string.Format(GreaterThanOrEqualToZeroErrorMessage, "Minimum grade"));
            }

            this.minGrade = value;
        }
    }

    public int MaxGrade
    {
        get
        {
            return this.maxGrade; 
            
        }

        private set
        {
            if ( value < 0 )
            {
                throw new ArgumentException(string.Format(GreaterThanOrEqualToZeroErrorMessage, "Maximum grade"));
            }

            this.maxGrade = value;
        }
    }

    public string Comments
    {
        get
        {
            return this.comments; 
        }

        private set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(nameof(this.Comments));
            }

            this.comments = value;
        }
    }
}
