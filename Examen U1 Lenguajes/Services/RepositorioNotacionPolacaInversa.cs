using Examen_U1_Lenguajes.Models.Interfaces;

namespace Examen_U1_Lenguajes.Services;

public class RepositorioNotacionPolacaInversa: INotacionPolacaInversa
{
    public string NotacionPolacaInversa { get; }

    public void ObtenerNotacionPolacaInversa(string notacion)
    {
        
    }

    public string ObtenerNotacionPolacaInversa()
    {
        throw new NotImplementedException();
    }
}