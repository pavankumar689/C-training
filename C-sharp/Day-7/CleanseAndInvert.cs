class CleanseAndInvert
{
    private string Password;
    public CleanseAndInvert(String password)
    {
        Password=password;
    }

    public string GeneratePassword(string Password)
    {
        string modified="";
        foreach(char c in Password)
        {
            if (((int)c % 2 == 1))
            {
                modified+=c;
            }
        }
        string reversed=Reversed(modified);
        string finalstring="";
        for(int i = 0; i < reversed.Length; i++)
        {
            if (i % 2 == 0)
            {
                finalstring+=reversed[i].ToString().ToUpper();
            }
            else
            {
                finalstring+=reversed[i];
            }
        }
        return finalstring;
    }
    public string Reversed(string s)
    {
        string newstring="";
        for(int i = s.Length - 1; i >= 0; i--)
        {
            newstring+=s[i];
        }
        return newstring;
    }
}