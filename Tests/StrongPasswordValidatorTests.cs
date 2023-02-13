using PaaswordStrongValidation;

namespace Tests
{
    [TestClass]
    public class StrongPasswordValidatorTests
    {
        private PasswordPolicy _passwordPolicy;

        [TestMethod]
        public void Validate_WhenPasswordIsCorrect()
        {
            const string password = "AAss11#%";

            var result = new StrongPasswordValidator().Validate(password, this._passwordPolicy);

            Assert.IsTrue(result, "The password should be correct.");
        }

        [TestMethod]
        public void Validate_WhenPasswordIsWrong_NotAllowedSpecSymbols()
        {
            const string password = "AAss11@@";

            var result = new StrongPasswordValidator().Validate(password, this._passwordPolicy);

            Assert.IsFalse(result, "The password should be wrong.");
        }

        [TestInitialize]
        public void Setup()
        {
            this._passwordPolicy = new PasswordPolicy
            {
                Length = 8,
                DigitCount = 2,
                LowercaseCount = 2,
                UppercaseCount = 2,
                SpecialCharacterCount = 2,
                AllowedSpecialCharacters = "%$#"
            };
        }
    }
}