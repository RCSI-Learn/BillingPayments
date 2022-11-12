import { useState } from "react";

export default function useSearchByCategory() {
  const [isOpenSearchByCategory, setisOpenSearchByCategory] = useState(false);

  const toggleSearchByCategory= () => {
    setisOpenSearchByCategory(!isOpenSearchByCategory);
  };

  return {
    isOpenSearchByCategory,
    toggleSearchByCategory
  };
}