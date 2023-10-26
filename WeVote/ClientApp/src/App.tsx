import { useQuery } from "@tanstack/react-query";
import { useGetUserData } from "./API/vatcomply";
import "./App.css";
import { saveVisit } from "./API/backend";

function App() {
  const { data: clientData, isLoading, isError } = useGetUserData();

  const { data: saveData, isLoading: isSaveLoading } = useQuery({
    queryKey: ["POST_DATA"],
    queryFn: () => saveVisit(clientData!),
    enabled: !!clientData
  });

  if (isLoading) {
    return <div className="read-the-docs"> CARGANDO.... </div>;
  }
  if (isError) {
    return <div className="read-the-docs"> ERROR.... </div>;
  }
  return (
    <main>
      {isSaveLoading&&"Guardando datos en servidor...."}
      { String(saveData) }
      <h1>We-Vote Prueba técnica</h1>
      <div className="card">
        <p className="read-the-docs">
          Por tu dirección de IP
          <strong>{" " + clientData?.ip + " "}</strong>
        </p>
        <p className="read-the-docs">
          Se a detectado que eres de
          <strong>{" " + clientData?.countryName + " "}</strong>
          y tu moneda { clientData?.countryName? "esta": "es el"}
          <strong> {clientData?.currencyName} </strong>
        </p>
      </div>
    </main>
  );
}

export default App;
