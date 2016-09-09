private void CookPotato()
{
    Potato potato;
    //... 
    if (potato != null)
    {
        if (potato.HasBeenPeeled 
            && !potato.IsRotten)
        {
            Cook(potato);
        }
    }
}
   
private void VisitCellAt(int x, int y, bool shouldVisitCell)
{
    bool xPosIsValid = MIN_X <= x && x <= MAX_X;
    bool yPosIsValid = MIN_Y <= y && y <= MAX_Y;

    if (xPosIsValid
        && yPosIsValid
        && shouldVisitCell )
    {
        VisitCell();
    }
}