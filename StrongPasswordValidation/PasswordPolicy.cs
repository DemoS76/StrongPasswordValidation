namespace PaaswordStrongValidation
{
    public class PasswordPolicy
    {
        /// <summary>
        /// The allowed special characters.
        /// </summary>
        public string AllowedSpecialCharacters { get; set; }

        /// <summary>
        /// The minimal count of digits.
        /// </summary>
        public byte DigitCount { get; set; }

        /// <summary>
        /// The minimal length of password.
        /// </summary>
        public byte Length { get; set; }

        /// <summary>
        /// The minimal count of lowercase characters.
        /// </summary>
        public byte LowercaseCount { get; set; }

        /// <summary>
        /// The minimal count of special characters.
        /// </summary>
        public byte SpecialCharacterCount { get; set; }

        /// <summary>
        /// The  minimal count of uppercase character.
        /// </summary>
        public byte UppercaseCount { get; set; }
    }
}