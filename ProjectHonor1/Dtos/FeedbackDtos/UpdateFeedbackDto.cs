namespace ProjectHonor1.Dtos.FeedbackDtos
{
    public class UpdateFeedbackDto
    {
        public int Id { get; set; }
        public string? TITLE { get; set; }
        public string? Description { get; set; }
        public int CategoryId { get; set; }
        public int StatusId { get; set; }
    }
}
