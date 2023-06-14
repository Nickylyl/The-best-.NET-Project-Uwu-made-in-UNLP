namespace Aseguradora.Aplicacion;
public interface IRepoSiniestro
{
    public void AgregarSiniestro(Siniestro S);
    public void ModificarSiniestro(Siniestro S);
    public void EliminarSiniestro(int S);
    public List<Siniestro> ListarSiniestros();
}