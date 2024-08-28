using System.Threading.Tasks;
using System.Collections.Generic;
namespace LogicLyric
{
    public interface IPacketHandler
    {
        Task HandleAsync(object request);
    }
}
