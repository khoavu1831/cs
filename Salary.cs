class Salary
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
    public string RandomGenSalariesString(int daysCount, int startDay, int startMonth)
    {
        int i = 0;
        string s = "";
        int day = startDay;
        int month = startMonth;
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
        return s;
    }

    public int TotalGoodSalaries(string s)
    {
        int totalOfSalaries = 0;
        int i = 0;
        List<int> salaries = new List<int>();

        while (i < s.Length)
        {
            if (s[i] == '-') break;

            if (s[i + 1] == '+')
            {
                i++;
            }

            if (s[i] == ':')
            {
                string salary = "";

                while (i < s.Length && s[i] != '+' && s[i] != '-')
                {
                    if (s[i] >= '0' && s[i] <= '9')
                    {
                        salary += s[i];
                    }
                    else if (s[i] == ',')
                    {
                        salaries.Add(Convert.ToInt32(salary));
                        salary = "";
                    }

                    i++;
                }
                salaries.Add(Convert.ToInt32(salary));

                if (i < s.Length && s[i] == '-') break;
            }
            i++;
        }

        foreach (var salary in salaries)
        {
            totalOfSalaries += salary;
        }

        return totalOfSalaries;
    }
    public int TotalBadSalaries(string s)
    {
        int totalOfSalaries = 0;
        int i = 0;
        List<int> salaries = new List<int>();

        while (i < s.Length)
        {
            if (s[i] == '-')
            {
                while (i < s.Length && s[i] != ':')
                {
                    i++;
                }
                string salary = "";

                while (i < s.Length && s[i] != '-')
                {
                    if (s[i] >= '0' && s[i] <= '9')
                    {
                        salary += s[i];
                    }
                    else if (s[i] == ',')
                    {
                        salaries.Add(Convert.ToInt32(salary));
                        salary = "";
                    }

                    i++;
                }
                salaries.Add(Convert.ToInt32(salary));
            }
            i++;
        }

        foreach (var salary in salaries)
        {
            totalOfSalaries += salary;
        }

        return totalOfSalaries;
    }

    public void SalaryInfo(string s)
    {
        string raw = s;
        string input = raw.Replace("\n", "").Replace("\r", "").Replace(" ", "");
        int luong = TotalGoodSalaries(input);
        int tieu = TotalBadSalaries(input);
        int total = luong - tieu;

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"+Tien luong: {luong}");
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine($"-Tien tieu: {tieu}");

        if (total > 0)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"=Tong tien: {total}");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"=Tong tien: {total}");
            Console.ResetColor();
        }
    }
}