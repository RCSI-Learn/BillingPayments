import React, { ReactNode } from "react";

interface ModalType {
  children?: ReactNode;
  isOpenSearchByCategory: boolean;
  toggleSearchByCategory: () => void;
}

export default function Search_Bills(props: ModalType) {
  return (
    <>
      {props.isOpenSearchByCategory && (
        <div className="modal-overlay" onClick={props.toggleSearchByCategory}>
          <div onClick={(e) => e.stopPropagation()} className="modal-box">
            {props.children}
          </div>
        </div>
      )}
    </>
  );
}
