namespace Client.Schema.Information
{
    public abstract class InformationSchema
    {
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}