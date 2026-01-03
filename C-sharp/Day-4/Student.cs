class Student
{
    private String? name;
    private int age;
    private int marks;

    public String? Name
    {
        get{return name;}
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                name = value;
            }
            else
            {
                Console.WriteLine("Name cannot be empty");
            }
        }
    }
    public int Age
    {
        get{return age;}
        set
        {
            if (value > 0)
            {
                age=value;
            }
            else
            {
                Console.WriteLine("Age cannot be negative");
            }
        }
    } 

    public int Marks
    {
        get{return marks;}
        set
        {
            if(value>=0 && value <= 100)
            {
                marks=value;
            }
            else
            {
                Console.WriteLine("Marks should be inbetween 0 and 100.");
            }
        }
    }

    public int StudentId{get;set;}

    public String Result
    {
        get{
            if(marks>40) 
            return "pass"; 
            else 
            return "Fail";
        }
    }
    private String? password;
    public String Password
    {
        set
        {
            if (value.Length > 6)
            {
                password=value;
            }
            else
            {
                Console.WriteLine("Password should contain atleast 6 characters.");
            }
        }
    }

    private int RegistrationNumber;
    public int Reg
    {
        get;private set;
    }

}
