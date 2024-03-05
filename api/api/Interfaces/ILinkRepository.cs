using api.Models;

namespace api.Interfaces
{
    public interface ILinkRepository
    {
        Link Insert(int userId, Link link);
        int Remove(int linkId);
        Link Update(int linkId, Link link);
    }
}
