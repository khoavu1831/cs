class Draw
{
    public void DrawSpace(int spaceFlag)
    {
        for (int spaceIndex = 1; spaceIndex <= spaceFlag; spaceIndex++)
        {
            Console.Write(":");
        }
    }
    public void DrawStar(int starFlag)
    {
        int index = 0;
        for (int starIndex = 1; starIndex <= starFlag; starIndex++)
        {
            // Console.Write(starIndex);
            int tmpIndex = starIndex;
            if (starFlag > 9)
            {
                index++;
                if (index > 9)
                {
                    index = 0;
                }
                tmpIndex = index;
            }
            Console.Write(tmpIndex);
        }
    }
    public void LoopDrawInLine(int looper, int spaceFlag, int starFlag)
    {
        for (int i = 0; i < looper; i++)
        {
            DrawSpace(spaceFlag);
            DrawStar(starFlag);
            DrawSpace(spaceFlag);
        }
        DrawEndline();
    }
    public void DrawEndline() => Console.WriteLine();
    public void Drawing(int loop, int n)
    {
        int i = 1;
        while (i <= n)
        {
            var starFlag = 2 * i - 1;
            var spaceFlag = n - i;
            LoopDrawInLine(loop, spaceFlag, starFlag);
            i++;
        }
    }
    public void ReverseDrawing(int loop, int n)
    {
        int i = n - 1;
        while (i > 0)
        {
            var starFlag = 2 * i - 1;
            var spaceFlag = n - i;
            LoopDrawInLine(loop, spaceFlag, starFlag);
            i--;
        }
    }
    public void DrawAll(int loop, int lines)
    {
        int maxLoop = 7;
        int bonusLoop = loop - maxLoop;
        if (loop <= maxLoop)
        {
            Drawing(loop, lines);
            ReverseDrawing(loop, lines);
        }
        else
        {
            int loopCount = 0;
            while (loopCount < loop)
            {
                Drawing(maxLoop, lines);
                ReverseDrawing(maxLoop, lines);
                Drawing(bonusLoop, lines);
                ReverseDrawing(bonusLoop, lines);
                loopCount++;
            }
        }
    }
}