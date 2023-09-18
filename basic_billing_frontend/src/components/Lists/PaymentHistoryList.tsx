import { ClientBillDto } from "../../models/ClientBillDto";
import { useGetPaymentHistoryByCategoryQuery } from "../../features/bills/apiSlice";
import { Select } from "../basicElements/Select";
import { useState } from "react";
import { Categories } from "../../app/categoriesDictionary";

export const PaymentHistoryList = () => {
  const [selectedCategory, setSelectedCategory] = useState(Object.keys(Categories)[0]);
  const { data, isError, isLoading } = useGetPaymentHistoryByCategoryQuery(selectedCategory);

  if (isLoading) {
    return <div style={{ textAlign: "center" }}>Loading...</div>;
  }

  if (isError) {
    return <div style={{ textAlign: "center" }}>Error...</div>;
  }

  const handleCategoryChange = (SelectedKey: string) => {
    setSelectedCategory(SelectedKey);
  };

  return (
    <div style={{width:"50%", margin:"0 auto", backgroundColor:"silver", textAlign:"center" }}>
      <label
        htmlFor="category"
        style={{ fontWeight:"bold", marginLeft: "1.5em", marginRight: "0.5em" }}
      >
        Category:{" "}
      </label>
      <Select onSelectOptionChange={(e) => handleCategoryChange(e)} DictionaryKeyValues={Categories} />
      <table style={{width:"100%", marginTop:"2em"}}>
        <thead>
          <tr style={{fontWeight:"bold", borderBottom:"solid"}}>
            <td>Client</td>
            <td>Period</td>
            <td>Category</td>
          </tr>
        </thead>
        <tbody>
          {data?.map((clientBill: ClientBillDto, index:Number) => {
            const uniqueKey = `bill_${index}`;
            return (

              <tr style={{borderBottom:"inset"}} key={uniqueKey}>
                <td>{clientBill.clientName}</td>
                <td>{`${String(clientBill.period).slice(0, 4)}-${String(clientBill.period).slice(4, 6)}`}</td>
                <td>{clientBill.category}</td>
              </tr>
            );
          })}
        </tbody>
      </table>
    </div>
  );
};
