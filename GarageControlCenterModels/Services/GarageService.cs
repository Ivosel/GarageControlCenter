using GarageControlCenterBackend.Models;
using GarageControlCenterBackend.DBContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GarageControlCenterBackend.Services
{
    public class GarageService
    {
        private readonly GarageDbContext _context;
        private readonly ILogger<GarageService> _logger;


        public GarageService(GarageDbContext context, ILogger<GarageService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<List<Garage>> GetAllGaragesAsync()
        {
            try
            {
                return await _context.Garages.Include(g => g.Levels)
                                             .ThenInclude(l => l.Spots)
                                             .Include(g => g.Tickets)
                                             .Include(g => g.Users)
                                             .ThenInclude(u => u.UserTicket)
                                             .ToListAsync();
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting all garages.");
                throw;
            }
        }

        public async Task AddGarageAsync(Garage garage)
        {
            try
            {
                _context.Garages.Add(garage);
                await _context.SaveChangesAsync();
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while adding a garage.");
                throw;
            }
        }

        public async Task UpdateTicketAsync(Ticket updatedTicket)
        {
            try
            {
                var existingTicket = await _context.Tickets.FindAsync(updatedTicket.Id);
                if (existingTicket != null)
                {
                    existingTicket.MarkTicketPaid();
                    await _context.SaveChangesAsync();
                }

                else
                {
                    _logger.LogWarning($"Ticket with id {updatedTicket.Id} not found.");
                }
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while updating ticket with id: {updatedTicket.Id}.");
                throw;
            }
        }

        public async Task AddTicketAsync(Ticket ticket)
        {
            try
            {
                _context.Tickets.Add(ticket);
                await _context.SaveChangesAsync();
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while adding a ticket.");
                throw;
            }
        }

        public async Task RemoveTicketAsync(Ticket ticket)
        {
            try
            {
                var existingTicket = await _context.Tickets.FindAsync(ticket.Id);
                if (existingTicket != null)
                {
                    _context.Tickets.Remove(existingTicket);
                    await _context.SaveChangesAsync();
                }

                else
                {
                    _logger.LogWarning($"Ticket with id {ticket.Id} not found.");
                }
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while removing ticket with id: {ticket.Id}.");
                throw;
            }
        }


        public async Task OccupyParkingSpotAsync(ParkingSpot updatedSpot)
        {
            try
            {
                var existingSpot = await _context.ParkingSpots.FindAsync(updatedSpot.Id);
                if (existingSpot != null)
                {
                    existingSpot.ReserveSpot();
                    await _context.SaveChangesAsync();
                }

                else
                {
                    _logger.LogWarning($"Parking spot with id {updatedSpot.Id} not found.");
                }
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while occupying parking spot with id: {updatedSpot.Id}.");
                throw;
            }
        }

        public async Task ReleaseParkingSpotAsync(ParkingSpot updatedSpot)
        {
            try
            {
                var existingSpot = await _context.ParkingSpots.FindAsync(updatedSpot.Id);
                if (existingSpot != null)
                {
                    existingSpot.ReleaseSpot();
                    await _context.SaveChangesAsync();
                }

                else
                {
                    _logger.LogWarning($"Parking spot with id {updatedSpot.Id} not found.");
                }
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while releasing parking spot with id: {updatedSpot.Id}.");
                throw;
            }
        }
    }
}
