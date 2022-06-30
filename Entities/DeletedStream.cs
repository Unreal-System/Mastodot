using System;
namespace Mastodot.Entities
{
    public class DeletedStream: IStreamEntity
    {
        public long StatusId { get; set; }
    }
}
