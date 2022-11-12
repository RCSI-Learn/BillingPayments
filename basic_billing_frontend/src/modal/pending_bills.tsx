import React, { ReactNode } from "react";

interface ModalType {
  children?: ReactNode;
  isOpenPendingBills: boolean;
  togglePendingBills: () => void;
}

export default function Pending_Bills(props: ModalType) {
  return (
    <>
      {props.isOpenPendingBills && (
        <div className="modal-overlay" onClick={props.togglePendingBills}>
          <div onClick={(e) => e.stopPropagation()} className="modal-box">
            {props.children}
          </div>
        </div>
      )}
    </>
  );
}
