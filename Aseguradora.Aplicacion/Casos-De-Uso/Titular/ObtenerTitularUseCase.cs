namespace Aseguradora.Aplicacion;
public class ObtenerTitularUseCase
{
    IRepoTitular _repo;
    public ObtenerTitularUseCase(IRepoTitular repo)
    {
        _repo = repo;
    }
    public Titular? Ejecutar(int Id)
    {
        return _repo.ObtenerTitular(Id);
    }
}