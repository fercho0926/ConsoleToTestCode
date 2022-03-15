namespace ArraysAndCollections.BaseClass
{
    public class BaseClassDef
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string[] ArrayAddress { get; set; }

        public BaseClassDef(int id, string name, string lastname,string[] arrayAddress )
        {
            Id = id;
            Name = name;
            Lastname = lastname;
            ArrayAddress = arrayAddress;
    }
        public override string ToString() => $"Id: {Id}, Name: {Name}, Lastname: {Lastname} ";
    }
}
