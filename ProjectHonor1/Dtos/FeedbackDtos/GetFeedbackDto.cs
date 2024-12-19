namespace ProjectHonor1.Dtos.GetFeedbackDtos
{
    public class GetFeedbackDto
    {
        public int Id { get; set; }
        public string? TITLE { get; set; }
        public string? Description { get; set; }
        public int? CategoryId { get; set; }
        public int? StatusId { get; set; }
        public string? CategoryName { get; set; } //Category Adı döndürmek için
        public string? StatusName { get; set; } // Status adını döndürmek için 
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
