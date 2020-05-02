using System;

namespace ReserveProject.Domain.Shared.Abstract
{
    public interface IHasSecondaryId
    {
        Guid UId { get; set; }
    }
}