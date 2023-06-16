namespace Aseguradora.Aplicacion;
public class ObtenerTerceroUseCase
{
    IRepoTercero _repo;
    public ObtenerTerceroUseCase(IRepoTercero repo)
    {
        _repo = repo;
    }
    public Tercero? Ejecutar(int Id)
    {
        return _repo.ObtenerTercero(Id);
    }
}