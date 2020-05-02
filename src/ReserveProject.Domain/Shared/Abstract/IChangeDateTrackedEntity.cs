using System;

namespace ReserveProject.Domain.Shared.Abstract
{
    public interface IChangeDateTrackedEntity
    {
        DateTimeOffset LastChangeDate { get; set; }
    }
}