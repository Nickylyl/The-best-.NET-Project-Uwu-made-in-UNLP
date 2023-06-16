namespace Aseguradora.Aplicacion;
public class ObtenerSiniestroUseCase
{
    IRepoSiniestro _repo;
    public ObtenerSiniestroUseCase(IRepoSiniestro repo)
    {
        _repo = repo;
    }
    public Siniestro? Ejecutar(int Id)
    {
        return _repo.ObtenerSiniestro(Id);
    }
}