using SampleMvcCoreApp.IEntities;

namespace SampleMvcCoreApp.Entities
{
    public class UserContext : IUserContext
    {
        int IUserContext.GetUserId()
        {
            return 1;
        }

        string IUserContext.GetUserName()
        {
            return "Imdadhusen";
        }
    }
}
