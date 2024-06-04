using api.Data;
using api.Interfaces;
using api.Models;

namespace api.Repositories
{
    public class LinkRepository : ILinkRepository
    {
        private readonly AppDbContext _context;
        public LinkRepository(AppDbContext context)
        {
            _context = context;
        }

        public object? GetLinksForUser(int userId)
        {
            var links = _context.UserLinks.Where(ua => ua.UsersId == userId).Select(uL => uL.Link).ToList();
            return links;
        }

        public Link Insert(int userId, Link link)
        {
            _context.Links.Add(link);
            var user = _context.Users.Find(userId);
            user?.UserLinks.Add(new UserLink { Link = link });
            _context.SaveChanges();
            return link;
        }

        public int Remove(int linkId)
        {
            var link = _context.Links.Find(linkId);
            if (link == null) return 0;
            _context.Links.Remove(link);
            _context.SaveChanges();
            return linkId;
        }

        public Link Update(int linkId, Link link)
        {
            var link_db = _context.Links.Find(linkId);

            if (link_db == null) return null;

            link_db.LinkContent = link.LinkContent;

            _context.Links.Update(link_db);
            _context.SaveChanges();
            return link_db;
        }
    }
}
