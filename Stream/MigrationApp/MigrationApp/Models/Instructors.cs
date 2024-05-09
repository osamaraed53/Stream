﻿namespace Migration.Models;

public class Instructor
{
    public int Id { set; get; }
    public string? FName { get; set; }
    public string? LName { get; set; }

    public int? OfficeId { get; set; }
    public Office? Office { get; set; }

    public ICollection<Section> Sections { get; set; } = new List<Section>();
} 

