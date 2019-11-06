using System;

namespace Repository.Core
{
    public interface IEntity
    {
        int Id { get; set; }
        Byte[] RowVersion { get; set; }
        bool IsInstantiated { get; set; }
    }
}