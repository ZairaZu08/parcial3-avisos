import { useState } from "react";
type Usuario = {
    "id": string,
    "Nombre": string,
    "Password": string,
    "Correo": string
}

const Usuarios = () => {
    //Datos
    const [registros, setRegistros] = useState<Usuario[]>([]);

    //Vista
    return (
        <>
        <div className="container">
            <h1>Usuarios</h1>
        </div>
        <div className="container">
            <div className="card">
                <div className="card-header">Búsqueda</div>
                <div className="card-body">
                    <div className="row">
                        <div className="col-12">
                            <div className="mb-3">
                                <label>Búsqueda de Usuarios</label>
                                <input type= "text" className="form-control" placeholder="Introduce el nombre o el correo"></input>
                            </div>
                        </div>
                        <div className="col-12">
                            <button className="btn btn-primary">Buscar</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div className="container mt-4">
            <div className="card">
                <div className="card-header">Usuarios existentes</div>
                <div className="car-body">
                    <table className="table table-striped">
                        <thead>
                            <tr>
                                <th>No.</th>
                                <th>Nombre</th>
                                <th>Correo</th>
                                <th>Password</th>
                                <th></th>
                            </tr>
                        </thead>
                        {
                            registros.length === 0 &&
                            <tbody>
                                
                            </tbody>
                        }
                        <tbody>
                            <tr>
                                <td>1</td>
                                <td>Nombre del usuario 1</td>
                                <td>Correo del usuario 1</td>
                                <td>Contraseña del usuario 1</td>
                                <td className="d-flex gap-2">
                                    <button className="btn btn-primary">Editar</button>
                                    <button className="btn btn-danger">Eliminar</button>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
        </>
    )
}

export default Usuarios;