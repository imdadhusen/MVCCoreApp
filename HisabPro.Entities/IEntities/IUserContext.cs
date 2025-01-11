namespace HisabPro.Entities.IEntities
{
    public interface IUserContext
    {
        int GetCurrentUserId(bool useFallback = false);
        string GetCurrentUserName();
    }
}
