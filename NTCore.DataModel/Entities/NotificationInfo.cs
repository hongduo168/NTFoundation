using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NTCore.DataModel.Entities
{
    public class NotificationInfo : SiteEntity
    {
        [Required, MaxLength(255)]
        public string Title { get; set; }

        public int ReceiverId { get; set; }

        [Required, MaxLength(2000)]
        public string Message { get; set; }

        public bool IsRead { get; set; }


    }
}
