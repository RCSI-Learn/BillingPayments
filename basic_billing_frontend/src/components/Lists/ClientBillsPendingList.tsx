import { Client } from "../../models/Client";
import { Bill } from "../../models/Bill";
import { useGetPendignBillsByClientIdQuery, usePostPayBillMutation } from "../../features/bills/apiSlice";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faCheck } from "@fortawesome/free-solid-svg-icons";

interface ClientBillsPendingListProps {
  client: Client;
}
export const ClientBillsPendingList: React.FC<ClientBillsPendingListProps> = ({ client }) => {
  const { data, isError, isLoading, refetch } = useGetPendignBillsByClientIdQuery( client.id);

  const [payPendingBill] = usePostPayBillMutation();

  if (isLoading) {
    return <div style={{ textAlign: "center" }}>Loading...</div>;
  }

  if (isError) {
    return <div style={{ textAlign: "center" }}>Error...</div>;
  }

  const handlePayButton = (pendingBill: Bill) => {
    payPendingBill({
      clientId: pendingBill.clientId,
      period: pendingBill.period,
      category: pendingBill.category,
    }).then(() => {
      refetch();
    });
  };

  return (
    <div>
        <div
          style={{ fontSize: "15px", textAlign: "center", fontWeight: "bold" }}
        >
          PENDINGS
        </div>
        <table style={{ width: "100%", textAlign: "center" }}>
          <thead>
            <tr>
              <th>Period</th>
              <th>Category</th>
              <th>Pay?</th>
            </tr>
          </thead>
          <tbody>
            {data?.map((bill: Bill) => {
              return (
                <tr key={bill.id}>
                  <td>{`${String(bill.period).slice(0, 4)}-${String(
                    bill.period
                  ).slice(4, 6)}`}</td>
                  <td>{bill.category}</td>
                  <td>
                    {bill.state === "PENDING" && (
                      <button
                        title="Pay"
                        onClick={() => handlePayButton(bill)}
                        style={{ backgroundColor: "lightgray" }}
                      >
                        <FontAwesomeIcon icon={faCheck} />
                      </button>
                    )}
                  </td>
                </tr>
              );
            })}
          </tbody>
        </table>
    </div>
  );
};
