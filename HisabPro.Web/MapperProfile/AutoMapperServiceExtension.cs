namespace HisabPro.Web.MapperProfile
{
    public static class AutoMapperServiceExtension
    {
        public static void ConfigureAutoMappers(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile));
        }
    }
}
