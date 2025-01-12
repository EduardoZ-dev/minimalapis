namespace MinimalAPIPeliculas.Validaciones
{
    public static class Utilidades
    {
        public static string CampoRequeridoMensaje = "el campo {PropertyName} es requerido";
        public static string MaximumLenghtMensaje = "El campo {PropertyName} debe tener menos de {MaxLength} caracteres";
        public static string PrimeraLetraMayusculaMensaje = "El campo {PropertyName} debe comenzar en Mayuscula";
        public static string EmailMensaje = "El campo {PropertyName} debe ser un email válido";
        
        
        public static string GreaterThanOrEqualToMensaje(DateTime fechaMinima)
        {
            return "El campo {PropertyName} debe ser posterior a " + fechaMinima.ToString("yyyy-MM-dd");
        }


        public static bool PrimeraLetraEnMayus(string valor)
        {
            if (string.IsNullOrWhiteSpace(valor))
            {
                return true;
            }

            var primeraLetra = valor[0].ToString();

            return primeraLetra == primeraLetra.ToUpper();
        }


    }


}
