namespace SIGU.Aplicacion.Excepciones;

public class DuplicadoException : Exception
{
    public DuplicadoException(string mensaje) : base(mensaje) { }
    public DuplicadoException(string mensaje, Exception innerException) : base(mensaje, innerException) { }
}