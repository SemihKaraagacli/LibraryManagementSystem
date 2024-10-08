using FluentValidation;
using LibraryManagementSystem_EFCore_.Models.Book.ViewModel;

namespace LibraryManagementSystem_EFCore_.Models.Book.Validations
{
    public class CreateBookValidation : AbstractValidator<CreateBookViewModel>
    {
        public CreateBookValidation()
        {
            RuleFor(x => x.Author).NotEmpty().WithMessage("The Author field cannot be null.");
            RuleFor(x => x.PublicationYear).NotEmpty().WithMessage("The PublicationYear field cannot be null.");
            RuleFor(x => x.ISBN).NotEmpty().WithMessage("The ISBN field cannot be null.");
            RuleFor(x => x.Genre).NotEmpty().WithMessage("The Genre field cannot be null.");
            RuleFor(x => x.Publisher).NotEmpty().WithMessage("The Publisher field cannot be null.");
            RuleFor(x => x.PageCount).NotEmpty().WithMessage("The PageCount field cannot be null.");
            RuleFor(x => x.Language).NotEmpty().WithMessage("The Language field cannot be null.");
            RuleFor(x => x.Summary).NotEmpty().WithMessage("The Summary field cannot be null.");
            RuleFor(x => x.AvailableCopies).NotEmpty().WithMessage("The AvailableCopies field cannot be null.");
            RuleFor(x => x.Title).NotEmpty().WithMessage("The Title field cannot be null.");
        }
    }
}
