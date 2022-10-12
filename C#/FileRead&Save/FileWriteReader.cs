public class FileWriteReader : DataType
{
    public static DataTypeFactory factory(string type)
    {
        DataTypeFactory factory = null;
        switch (type)
        {
            case "json":
                factory = new FileJson();
                break;
            case "xml":
                factory = new FileXml();
                break;
            default:
                break;
        }
        return factory;
    }
}
