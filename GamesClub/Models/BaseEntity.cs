﻿namespace GamesClub.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        [MaxLength(255)]
        public string Name { get; set; } = string.Empty;
    }
}
