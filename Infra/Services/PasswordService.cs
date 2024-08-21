using Application.Interfaces;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
namespace Infra.Services
{
    public partial class PasswordService : IPasswordService
    {
        private const char Delimeter = '.';
        private static readonly int Iterations = 10000; //
        private static readonly int SaltSize = 128 / 8; // 128 bit
        private static readonly int KeySize = 256 / 8; // 256 bit
        private static readonly HashAlgorithmName HashAlgorithmName = HashAlgorithmName.SHA256;

        public string Hash(string password)
        {
            if (!HasNumber().IsMatch(password))
                throw new Exception("A senha tem que ter pelo menos um número.");

            if (!HasUpperChar().IsMatch(password))
                throw new Exception("A senha tem que ter pelo menos uma letra maiúscula.");

            if (!HasLowerChar().IsMatch(password))
                throw new Exception("A senha tem que ter pelo menos uma letra minúscula.");

            if (!HasMinimum8Chars().IsMatch(password))
                throw new Exception("A senha tem que ter pelo menos 8 caracteres.");

            if (!HasSpecialCharacter().IsMatch(password))
                throw new Exception("A senha tem que ter pelo um caracter especial.");

            var salt = RandomNumberGenerator.GetBytes(SaltSize);
            var hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, HashAlgorithmName, KeySize);

            return string.Join(Delimeter, Convert.ToBase64String(salt), Convert.ToBase64String(hash));
        }

        public bool Verify(string passwordHash, string password)
        {
            var elements = passwordHash.Split(Delimeter);

            if (elements.Length != 2)
                return false;

            var salt = Convert.FromBase64String(elements[0]);
            var hash = Convert.FromBase64String(elements[1]);

            var hashInput = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, HashAlgorithmName, KeySize);

            return CryptographicOperations.FixedTimeEquals(hash, hashInput);
        }


        [GeneratedRegex(@"[!@#$%^&*()_+{}[\]:;<>,.?~\\-]+")]
        private static partial Regex HasSpecialCharacter();

        [GeneratedRegex(@"[0-9]+")]
        private static partial Regex HasNumber();

        [GeneratedRegex(@"[A-Z]+")]
        private static partial Regex HasUpperChar();

        [GeneratedRegex(@"[a-z]+")]
        private static partial Regex HasLowerChar();

        [GeneratedRegex(@".{8,}")]
        private static partial Regex HasMinimum8Chars();
    }
}