using System;

public class Student : IComparable
{
    public string Name { get; set; }
    public int StartYear { get; set; }

    public char GetFirstCharacter
    {
        get { return char.ToUpper(this.Name[0]); }
    }

    public int CompareTo(object obj)
    {
        return this.StartYear.CompareTo((obj as Student).StartYear);
    }

    public int CountSemester()
    {
        return (DateTime.Now.Year - this.StartYear) * 2;
    }

    public void CreateInstanceFromString(string input)
    {
        if (input.Contains("#"))
            throw new FormatException("not valid format");
        else
        {
            // input = [name]%[year]

            this.Name = input.Split('%')[0];
            this.StartYear = int.Parse(input.Split('%')[1]);
        }
    }
}