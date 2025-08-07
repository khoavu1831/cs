class Run()
{
    public static void Main(string[] args)
    {
        HandleFunctions handleFunctions = new HandleFunctions();
        handleFunctions.PrintRandomSalaries();
    }
}

class HandleFunctions
{
    public string RandomSalaries()
    {
        string s = "";
        Random rd = new Random();
        for (int i = 0; i < rd.Next(5); i++)
        {
            s += rd.Next(200).ToString() + ",";
        }
        if (s.Length > 0)
        {
            s = s.Substring(0, s.Length - 1);
        }
        return s;
    }
    public int CheckEvenMonth(int month)
    {
        if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12)
        {
            return 31;
        }

        return 30;
    }

    public void PrintRandomSalaries()
    {
        int i = 0;
        string s = "";
        int daysCount = 20;
        int day = 1;
        int month = 1;
        int maxDay;

        while (i < daysCount)
        {
            if (month == 2)
            {
                maxDay = 29;
            }
            else
            {
                maxDay = CheckEvenMonth(month);
            }


            if (day == maxDay + 1)
            {
                day = 1;
                month++;
                if (month > 12)
                {
                    month = 1;
                }
            }

            s += "+" + day + "/" + month + ":" + RandomSalaries() + "\n";
            day++;
            i++;
        }
        Console.Write(s);
    }

}