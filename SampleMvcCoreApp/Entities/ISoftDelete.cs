﻿namespace SampleMvcCoreApp.Entities
{
    public interface ISoftDelete
    {
        bool IsDeleted { get; set; }
    }
}
