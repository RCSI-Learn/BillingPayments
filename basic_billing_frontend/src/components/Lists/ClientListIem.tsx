import { useState } from "react";
import { Client } from "../../models/Client";
import { ClientBillsPendingList } from "./ClientBillsPendingList";

interface ClientListItemProps {
  clientItem: Client;
}

export const ClientListItem: React.FC<ClientListItemProps> = ({
  clientItem,
}) => {
  const [Active, setActive] = useState(false);
  return (
    <div style={{ borderStyle: "solid", borderBottomColor: "black" }}>
      <div
        style={{
          display: "flex",
          justifyContent: "space-between",
          alignItems: "center",
        }}
      >
        <label style={{ marginTop: "0.1em", marginLeft: "1em", fontWeight:"1.5em" }}>
          {clientItem.name}
        </label>
        <div
          style={{ marginTop: "0.1em", marginLeft: "auto" }}
          onClick={() => setActive(!Active)}
        >
          <label style={{ marginRight: "1em"}}>{Active ? "-" : "+"}</label>
        </div>
      </div>
      {Active ? <ClientBillsPendingList client={clientItem} /> : null}
    </div>
  );
};
