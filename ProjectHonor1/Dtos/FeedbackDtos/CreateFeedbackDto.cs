namespace ProjectHonor1.Dtos.FeedbackDtos
{
    public class CreateFeedbackDto
    {
        public string? TITLE { get; set; }
        public string? Description { get; set; }
        public int? CategoryId { get; set; }
        public int? StatusId { get; set; }

    }
}
