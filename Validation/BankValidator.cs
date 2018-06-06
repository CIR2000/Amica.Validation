using Amica.Models;
using FluentValidation;
using System.Text.RegularExpressions;
using System.Text;

namespace Amica.Validation
{
    public class BankValidator : AbstractValidator<BankAsProperty>
    {
		public BankValidator()
        {
            RuleFor(bank => bank.Name).NotEmpty();
            RuleFor(bank => bank.IbanCode).Must(BeValidIbanCode).When(bank => bank.IbanCode != null);
            RuleFor(bank => bank.BicSwiftCode).Must(BeValidSwiftCode).When(bank => bank.BicSwiftCode != null);
        }

        #region IBAN VALIDATION
        private static bool BeValidIbanCode(string iban)
        {
            if (string.IsNullOrEmpty(iban))
                return false;

            iban = iban.ToUpper();

            if (iban.StartsWith("IT"))
                return IsValidItalianIban(iban);

            return false;
        }
		private static bool IsValidItalianIban(string iban)
        {
            if (iban.Length != 27)
                return false;

            if (Regex.IsMatch(iban, "^[A-Z0-9]"))
            {
                iban = iban.Replace(" ", string.Empty);
                string bank = iban.Substring(4, iban.Length - 4) + iban.Substring(0, 4);
                int asciiShift = 55;
                StringBuilder sb = new StringBuilder();
                foreach (char c in bank)
                {
                    int v;
                    if (char.IsLetter(c)) v = c - asciiShift;
                    else v = int.Parse(c.ToString());
                    sb.Append(v);
                }
                string checkSumString = sb.ToString();
                int checksum = int.Parse(checkSumString.Substring(0, 1));
                for (int i = 1; i < checkSumString.Length; i++)
                {
                    int v = int.Parse(checkSumString.Substring(i, 1));
                    checksum *= 10;
                    checksum += v;
                    checksum %= 97;
                }
                return checksum == 1;
            }
            else
                return false;
        }
        #endregion

        private bool BeValidSwiftCode(string code)
        {
            if (string.IsNullOrEmpty(code))
                return false;

            const string match = "^[A-Z]{6}[A-Z0-9]{2}([A-Z0-9]{3})?$";

            return Regex.IsMatch(code, match);
        }
    }
}
