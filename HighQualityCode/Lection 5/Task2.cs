public class Potatoes 
{
    public bool IsPeeled { get; set; }

    public bool IsRotten { get; set; }
}

public class Mixed // naming is only for test purpose. just check only the two if statements 
{
    private const int FIELD_START_X = 0;
    private const int FIELD_END_X = 0;
    private const int FIELD_START_Y = 0;
    private const int FIELD_END_Y = 0;

    public void Cook(Potatoes potato)
    {
        // ... 
        if (potato != null)
        {
            if (potato.IsPeeled && !potato.IsRotten)
            {
                Cook(potato);
            }
        }
    }

    public void CheckVisited(int x, int y)
    {
        bool allowVisit = true;

        if ((x >= FIELD_START_X && x <= FIELD_END_X && y >= FIELD_START_Y && y <= FIELD_END_Y) && allowVisit)
        {
            VisitCell();
        }
    }

    private void VisitCell()
    {
        throw new System.NotImplementedException();
    }
}