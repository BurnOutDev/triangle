using System;

namespace ReserveProject.Domain.Shared.Abstract
{
    public interface ICreateDateTrackedEntity
    {
        DateTimeOffset CreateDate { get; set; }
    }
}