class InputValidator
{
    public static int ReadAge(string input)
    {
        if (int.TryParse(input, out int age))
        {
            return age;
        }

        throw new FormatException("Invalid age input. Please enter a valid number.");
    }
}