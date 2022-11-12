import { useState } from "react";

export default function usePendingBills() {
  const [isOpenPendingBills, setisOpenPendingBills] = useState(false);

  const togglePendingBills= () => {
    setisOpenPendingBills(!isOpenPendingBills);
  };

  return {
    isOpenPendingBills,
    togglePendingBills
  };
}