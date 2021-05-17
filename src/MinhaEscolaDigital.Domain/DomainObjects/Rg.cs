using System.Text.RegularExpressions;

namespace MinhaEscolaDigital.Domain.DomainObjects
{
    public class Rg
    {
        public const int RgMaxLength = 14;
        public string Numero { get; private set; }

        public Rg(string numero)
        {
            if (!Validar(numero)) throw new DomainException("RG inválido");
            Numero = numero;
        }

        public static bool Validar(string rg)
        {            
            var regexRg = new Regex(@"(^\d{1,2}).?(\d{3}).?(\d{3})-?(\d{1}|X|x$)");
            return regexRg.IsMatch(rg);
        }
    }
}