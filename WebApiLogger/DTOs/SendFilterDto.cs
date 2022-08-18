using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace WebApiLogger.DTOs
{
    public class SendFilterDto
    {
        
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string AcceptorEmail { get; set; } = "";
        [Required]
        public SendType SendType { get; set; }
    }

    public class SendFilterDtoValidator : AbstractValidator<SendFilterDto>
    {
        public SendFilterDtoValidator()
        {
            RuleFor(x => x.StartDate).NotEmpty().WithMessage("Can not be empty");
            RuleFor(x => x.AcceptorEmail).NotEmpty().WithMessage("Email address is required")
                .EmailAddress().WithMessage("Valid emails only");
            RuleFor(x => x.EndDate).NotEmpty().WithMessage("Can not be empty");
            RuleFor(x=>x).Custom((x, context)=>{
                string[] arr = x.AcceptorEmail.Split("@");
                if (arr[1].Trim().ToLower() != "code.edu.az") context.AddFailure("AcceptorEmail", "only code.edu.az emails");
            });
            RuleFor(x => x).Custom((x, context) =>
            {
                double time = (x.EndDate - x.StartDate).TotalMilliseconds;
                if (time < 0) context.AddFailure("EndDate", "Wrong data");
            });
        }
    }
    public enum SendType
    {
        Segment =1,
        Country,
        Product,
        Discounts
    }
}
