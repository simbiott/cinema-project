using Cinema.Models;
using Cinema.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Cinema.General.Pages.Sessions
{
    public class SessionsModel : PageModel
    {
        private readonly ISessionRepository _db;

        public SessionsModel(ISessionRepository db)
        {
            _db = db;
        }

        public Session Session { get; private set; }

        public void OnGet(int id)
        {
            Session = _db.GetByID(id);
        }
        
        public void OnPostReservePlaces(int id)
        {
            Session = _db.GetByID(id);
            foreach (var place in Session.Places)
            {
                place.Position = 0;
                place.Row = 0;
            }

            _db.Update(Session);
        }
    }
}
