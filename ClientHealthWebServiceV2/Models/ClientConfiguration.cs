﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ClientHealthWebServiceV2.Models
{
    public class ClientConfiguration
    {
        [Key]
        public string Id { get; set; }
        public string Configuration { get; set; }
    }
}
