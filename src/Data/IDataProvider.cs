namespace Data
{
    public interface IDataProvider
    {
        // Checking is fk values intersect pk values.
        bool IsIntersect(IColumnInfo fk, IColumnInfo pk);
    }
}