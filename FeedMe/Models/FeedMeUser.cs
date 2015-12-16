﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FeedMe.Models
{
    public class FeedMeUser
    {
        [Key] 
        public int FeedMeUserId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}