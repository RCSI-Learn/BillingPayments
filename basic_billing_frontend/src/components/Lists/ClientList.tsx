import { Client } from "../../models/Client";
import { useGetAllClientsQuery } from "../../features/bills/apiSlice";
import { ClientListItem } from "./ClientListIem";

export const ClientList = () => {
  const { data, isError, isLoading } = useGetAllClientsQuery("");

  if (isLoading) {
    return <div style={{ textAlign: "center" }}>Loading...</div>;
  }

  if (isError) {
    return <div style={{ textAlign: "center" }}>Error...</div>;
  }

  return (
    <div style={{ width: "50%", margin: "0 auto", backgroundColor: "silver" }}>
      {data?.map((client: Client) => {
        return <ClientListItem key={client.id} clientItem={client} />;
      })}
    </div>
  );
};
