

using AplicacionConsola.Clases.Models;
using AplicacionConsola.Database;




Usuario usuario = new Usuario("prueba", "prueba", "prueba", "ad21es", "prueba@gmail.com");


try //OBTENER LISTA
{


    var listaUsuarios=GestorUsuarioData.GetListaUsuarios();

    foreach (var item in listaUsuarios)
    {
        Console.WriteLine(item.Name);
    }


}catch (Exception ex){
    
    Console.WriteLine($"{ex.Message}");

}


try // OBTENER USUARIO POR ID
{
    Console.WriteLine(GestorUsuarioData.GetUsuarioPorId(1).Name);

}catch (Exception ex){

    Console.WriteLine($"{ex.Message}");

}

try  // AGREGAR USUARIO A LA TABLA SQL
{

   
    GestorUsuarioData.AddUsuario(usuario);

    var listaUsuarios = GestorUsuarioData.GetListaUsuarios();

    foreach (var item in listaUsuarios)
    {
        Console.WriteLine(item.Name);
    }

}catch (Exception ex){

    Console.WriteLine($"{ex.Message}");

}

try // MODIFICAR USUARIO DE LA TABLA SQL
{

    GestorUsuarioData.UpdateUsuario(4, usuario);

    var listaUsuarios = GestorUsuarioData.GetListaUsuarios();

    foreach (var item in listaUsuarios)
    {
        Console.WriteLine(item.Name);
    }

}catch (Exception ex){

    Console.WriteLine($"{ex.Message}");

}




try //ELIMINAR USUARIO DE LA TABLA SQL
{
    GestorUsuarioData.DeleteUsuario(4);

}catch (Exception ex){

    Console.WriteLine($"{ex.Message}");
}
