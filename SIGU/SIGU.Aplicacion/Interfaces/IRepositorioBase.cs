namespace SIGU.Aplicacion.Interfaces;

public interface IRepositorioBase<T>
{
	void Agregar(T entidad);
	void Modificar(T entidad, Guid id);
	void Eliminar(Guid id);
	List<T>? Listar();
	T? ObtenerPorID(Guid id);

}