using System;

public class CSharpExam : Exam
{
    private int score;

    public CSharpExam(int score)
    {
        this.Score = score;
    }

    public int Score 
    {
        get
        {
            return this.score;
        }

        private set
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentOutOfRangeException("Invalid Score - must be from 0 to 100");
            }
            else
            {
                this.score = value;
            }
        }
    }

    public override ExamResult Check()
    {
        return new ExamResult(2 + this.Score * 4 / 100, 2, 6, "Exam results calculated by score.");
    }
}
