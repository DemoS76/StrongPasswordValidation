namespace PaaswordStrongValidation
{
    /// <summary>
    /// The password validator.
    /// </summary>
    public class StrongPasswordValidator
    {
        private byte _lowercase = 0;

        private byte _numbers = 0;

        private byte _specSimbols = 0;

        private byte _uppercase = 0;

        public StrongPasswordValidator()
        {
        }

        public virtual bool Validate(string password, PasswordPolicy passwordPolicy)
        {
            if (password.Length < passwordPolicy.Length)
                return false;

            foreach (var symbol in password)
            {
                if (this.IsDigit(symbol))
                    continue;

                if (this.IsLetter(symbol))
                    continue;

                this.IsSpecialSymbol(symbol, passwordPolicy.AllowedSpecialCharacters);
            }

            return this.Validate(passwordPolicy);
        }

        protected virtual bool IsDigit(char c)
        {
            if (char.IsDigit(c))
            {
                _numbers++;

                return true;
            }

            return false;
        }

        protected virtual bool IsLetter(char c)
        {
            if (!char.IsLetter(c))
                return false;

            if (char.IsUpper(c))
            {
                _uppercase++;

                return true;
            }

            if (char.IsLower(c))
            {
                _lowercase++;

                return true;
            }

            return false;
        }

        protected virtual bool IsSpecialSymbol(char c, string allowedSpecialCharacters)
        {
            if (char.IsLetterOrDigit(c))
                return false;

            if (!string.IsNullOrEmpty(allowedSpecialCharacters) && !allowedSpecialCharacters.Contains(c))
                return false;

            _specSimbols++;

            return true;
        }

        protected virtual bool Validate(PasswordPolicy policy)
        {
            if (policy.DigitCount > _numbers)
                return false;

            if (policy.UppercaseCount > _uppercase)
                return false;

            if (policy.LowercaseCount > _lowercase)
                return false;

            if (policy.SpecialCharacterCount > _specSimbols)
                return false;

            return true;
        }
    }
}