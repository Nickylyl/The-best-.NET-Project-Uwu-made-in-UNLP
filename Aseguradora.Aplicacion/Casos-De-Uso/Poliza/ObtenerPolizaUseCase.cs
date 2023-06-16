namespace Aseguradora.Aplicacion;
public class ObtenerPolizaUseCase
{
    IRepoPoliza _repo;
    public ObtenerPolizaUseCase(IRepoPoliza repo)
    {
        _repo = repo;
    }
    public Poliza? Ejecutar(int Id)
    {
        return _repo.ObtenerPoliza(Id);
    }
}