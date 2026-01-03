class Library
{
    private Dictionary<int,string> books=new Dictionary<int,string>();
    
    public String this[int id]
    {
        get{return books[id];}
        set{books[id]=value;}
    }

    public String this[String name]
    {
        get{return books.FirstOrDefault(e=>e.Value==name).Value;}
    }
}