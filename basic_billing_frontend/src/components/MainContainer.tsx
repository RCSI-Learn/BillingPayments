import { CreateBillForm } from "./forms/CreateBillForm";
import { ClientList } from "./Lists/ClientList";
import { PaymentHistoryList } from "./Lists/PaymentHistoryList";
import { useState } from "react";
import "./MainContainer.css";

export const MainContainer = () => {
  const [activeTab, setActiveTab] = useState("createBill");

  const handleTabClick = (tabName: string) => {
    setActiveTab(tabName);
  };

  return (
    <div style={{fontSize:"1rem"}}>
      <ul style={{marginBottom:"2rem"}}>
        <li
          onClick={() => handleTabClick("clientList")}
          className={activeTab === "clientList" ? "active" : ""}
        >
          CLIENT LIST
        </li>
        <li
          onClick={() => handleTabClick("createBill")}
          className={activeTab === "createBill" ? "active" : ""}
        >
          CREATE BILL
        </li>
        <li
          onClick={() => handleTabClick("paymentHistory")}
          className={activeTab === "paymentHistory" ? "active" : ""}
        >
          PAYMENT HISTORY
        </li>
      </ul>
      {activeTab === "createBill" && <CreateBillForm />}
      {activeTab === "clientList" && <ClientList />}
      {activeTab === "paymentHistory" && <PaymentHistoryList />}
    </div>
  );
};
