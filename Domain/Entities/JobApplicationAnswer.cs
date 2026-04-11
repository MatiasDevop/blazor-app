namespace Domain.Entities
{
    public class JobApplicationAnswer
    {
        public Guid Id { get; set; }

        public Guid JobApplicationId { get; set; }
        public JobApplication JobApplication { get; set; } = null!;

        public Guid ApplicationQuestionId { get; set; }
        public ApplicationQuestion Question { get; set; } = null!;

        public string AnswerText { get; set; } = string.Empty;
    }
}
