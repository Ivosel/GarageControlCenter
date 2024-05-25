using GarageControlCenterBackend.Models;
using GarageControlCenterBackend.DBContexts;
using Microsoft.EntityFrameworkCore;

namespace GarageControlCenterBackend.Services
{
    public class GarageService
    {
        private readonly GarageDbContext _context;

        public GarageService(GarageDbContext context)
        {
            _context = context;
        }

        public async Task<List<Garage>> GetAllGaragesAsync()
        {
            return await _context.Garages.Include(g => g.Levels)
                                          .ThenInclude(l => l.Spots)
                                          .Include(g => g.Tickets)
                                          .Include(g => g.Users)
                                          .ToListAsync();
        }

        public async Task<Garage> GetGarageByIdAsync(int id)
        {
            return await _context.Garages.Include(g => g.Levels)
                                         .ThenInclude(l => l.Spots)
                                         .Include(g => g.Tickets)
                                         .Include(g => g.Users)
                                         .FirstOrDefaultAsync(g => g.Id == id);
        }

        public async Task AddGarageAsync(Garage garage)
        {
            _context.Garages.Add(garage);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTicketAsync(Ticket updatedTicket)
        {
            var existingTicket = await _context.Tickets.FindAsync(updatedTicket.Id);
            if (existingTicket != null)
            {
                existingTicket.MarkTicketPaid();
            }
            await _context.SaveChangesAsync();
        }

        public async Task AddTicketAsync(Ticket ticket)
        {
            _context.Tickets.Add(ticket);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveTicketAsync(Ticket ticket)
        {
            _context.Tickets.Remove(ticket);
            await _context.SaveChangesAsync();
        }


        public async Task OccupyParkingSpotAsync(ParkingSpot updatedSpot)
        {
            var existingSpot = await _context.ParkingSpots.FindAsync(updatedSpot.Id);
            if (existingSpot != null)
            {
                existingSpot.ReserveSpot();
            }
            await _context.SaveChangesAsync();
        }

        public async Task ReleaseParkingSpotAsync(ParkingSpot updatedSpot)
        {
            var existingSpot = await _context.ParkingSpots.FindAsync(updatedSpot.Id);
            if (existingSpot != null)
            {
                existingSpot.ReleaseSpot();
            }
            await _context.SaveChangesAsync();
        }
    }
}
