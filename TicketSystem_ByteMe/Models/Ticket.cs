﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace TicketSystem_ByteMe.Models
{
  public class Ticket
  {
    [Key]
    public int TicketID { get; set; }

    public string Headline { get; set; }

    public string Description { get; set; }

    public Project Project { get; set; }

    public DateTime CreatedAt { get; set; }
    [Required]
    public Employee CreatedBy { get; set; }
    [Required]
    public Employee AssignedTo { get; set; }
    public DateTime? SolvedAt { get; set; }
  }
}
