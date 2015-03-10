namespace Nardax.Serialization
{
    public interface ISerializer<TOriginal, TDestination>
    {
        TDestination Serialize(TOriginal value);

        TOriginal Deserialize(TDestination bytes);
    }
}
