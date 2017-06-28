namespace GamePlatformer.Utils
{
    public enum PlatformType
    {
        Desktop,
        Android,
        Ios
    }
    
    public interface IPlatform
    {
        PlatformType PlatformType
        {
            get;
        }
    }
}
