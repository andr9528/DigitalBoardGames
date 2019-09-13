using System;

namespace Chess.Repository.Core
{
    public interface IEntity
    {
        int Id { get; set; }
        Byte[] RowVersion { get; set; }
    }
}