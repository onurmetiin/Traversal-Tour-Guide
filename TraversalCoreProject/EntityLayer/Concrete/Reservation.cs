using System;
namespace EntityLayer.Concrete
{
	public class Reservation
	{
		public int ReservationID { get; set; }
        public int DestinationID { get; set; }
		public int appUserID { get; set; }
		public AppUser appUser { get; set; }
		public string PersonCount { get; set; }
		public DateTime ReservationDate { get; set; }
		public string Description { get; set; }
		public string Status { get; set; }

		public Destination Destination { get; set; }
	}
}

