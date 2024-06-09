using GarageControlCenterBackend.DBContexts;
using GarageControlCenterBackend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

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
                var existingUser = await _context.Users
                    .Include(u => u.UserTicket)
                    .ThenInclude(ut=>ut.TicketEvents)
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
                    _logger.LogInformation($"User {existingUser.Id} updated successfully with ticket {existingUser.UserTicket?.Id}");
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

        public static void ValidateUser(GarageUser user)
        {
            if (string.IsNullOrWhiteSpace(user.FirstName))
            {
                throw new ArgumentException("First name is required");
            }

            if (user.FirstName.Length > 50)
            {
                throw new ArgumentException("First name cannot exceed 50 characters");
            }

            if (string.IsNullOrWhiteSpace(user.LastName))
            {
                throw new ArgumentException("Last name is required");
            }

            if (user.LastName.Length > 50)
            {
                throw new ArgumentException("Last name cannot exceed 50 characters");
            }

            if (!string.IsNullOrEmpty(user.PhoneNumber) && !Regex.IsMatch(user.PhoneNumber, @"^\d{10}$"))
            {
                throw new ArgumentException("Invalid phone number");
            }

            if (!string.IsNullOrEmpty(user.Email) && !new EmailAddressAttribute().IsValid(user.Email))
            {
                throw new ArgumentException("Invalid email address");
            }

            if (string.IsNullOrWhiteSpace(user.RegistrationPlate))
            {
                throw new ArgumentException("Registration plate is required");
            }
        }
    }
}
