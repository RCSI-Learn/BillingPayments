import React, { useState } from "react";
import { NewBill } from "../../models/NewBill";
import { usePostCreateBillMutation } from "../../features/bills/apiSlice";
import { Select } from "../basicElements/Select";
import { Categories } from "../../app/categoriesDictionary";
import { PendingMonths } from "../../app/pendingMonthsDictionary";

export const CreateBillForm = () => {
  const [newBill, setNewBill] = useState<NewBill>({
    period: parseInt(Object.keys(PendingMonths)[0]),
    category: Object.keys(Categories)[0],
  });
  const [createBill] = usePostCreateBillMutation();
  const [confirmation, setConfirmation] = useState<boolean>(false);
  const [error, setError] = useState<boolean>(false);

  const handlePeriodChange = (SelectedKey: string) => {
    setNewBill({ ...newBill, period: parseInt(SelectedKey) });
  };

  const handleCategoryChange = (SelectedKey: string) => {
    setNewBill({ ...newBill, category: SelectedKey });
  };

  const handleSubmit = (e: React.SyntheticEvent) => {
    e.preventDefault();
    createBill({
      period: parseInt(newBill.period.toString()),
      category: newBill.category,
    })
      .then((res: any) => {
        if (res === undefined || res.error) {
          setConfirmation(false);
          setError(true);
        } else {
          setError(false);
          setConfirmation(true);
        }
      })
      .catch(() => {
        setError(false);
        setConfirmation(true);
      });
  };

  return (
    <div>
      <form
        style={{ textAlign: "center", marginTop: "2em", marginBottom: "2em" }}
        onSubmit={handleSubmit}
      >
        <label style={{ fontWeight: "bold", marginRight: "0.5em" }}>
          Period:{" "}
        </label>
        <Select
          onSelectOptionChange={handlePeriodChange}
          DictionaryKeyValues={PendingMonths}
        />
        <label
          style={{
            fontWeight: "bold",
            marginLeft: "1.5em",
            marginRight: "0.5em",
          }}
        >
          Category:{" "}
        </label>
        <Select
          onSelectOptionChange={handleCategoryChange}
          DictionaryKeyValues={Categories}
        />
        <br />
        <button
          style={{
            marginTop: "1.5em",
            backgroundColor: "#80808080",
            textDecoration: "none",
            paddingLeft: "1em",
            paddingRight: "1em",
          }}
        >
          CREATE
        </button>
        {confirmation && <p>Bill created successfully.</p>}
        {error && <p>Error...</p>}
      </form>
    </div>
  );
};
