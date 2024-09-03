using BookStream.Application.Commands.BookCommands.InsertBook;
using FluentValidation;

namespace BookStream.Application.Validators;
public class InsertBookValidator : AbstractValidator<InsertBookCommand>
{
    public InsertBookValidator()
    {
        RuleFor(livro => livro.Code)
            .NotEmpty()
                .WithMessage("O código não pode ser vazio.")
            .Length(6)
                .WithMessage("O código deve conter exatamente 6 caracteres.")
            .Matches(@"^[A-Z]{3}\d{3}$")
                .WithMessage("O campo deve conter exatamente 3 letras maiúsculas seguidas de 3 números.")
            .Matches(@"^[a-zA-Z0-9\s]*$")
                .WithMessage("O campo não pode conter caracteres especiais.");

        RuleFor(livro => livro.Title)
            .NotEmpty()
                .WithMessage("O título do livro não pode estar vazio.")
            .MaximumLength(200)
                .WithMessage("Você ultrapassou o limite de caracteres para o título.");
        //.Matches(@"^[a-zA-Z0-9\s]*$")
        //    .WithMessage("O campo não pode conter caracteres especiais.");

        RuleFor(livro => livro.Synopsis)
            .NotEmpty()
                .WithMessage("O campo de sínopse não pode estar vazio .")
            .MaximumLength(375)
                .WithMessage("Você ultrapssou o limite de 5 linhas.");
            //.Matches(@"^[a-zA-Z0-9\s]*$")
            //    .WithMessage("O campo não pode conter caracteres especiais.");

        //RuleFor(livro => livro.Author)
        //    .NotEmpty()
        //        .WithMessage("O nome do autor deve ser informado")
        //    .MaximumLength(100)
        //        .WithMessage("Você ultrapassou a quantidade de caracteres permitidos para o campo Author.")
        //    .Matches(@"^[a-zA-Zà-úÀ-ÚçÇñÑ'\- ]{2,50}$")
        //        .WithMessage("Nome do autor inválido. Contém caracteres especiais ou números.")
        //    .Matches(@"^[a-zA-Z0-9\s]*$")
        //        .WithMessage("O campo não pode conter caracteres especiais.");
        RuleFor(livro => livro.AuthorId)
            .GreaterThan(0)
                .WithMessage("O autor do livro deve ser válido.");

        RuleFor(livro => livro.Publisher)
            .NotEmpty()
                .WithMessage("O campo Editora é obrigatório.")
            .MinimumLength(3)
                .WithMessage("A Editora deve ter pelo menos 3 caracteres.")
            .MaximumLength(100)
                .WithMessage("A Editora não pode ter mais de 100 caracteres.")
            .Matches("^[A-Z][a-zA-Z0-9 ]*$")
                .WithMessage("A Editora deve começar com uma letra maiúscula e conter apenas letras, números e espaços.")
            .Matches(@"^[a-zA-Z0-9\s]*$")
                .WithMessage("O campo não pode conter caracteres especiais.");

        RuleFor(livro => livro.IdGenre)
            .GreaterThan(0)
                .WithMessage("O gênero do livro deve ser válido.");

        RuleFor(livro => livro.UnformatedISBN)
            .NotEmpty()
                .WithMessage("O ISBN é obrigatório.")
            .Must(isbn => isbn.All(char.IsDigit))
                .WithMessage("O ISBN deve conter apenas números.")
            .MaximumLength(13)
                .WithMessage("O ISBN deve ter no máximo 13 caracteres.");

        RuleFor(livro => livro.YearOfPublication)
            .GreaterThan(0)
                .WithMessage("O ano de publicação deve ser válido.")
            .LessThanOrEqualTo(DateTime.Now.Year)
                .WithMessage("O ano de publicação não pode ser no futuro.");

        RuleFor(livro => livro.IdAgeRating)
            .GreaterThanOrEqualTo(0)
                .WithMessage("A classificação indicativa deve ser válida.");



    }
}
