namespace Staff_database
{
    public interface IReader
    {
        string readAttribute(string name, string item = null, string attribute = null);
    }
}
