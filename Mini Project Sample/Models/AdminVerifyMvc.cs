﻿namespace Mini_Project_Sample.Models
{
    public class AdminVerifyMvc
    {
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; } = new byte[32];
        public byte[] PasswordSalt { get; set; } = new byte[32];
       
    }
}
