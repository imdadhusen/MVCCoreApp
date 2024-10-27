namespace HisabPro.Entities.IEntities
{
    public interface IUserContext
    {
        int GetCurrentUserId();
        string GetCurrentUserName();
    }
}
