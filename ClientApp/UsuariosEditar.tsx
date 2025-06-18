import { useState } from "react";

interface UsuariosEditarProps {
    id? : string
}

const UsuariosEditar = ({id}: UsuariosEditarProps) => {
    const [idUsuario, setIdUsuario] = useState(id);
    const [nombre, setNombre] = useState("");
    const [correo, setCorreo] = useState("");
    const [password, setPassword] = useState("");

    const guardar = async () => {
        const model = {
            "Nombre": nombre,
            "Correo": correo,
            "Password": password
        }

        console.log(model);
        let url = "/api/usuarios";
        let metodo = "POST";

        const resp = await fetch(url, {
            method: metodo,
            body: JSON.stringify(model),
            headers:{
                "Content-Type": "application/json"
            }
        });

        if(resp.ok) {
            alert("El registro se guardo correctamente");
        }
        else {
            const error = await resp.text()
            alert(error);
        }
    }

    return (
        <>
        <div className="container">
            <h1>Editar Usuario</h1>
        </div>
        <div className="container">
            <div className="row">
                <div className="col-12">
                    <div className="mb-3">
                        <label>Nombre</label>
                        <input type="text" className="form-control" onChange={(e) => setNombre(e.target.value)} ></input>
                    </div>
                </div>
                <div className="col-12">
                    <div className="mb-3">
                        <label>Correo Electrónico</label>
                        <input type="email" className="form-control" onChange={(e) => setCorreo(e.target.value)}></input>
                    </div>
                </div>
                <div className="col-12">
                    <div className="mb-3">
                        <label>Contraseña</label>
                        <input type="text" className="form-control" onChange={(e) => setPassword(e.target.value)}></input>
                    </div>
                </div>
                <div className="col-12 d-flex gap-2 justify-content-end">
                    <button className="btn btn-primary" onClick={guardar}>Guardar</button>
                    <a  href="/usuarios" className="btn btn-secondary">Regresar</a>
                </div>
            </div>
        </div>
        </>
    )
}

export default UsuariosEditar;