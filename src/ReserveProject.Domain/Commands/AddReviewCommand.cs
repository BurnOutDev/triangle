using ReserveProject.Domain.Commands.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveProject.Domain.Commands
{
    public class AddReviewCommand
    {
        public int ReservationId { get; set; }
        public string Content { get; set; }
        public decimal Stars { get; set; }
        public ICollection<MediaItem> MediaItems { get; set; }

        public class MediaItem
        {
            public string Base64 { get; set; }
            public string Format { get; set; }
        }
    }

    public class AddReviewCommandResult : CommandResult
    {
    }
}
