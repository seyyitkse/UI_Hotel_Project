namespace HotelProject.WebUI.Dtos.BookingDto
 {
    public class CreateBookingDto
    {
        public string Name { get; set; }
        public string Mail { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int AdultCount { get; set; }
        public int ChildCount { get; set; }
        public int RoomCount { get; set; }
        public decimal TotalPrice { get; set; }
        public string SpecialRequests { get; set; }
        public string Description { get; set; }
    }
}
