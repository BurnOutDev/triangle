using ReserveProject.Domain.Enums;
using System;

namespace ReserveProject.Domain.Shared.Abstract
{
    public interface IBaseEntity
    {
        int Id { get; set; }
        Guid UId { get; set; }
        EntityStatus EntityStatus { get; }
    }
}