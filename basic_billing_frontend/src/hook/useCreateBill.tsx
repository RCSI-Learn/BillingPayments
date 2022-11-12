import { useState } from "react";

export default function useCreateBill() {
  const [isOpenCreateBill, setisOpenCreateBill] = useState(false);

  const toggleCreateBill = () => {
    setisOpenCreateBill(!isOpenCreateBill);
  };

  return {
    isOpenCreateBill,
    toggleCreateBill
  };
}