import React, { ReactNode } from "react";

interface ModalType {
  children?: ReactNode;
  isOpenCreateBill: boolean;
  toggleCreateBill: () => void;
}

export default function Create_Bill(props: ModalType) {
  return (
    <>
      {props.isOpenCreateBill && (
        <div className="modal-overlay" onClick={props.toggleCreateBill}>
          <div onClick={(e) => e.stopPropagation()} className="modal-box">
            {props.children}
          </div>
        </div>
      )}
    </>
  );
}
