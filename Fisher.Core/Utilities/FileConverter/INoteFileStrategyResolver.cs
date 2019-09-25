namespace Fisher.Core.Utilities
{
    public interface INoteFileStrategyResolver
    {
        INoteFileConverterStrategy Resolve(FileType type);
    }
}