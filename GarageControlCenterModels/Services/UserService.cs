using GarageControlCenterBackend.DBContexts;
using GarageControlCenterBackend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GarageControlCenterBackend.Services
{
    public class UserService
    {
        private readonly GarageDbContext _context;
        private readonly ILogger<UserService> _logger;

        public UserService(GarageDbContext context, ILogger<UserService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task AddUserAsync(GarageUser user)
        {
            try
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while adding a user.");
                throw;
            }
        }

        public async Task UpdateUserAsync(GarageUser updatedUser)
        {
            try
            {
                var existingUser = await _context.Users.Include(u => u.UserTicket)
                                                       .FirstOrDefaultAsync(u => u.Id == updatedUser.Id);
                if (existingUser != null)
                {
                    existingUser.UpdateUser(
                        updatedUser.LastName,
                        updatedUser.FirstName,
                        updatedUser.PhoneNumber,
                        updatedUser.Email,
                        updatedUser.RegistrationPlate
                    );

                    if (updatedUser.UserTicket != null)
                    {
                        UpdateUserTicket(existingUser.UserTicket, updatedUser.UserTicket);
                    }

                    await _context.SaveChangesAsync();
                }

                else
                {
                    _logger.LogWarning($"User with id {updatedUser.Id} not found.");
                }
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while updating user with id: {updatedUser.Id}.");
                throw;
            }
        }

        public async Task DeleteUserAsync(int id)
        {
            try
            {
                var user = await _context.Users.Include(u => u.UserTicket)
                                               .FirstOrDefaultAsync(u => u.Id == id);
                if (user != null)
                {
                    _context.Users.Remove(user);
                    await _context.SaveChangesAsync();
                }

                else
                {
                    _logger.LogWarning($"User with id {id} not found.");
                }
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while deleting user with id: {id}.");
                throw;
            }
        }

        private void UpdateUserTicket(UserTicket existingTicket, UserTicket updatedTicket)
        {
            existingTicket.ExtendTicket(updatedTicket.ValidUntil);
            existingTicket.ChangeTicketType(updatedTicket.Type);

            if (updatedTicket.GetBlockedInfo())
            {
                existingTicket.BlockTicket();
            }

            else
            {
                existingTicket.UnblockTicket();
            }

            if (updatedTicket.GetNeutralInfo())
            {
                existingTicket.SetToNeutral();
            }
        }
    }
}
