using System.ComponentModel.DataAnnotations;

namespace WorkList.Api.Features.Authentication.DTOs;

public record RegisterRequest(
    [Required]
    [RegularExpression(
        @"^[A-Za-z][A-Za-z0-9_]{2,29}$",
        ErrorMessage = "Username must be 3-30 characters and contain only letters, numbers, and underscores."
    )]
    string Username,
    [Required]
    [StringLength(128, MinimumLength = 8)]
    string Password
);