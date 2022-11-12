import React, { ChangeEvent } from 'react';
import './App.css';
import axios from "axios";
import "bootstrap/dist/css/bootstrap.min.css";
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faEdit } from '@fortawesome/free-solid-svg-icons';
import { Modal } from 'reactstrap';
import { Bill } from "../Models/bill";
import { useState, useEffect } from 'react';
//import CreateBill from "./modal/create_bill";
import useCreateBill from "./hook/useCreateBill";
import usePendingBills from "./hook/usePendingBills";
import useSearchByCategory from "./hook/useSearchBills";

const GetUrl = "http://localhost:5000/billing/pending?ClientId=200";
//const UrlGetClientPendingsById = "http://localhost:5000/billing/pending?ClientId=300";
const UrlPostCreateBill = "http://localhost:5000/billing/bills";
const UrlGetClientPendingsById = "http://localhost:5000/billing/pending";
const UrlPostPayBill = "http://localhost:5000/billing/pay";
const UrlGetSearchByCategory = "http://localhost:5000/billing/search";

function App() {
  /** Fill list */
  const [bills, setBills] = useState<Bill[]>([]);

  useEffect(() => {
    axios.get(GetUrl).then(response => {
      setBills(response.data);
    })
  }, [])


  /** Create Bill */
  const initNewBill = {
    period: Number(0),
    category: ''
  }

  const [newBill, setnewBill] = useState(initNewBill);
  const { isOpenCreateBill, toggleCreateBill } = useCreateBill();

  const PostCreateBill = async () => {
    console.log(newBill);
    await axios.post(UrlPostCreateBill, { period: Number(newBill.period), category: newBill.category }).then(response => {
      setBills(response.data);
      toggleCreateBill();
    }).catch(error => {
      console.log(error.message);
    })
  }

  function handleInputChange(event: ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) {
    const { name, value } = event.target;
    setnewBill({ ...newBill, [name]: value })
  }


  /** Client Pendings by Id */
  const initClientPendingsById = {
    clientId: ''
  }
  const [ clientId, setinputClientId] = useState(initClientPendingsById.clientId);
  const { isOpenPendingBills, togglePendingBills } = usePendingBills();

  const GetClientPendingsById = async () => {
    console.log("id" + initClientPendingsById.clientId);
    axios.get(UrlGetClientPendingsById + `?clientId=${clientId}`).then(response => {
      setBills(response.data);
      togglePendingBills();
    }).catch(error => {
      console.log(error.message);
    })
  }

  function handleInputClientId(event: ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) {
    console.log("evento " + event.target);
    console.log(event.target.value);
     setinputClientId(event.target.value);
     console.log("init" + initClientPendingsById.clientId);
     console.log("input" + clientId);
  }


  /**Search by Category */
  const initCategory = {
    category: ''
  }
  const [category, setCategory] = useState(initCategory.category)

  const { isOpenSearchByCategory, toggleSearchByCategory } = useSearchByCategory();
  function handleCategoryChange(event: ChangeEvent<HTMLSelectElement>) {
    setCategory(event.target.value);
    GetSearchByCategory(event.target.value);
  };

  function GetSearchByCategory(category: string) {
    console.log(UrlGetSearchByCategory + `?category=${category}`);
    axios.get(UrlGetSearchByCategory + `?category=${category}`).then(response => {
      setBills(response.data);
      toggleSearchByCategory();
    }).catch(error => {
      console.log(error.message);
    })
  }

  /**Payment */

  const PayBill = async (PendingBill: Bill) => {
  //function PayBill(PendingBill: Bill) {
    console.log(PendingBill);
    await axios.post(UrlPostPayBill, { clientId: PendingBill.clientId, period: PendingBill.period, category: PendingBill.category }).then(response => {
      // this can be change in the future by I prefer show the paide
      let arResponse: Array<Bill> = [response.data];
      setBills(arResponse);
      // setinputClientId(PendingBill.clientId.toString());
      // GetClientPendingsById();
    }).catch(error => {
      console.log(error.message);
    })
  }

  return (
    <div className="App">
      <br /><br /><br />
      <button className="btn btn-warning" onClick={toggleCreateBill}>Create Bill</button>
      {"   "}
      <button className="btn btn-primary" onClick={togglePendingBills}>Search Pendings by Id</button>
      {"   "}
      <button className="btn btn-success" onClick={toggleSearchByCategory}>Payment History</button>
      <br /><br />
      <table className="table ">
        <thead>
          <tr>
            <th>ID</th>
            <th>ClientId</th>
            <th>Period</th>
            <th>Category</th>
            <th>State</th>
          </tr>
        </thead>
        <tbody>
          {bills.map(bill => {
            return (
              <tr key={bill.id}>
                <td>{bill.id}</td>
                <td>{bill.clientId}</td>
                <td>{bill.period}</td>
                <td>{bill.category}</td>
                <td>{bill.state}</td>
                <td>
                  {bill.state === 'PENDING' &&
                    <button onClick={() => PayBill(bill)} className="btn btn-primary" ><FontAwesomeIcon icon={faEdit} /></button>
                  }
                </td>
              </tr>
            )
          })}
        </tbody>
      </table>
      <Modal isOpen={isOpenCreateBill} toggle={toggleCreateBill}>
        <div className="form-group">
          <label htmlFor="period">Period</label>
          <input className="form-control" type="text" name="period" id="period" onChange={handleInputChange} />
          <br />
          <label htmlFor="category">Category</label>
          <input className="form-control" type="text" name="category" id="category" onChange={handleInputChange} />
          <br />
          <button onClick={PostCreateBill}> Create </button>
        </div>
      </Modal>

      <Modal isOpen={isOpenPendingBills} toggle={togglePendingBills}>
        <div className="form-group">
          <label htmlFor="clientId">Client Id</label>
          <input className="form-control" value={clientId} type="text" name="clientId" id="clientId" onChange={(clientId) => handleInputClientId(clientId)} />
          <br />
          <button onClick={GetClientPendingsById}>Search</button>
        </div>
      </Modal>

      <Modal isOpen={isOpenSearchByCategory} toggle={toggleSearchByCategory}>
        <div className="form-group">
          <br />
          <label htmlFor="category">Category</label>

          <select value={category} onChange={(category) => handleCategoryChange(category)}>
            <option value="WATER">WATER</option>
            <option value="ELECTRICITY">ELECTRICITY</option>
            <option value="SEWER">SEWER</option>
          </select>
          <br />
        </div>
        <br />
      </Modal>
    </div>
  );
}

export default App;